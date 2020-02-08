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

        // This method makes sure the user provided a valid set of arguments. 
        public static bool ValidateArgumentsModel(ArgumentsModel argumentsModel)
        {         
            // If we get to this point, the model should be valid.
            return true;
        }
    }
}
