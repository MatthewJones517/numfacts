using numfacts.Constants;
using numfacts.Models;
using RestSharp;
using System.Threading.Tasks;

namespace numfacts.Workers
{
    static class NumfactsAPIClient
    {
        public static APIResponseModel GetNumFact(ArgumentsModel argumentsModel)
        {
            RestClient client = new RestClient(BuildAPIEndpointUrl(argumentsModel));
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader(APIConstants.HEADER_HOST_NAME, APIConstants.HEADER_HOST_VALUE);
            request.AddHeader(APIConstants.HEADER_KEY_NAME, APIConstants.HEADER_KEY_VALUE);

            IRestResponse<APIResponseModel> response = client.Execute<APIResponseModel>(request);

            return response.Data;
        }

        private static string BuildAPIEndpointUrl(ArgumentsModel argumentsModel)
        {
            string returnValue = APIConstants.BASE_URL;

            if (argumentsModel.RandomNumber)
            {
                returnValue += APIConstants.RANDOM_NUMBER_ENDPOINT;
            } else
            {
                returnValue += argumentsModel.Number.ToString();
            }

            returnValue += "/";

            if (argumentsModel.MathFact)
            {
                returnValue += APIConstants.MATH_FACT_ENDPOINT;
            } else
            {
                returnValue += APIConstants.TRIVIA_FACT_ENDPOINT;
            }

            returnValue += APIConstants.JSON_AND_FRAGMENT_ENDPOINT;

            return returnValue;
        }
    }
}
