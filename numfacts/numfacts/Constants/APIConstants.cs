using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts.Constants
{
    class APIConstants
    {
        // Header values. You will need to replace API_HEADER_KEY_VALUE with your own api key.
        public const string HEADER_KEY_NAME = "X-RapidAPI-Key";
        public const string HEADER_KEY_VALUE = "22f4edda2amshe3183f60ad0df3bp13dc9fjsn026d79530589";

        public const string HEADER_HOST_NAME = "X-RapidAPI-Host";
        public const string HEADER_HOST_VALUE = "numbersapi.p.rapidapi.com";

        // Endpoint Strings
        public const string BASE_URL = "https://numbersapi.p.rapidapi.com";
        public const string RANDOM_NUMBER = "random";
        public const string MATH_FACT = "math";
        public const string TRIVIA_FACT = "trivia";

        // Parameter Strings
        public const string FRAGMENT_PARAM = "fragment";
        public const string JSON_PARAM = "json";
    }
}
