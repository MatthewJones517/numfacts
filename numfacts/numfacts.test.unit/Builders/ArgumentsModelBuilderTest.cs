using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Builders;
using numfacts.Models;

namespace numfacts.test.unit.Builders
{
    [TestClass]
    public class ArgumentsModelBuilderTest
    {
        // Tests to make sure that the builder returns the proper defaults
        [TestMethod]
        public void ShouldCreateModelWithBuilderDefaults()
        {
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            Assert.AreEqual(int.MinValue, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        // Tests to make sure that the builder properly stores a number
        [TestMethod]
        public void ShouldCreateModelWithNumber()
        {
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            argumentsModelBuilder.WithNumber(33);
            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.IsTrue(argumentsModel.NumberProvided);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        // Tests to make sure that the builder properly stores the random number boolean
        [TestMethod]
        public void ShouldCreateModelWithRandomNumberBoolean()
        {
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            argumentsModelBuilder.WithRandomNumber();
            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            Assert.AreEqual(int.MinValue, argumentsModel.Number);
            Assert.IsFalse(argumentsModel.NumberProvided);
            Assert.AreEqual(true, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        // Tests to make sure that the builder properly stores the math fact boolean
        [TestMethod]
        public void ShouldCreateModelWithMathFactBoolean()
        {
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            argumentsModelBuilder.WithMathFact();
            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            Assert.AreEqual(int.MinValue, argumentsModel.Number);
            Assert.IsFalse(argumentsModel.NumberProvided);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(true, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        // Tests to make sure that the builder properly stores the trivia fact boolean
        [TestMethod]
        public void ShouldCreateModelWithTriviaFactBoolean()
        {
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            argumentsModelBuilder.WithTriviaFact();
            ArgumentsModel argumentsModel = argumentsModelBuilder.Build();

            Assert.AreEqual(int.MinValue, argumentsModel.Number);
            Assert.IsFalse(argumentsModel.NumberProvided);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(true, argumentsModel.TriviaFact);
        }
    }
}
