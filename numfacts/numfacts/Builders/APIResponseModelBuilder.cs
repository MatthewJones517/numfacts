using numfacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts.Builders
{
    class APIResponseModelBuilder
    {
        private string _text;
        private int _number;
        private bool _found;
        private string _type;

        public APIResponseModelBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _text = string.Empty;
            _number = int.MinValue;
            _found = false;
            _type = string.Empty;
        }

        public APIResponseModelBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public APIResponseModelBuilder WithNumber(int number)
        {
            _number = number;
            return this;
        }

        public APIResponseModelBuilder WithFound(bool found)
        {
            _found = found;
            return this;
        }

        public APIResponseModelBuilder WithType (string type)
        {
            _type = type;
            return this;
        }

        public APIResponseModel Build()
        {
            APIResponseModel responseModel = new APIResponseModel();

            responseModel.Text = _text;
            responseModel.Number = _number;
            responseModel.Type = _type;
            responseModel.Found = _found;

            return responseModel;
        }
    }
}
