using numfacts.Constants;
using numfacts.Models;
using RestSharp;
using System;
using System.Net;

namespace numfacts.Workers
{
    public class NumfactsAPIClient
    {
        private readonly IRestClient _client;

        public NumfactsAPIClient(IRestClient client) 
        {
            _client = client;
        }

        public APIResponseModel GetNumFact()
        {
            // Define return variable
            APIResponseModel apiResponseModel = null;

            // Instantiate RestClient and RestRequest objects.
            RestRequest request = new RestRequest(Method.GET);

            // Add API authentication headers
            request.AddHeader(APIConstants.HEADER_HOST_NAME, APIConstants.HEADER_HOST_VALUE);
            request.AddHeader(APIConstants.HEADER_KEY_NAME, APIConstants.HEADER_KEY_VALUE);

            // Add parameters
            request.AddParameter(APIConstants.FRAGMENT_PARAM, true, ParameterType.QueryString);
            request.AddParameter(APIConstants.JSON_PARAM, true, ParameterType.QueryString);

            // Execute request
            var response = _client.Execute<APIResponseModel>(request);

            // Return data or throw exception
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                apiResponseModel = response.Data;
            } else
            {
                throw new Exception(ErrorConstants.API_CONNECTION_ERROR);
            }

            return apiResponseModel;
        }

        // Returns the endpoint url we need based upon the user's arguments.
        public static string BuildAPIEndpointUrl(ArgumentsModel argumentsModel)
        {
            return $"{APIConstants.BASE_URL}/{NumberOrRandomNumberEndpoint(argumentsModel)}/{MathOrTriviaFactEndpoint(argumentsModel)}";
        }

        // Returns either an endpoint with the user's number or the "random" endpoint.
        private static string NumberOrRandomNumberEndpoint(ArgumentsModel argumentsModel)
        {
            if (argumentsModel.RandomNumber)
            {
                return APIConstants.RANDOM_NUMBER;
            }
            else
            {
                return argumentsModel.Number.ToString();
            }
        }

        // Returns endpoint for either a math or trivia fact.
        private static string MathOrTriviaFactEndpoint(ArgumentsModel argumentsModel)
        {
            if (argumentsModel.MathFact)
            {
                return APIConstants.MATH_FACT;
            }
            else
            {
                return APIConstants.TRIVIA_FACT;
            }
        }
    }
}
