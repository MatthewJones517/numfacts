using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts
{
    class Constants
    {
        public const string HowToUse = "Get a random fact for a number you specify. Usage:\n" +
                                       "numfacts [number] [attributes]" +
                                       "\n\t /m - Request a math fact." +
                                       "\n\t /t - Request a trivia fact." +
                                       "\n\t /r - Choose a random number" +
                                       "\nIf no attributes are given a trivia fact is returned.";
    }
}
