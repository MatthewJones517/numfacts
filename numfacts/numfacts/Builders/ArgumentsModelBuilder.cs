using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using numfacts.Models;

namespace numfacts.Builders
{
    // This class builds an instance of ArgumentsModel, which holds the user's passed in arguments. 
    class ArgumentsModelBuilder
    {
        private int _number;
        // Any valid integer can be provided to _number, so we need a separate boolean for validation later on.
        private bool _numberProvided; 
        private bool _randomNumber;
        private bool _mathFact;
        private bool _triviaFact;

        public ArgumentsModelBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _number = int.MinValue;
            _numberProvided = false;
            _randomNumber = false;
            _mathFact = false;
            _triviaFact = false;
        }

        public ArgumentsModelBuilder WithNumber(int num)
        {
            _number = num;
            _numberProvided = true;
            return this;
        }

        public ArgumentsModelBuilder WithRandomNumber()
        {
            _randomNumber = true;
            return this;
        }

        public ArgumentsModelBuilder WithMathFact()
        {
            _mathFact = true;
            return this;
        }

        public ArgumentsModelBuilder WithTriviaFact()
        {
            _triviaFact = true;
            return this;
        }
        
        public ArgumentsModel Build()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.Number = _number;
            argumentsModel.NumberProvided = _numberProvided;
            argumentsModel.RandomNumber = _randomNumber;
            argumentsModel.MathFact = _mathFact;
            argumentsModel.TriviaFact = _triviaFact;

            return argumentsModel;
        }
    }   
}
