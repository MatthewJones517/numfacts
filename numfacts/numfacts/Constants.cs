using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts
{
    class Constants
    {
        // Error Messages
        public const string HowToUse = "Get a random fact for a whole number you specify. Usage:\n" +
                                       "numfacts [number] [attributes]" +
                                       "Attributes: \n" +
                                       "\n\t /m - Request a math fact." +
                                       "\n\t /t - Request a trivia fact." +
                                       "\n\t /r - Choose a random number" +
                                       "\nIf no attributes are given a trivia fact is returned.";

        public const string InvalidInput = "Error - Invalid number or attribute: ";

        public const string BothRandomAndNumberProvided = "Error - You cannot specify both a number and request a random number.";

        // Attributes
        public const string RandomNumberFlag = "/r";
        public const string MathFactFlag = "/m";
        public const string TriviaFactFlag = "/t";
    }
}
