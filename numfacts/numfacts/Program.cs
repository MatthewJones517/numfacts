using numfacts.Models;
using numfacts.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

                // Make the API request. 
                APIResponseModel apiResponseModel = NumfactsAPIClient.GetNumFact(argumentsModel);

                // Display the results to the user.
                if (apiResponseModel.Found)
                {
                    Console.WriteLine(apiResponseModel.Text);
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
    }
}
