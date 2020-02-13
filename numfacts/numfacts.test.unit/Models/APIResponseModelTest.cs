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
            // Arrange / Act
            APIResponseModel apiResponseModel = new APIResponseModel();

            // Assert
            Assert.AreEqual(null, apiResponseModel.Text);
            Assert.AreEqual(null, apiResponseModel.Type);
            Assert.AreEqual(0, apiResponseModel.Number);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateFullModel()
        {
            // Arrange
            APIResponseModel apiResponseModel = new APIResponseModel();

            // Act
            apiResponseModel.Found = true;
            apiResponseModel.Text = "This is a random fact";
            apiResponseModel.Type = "Math";
            apiResponseModel.Number = 33;

            // Assert
            Assert.AreEqual("This is a random fact", apiResponseModel.Text);
            Assert.AreEqual("Math", apiResponseModel.Type);
            Assert.AreEqual(33, apiResponseModel.Number);
            Assert.IsTrue(apiResponseModel.Found);
        }
    }
}
