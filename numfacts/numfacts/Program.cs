using numfacts.Constants;
using numfacts.Models;
using numfacts.Workers;
using RestSharp;
using System;

namespace numfacts
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Make sure the arguments are properly split apart before creating the argument model.
                string[] splitArgs = ArgumentsHandler.BreakApartArguments(args);
                
                // Create arguments model from passed in arguments. 
                ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(splitArgs);

                // Validate the arguments model before making the API request.
                ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

                // Notify the user that we're about to make an API request. 
                Console.WriteLine(OutputConstants.API_LOADING);

                // Make the API request. 
                NumfactsAPIClient numfactsAPIClient = new NumfactsAPIClient(
                    new RestClient(
                        NumfactsAPIClient.BuildAPIEndpointUrl(argumentsModel)
                    )
                );

                APIResponseModel apiResponseModel = numfactsAPIClient.GetNumFact();

                // Display the results to the user.
                if (apiResponseModel.Found)
                {
                    Console.WriteLine(OutputConstants.FACT_DISPLAY_TEMPLATE, MathOrTriviaFactPrefix(apiResponseModel), apiResponseModel.Number, apiResponseModel.Text);
                } else
                {
                    throw new Exception(ErrorConstants.NO_FACT_FOUND + apiResponseModel.Number);
                }

            } catch (Exception ex)
            {
                // Display the error to the user.
                Console.WriteLine(ex.Message);
            }
        }

        // Returns the appropriate output prefix for the fact depending on what the user requested.
        private static string MathOrTriviaFactPrefix(APIResponseModel responseModel)
        {
            if (responseModel.Type == APIConstants.MATH_FACT)
            {
                return OutputConstants.MATH_FACT_PREFIX;
            } else
            {
                return OutputConstants.TRIVIA_FACT_PREFIX;
            }
        } 
    }
}
