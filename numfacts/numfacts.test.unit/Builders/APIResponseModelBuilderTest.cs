using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Builders;
using numfacts.Models;

namespace numfacts.test.unit.Builders
{
    [TestClass]
    public class APIResponseModelBuilderTest
    {
        [TestMethod]
        public void ShouldCreateModelWithDefaultValues()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder.Build();

            Assert.AreEqual(int.MinValue, apiResponseModel.Number);
            Assert.AreEqual(string.Empty, apiResponseModel.Text);
            Assert.AreEqual(string.Empty, apiResponseModel.Type);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateModelWithNumberValue()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder.WithNumber(33).Build();

            Assert.AreEqual(33, apiResponseModel.Number);
            Assert.AreEqual(string.Empty, apiResponseModel.Text);
            Assert.AreEqual(string.Empty, apiResponseModel.Type);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateModelWithTextValue()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder.WithText("Random Fact").Build();

            Assert.AreEqual(int.MinValue, apiResponseModel.Number);
            Assert.AreEqual("Random Fact", apiResponseModel.Text);
            Assert.AreEqual(string.Empty, apiResponseModel.Type);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateModelWithTypeValue()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder.WithType("Math").Build();

            Assert.AreEqual(int.MinValue, apiResponseModel.Number);
            Assert.AreEqual(string.Empty, apiResponseModel.Text);
            Assert.AreEqual("Math", apiResponseModel.Type);
            Assert.IsFalse(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateModelWithFoundValue()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder.WithFound(true).Build();

            Assert.AreEqual(int.MinValue, apiResponseModel.Number);
            Assert.AreEqual(string.Empty, apiResponseModel.Text);
            Assert.AreEqual(string.Empty, apiResponseModel.Type);
            Assert.IsTrue(apiResponseModel.Found);
        }

        [TestMethod]
        public void ShouldCreateModelWithAllValues()
        {
            APIResponseModelBuilder apiResponseModelBuilder = new APIResponseModelBuilder();

            APIResponseModel apiResponseModel = apiResponseModelBuilder
                                                .WithText("Random Fact")
                                                .WithType("Math")
                                                .WithNumber(33)
                                                .WithFound(true)
                                                .Build();

            Assert.AreEqual(33, apiResponseModel.Number);
            Assert.AreEqual("Random Fact", apiResponseModel.Text);
            Assert.AreEqual("Math", apiResponseModel.Type);
            Assert.IsTrue(apiResponseModel.Found);
        }
    }
}
