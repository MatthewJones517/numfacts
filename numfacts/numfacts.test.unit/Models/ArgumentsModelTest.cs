using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Models;

namespace numfacts.test.unit.Models
{
    [TestClass]
    public class ArgumentsModelTest
    {
        [TestMethod]
        public void ShouldCreateEmptyModel()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            Assert.AreEqual(0, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        [TestMethod]
        public void ShouldHoldNumberIntegerAndTriviaFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.Number = 33;
            argumentsModel.RandomNumber = false;
            argumentsModel.MathFact = false;
            argumentsModel.TriviaFact = true;

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(true, argumentsModel.TriviaFact);
        }

        [TestMethod]
        public void ShouldHoldNumberIntegerAndMathFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.Number = 33;
            argumentsModel.RandomNumber = false;
            argumentsModel.MathFact = true;
            argumentsModel.TriviaFact = false;

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(true, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        [TestMethod]
        public void ShouldHoldRandomNumberBooleanAndMathFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.RandomNumber = true;
            argumentsModel.MathFact = true;
            argumentsModel.TriviaFact = false;

            Assert.AreEqual(true, argumentsModel.RandomNumber);
            Assert.AreEqual(true, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
        }

        [TestMethod]
        public void ShouldHoldRandomNumberBooleanAndTriviaFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.RandomNumber = true;
            argumentsModel.MathFact = false;
            argumentsModel.TriviaFact = true;

            Assert.AreEqual(true, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(true, argumentsModel.TriviaFact);
        }
    }
}
