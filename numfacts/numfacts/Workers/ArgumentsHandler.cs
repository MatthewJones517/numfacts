using numfacts.Builders;
using numfacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts.Workers
{
    static class ArgumentsHandler
    {
        public static ArgumentsModel CreateArgumentsModelFromUserInput(string[] args)
        {
            // Create the model builder and begin the building process. Check for errors along the way.
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();

            // Loop through each argument and add it to the builder
            for (int i = 0; i < args.Length; i++)
            {
                // If this is the first argument, try to parse it as an integer. 
                if (i == 0)
                {
                    bool numberSuccessfullyParsed = int.TryParse(args[i], out int passedInNumber);

                    if (numberSuccessfullyParsed)
                    {
                        argumentsModelBuilder.WithNumber(passedInNumber);
                        continue;
                    }
                }

                // Check for valid options and update model build accordingly.
                switch (args[i])
                {
                    case Constants.RandomNumberFlag:
                        argumentsModelBuilder.WithRandomNumber();
                        break;

                    case Constants.MathFactFlag:
                        argumentsModelBuilder.WithMathFact();
                        break;

                    case Constants.TriviaFactFlag:
                        argumentsModelBuilder.WithTriviaFact();
                        break;

                    default:
                        throw new ArgumentException(Constants.InvalidInput + args[i]);
                }
            }

            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            return argumentsModel;
        }

        // It's possible for the user to provide arguments that conflict with each other. This method throws 
        // exceptions in these edge cases. 
        public static bool ValidateArgumentsModel(ArgumentsModel argumentsModel)
        {   
            // Make sure we didn't both provide a number and request a random one
            
            // Make sure we're not requesting both a math fact and a trivia fact. 
            
            // If we get to this point, the model should be valid.
            return true;
        }
    }
}
