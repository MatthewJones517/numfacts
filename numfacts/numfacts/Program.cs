using numfacts.Models;
using numfacts.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts
{
    class Program
    {
        static void Main(string[] args)
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

                // Display the results to the user.

            } catch (Exception ex)
            {
                // Display the error to the user.
                Console.WriteLine(ex.Message);
            }
        }
    }
}
