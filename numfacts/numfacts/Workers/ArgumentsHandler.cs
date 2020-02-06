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
        public static bool ArgumentsWerePassedIn(string[] args)
        {
            // Check to make sure at least one argument has been passed in. If not, throw an exception.
            if (args.Length == 0)
            {
                throw new Exception(Constants.HowToUse);
            }

            return true;
        }
        
        public static ArgumentsModel CreateArgumentsModelFromUserInput(string[] args)
        {
            // Create the model builder and begin the building process. Check for errors along the way.
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();

            // Loop through each argument and add it to the builder
            for (int i = 0; i < args.Length; i++)
            {
                // If this is the first argument, try to parse it as an integer. 
                bool numberSuccessfullyParsed = false;

                if (i == 0)
                {
                    numberSuccessfullyParsed = int.TryParse(args[i], out int passedInNumber);

                    if (numberSuccessfullyParsed)
                    {
                        argumentsModelBuilder.WithNumber(passedInNumber);
                    }
                }

                // If the number didn't parse, or this isn't the first iteration of the loop,
                // check for valid options and update model build accordingly.
                if (!numberSuccessfullyParsed)
                {
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
                            throw new Exception(Constants.InvalidInput + args[i]);
                    }
                }
            }

            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            return argumentsModel;
        }
    }
}
