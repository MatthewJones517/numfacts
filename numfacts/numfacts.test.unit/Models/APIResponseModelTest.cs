using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Models;

namespace numfacts.test.unit.Models
{
    [TestClass]
    public class APIResponseModelTest
    {
        [TestMethod]
        public void ShouldCreateEmptyModel()
        {
            APIResponseModel apiResponseModel = new APIResponseModel();

            Assert.AreEqual(null, apiResponseModel.Text);
            Assert.AreEqual(null, apiResponseModel.Type);
            Assert.AreEqual(0, apiResponseModel.Number);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateFullModel()
        {
            APIResponseModel apiResponseModel = new APIResponseModel();

            apiResponseModel.Found = true;
            apiResponseModel.Text = "This is a random fact";
            apiResponseModel.Type = "Math";
            apiResponseModel.Number = 33;
        }
    }
}
