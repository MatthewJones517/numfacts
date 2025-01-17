﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts
{
    class ErrorConstants
    {
        // Constants for the various error messages used throughout the application.
        public const string HOW_TO_USE = "Get a random fact for a whole number you specify. Usage:\n" +
                                       "numfacts [number] [attributes]" +
                                       "\n\nAttributes: \n" +
                                       "\n\t /m - Request a math fact." +
                                       "\n\t /t - Request a trivia fact." +
                                       "\n\t /r - Choose a random number";

        public const string INVALID_INPUT = "Error - Invalid number or attribute: ";
        public const string BOTH_RANDOM_AND_NUMBER_PROVIDED = "Error - You cannot both specify a number and request a random number.";
        public const string NEITHER_RANDOM_OR_NUMBER_PROVIDED = "Error - You must specify either a number or request a random number.";
        public const string BOTH_MATH_AND_TRIVIA_FACT_PROVIDED = "Error - You cannot request both a math and trivia fact at the same time.";
        public const string NEITHER_MATH_OR_TRIVIA_FACT_PROVIDED = "Error - You must specify either a math or a trivia fact.";
        public const string NO_FACT_FOUND = "The API couldn't find any facts for your number: ";
        public const string API_CONNECTION_ERROR = "There was an issue connecting to the API. Please wait a few minutes and try again.";
    }
}
