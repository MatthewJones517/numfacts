using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Models;

namespace numfacts.test.unit.Models
{
    [TestClass]
    public class ArgumentsModelTest
    {
        // Tests to make sure an empty model can be correctly instantiated.
        [TestMethod]
        public void ShouldCreateEmptyModel()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            Assert.AreEqual(0, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
            Assert.AreEqual(false, argumentsModel.NumberProvided);
        }

        // Tests to make sure model instantiates correctly with a number and the trivia fact boolean.
        [TestMethod]
        public void ShouldHoldNumberIntegerAndTriviaFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.Number = 33;
            argumentsModel.NumberProvided = true;
            argumentsModel.RandomNumber = false;
            argumentsModel.MathFact = false;
            argumentsModel.TriviaFact = true;

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(false, argumentsModel.MathFact);
            Assert.AreEqual(true, argumentsModel.TriviaFact);
            Assert.AreEqual(true, argumentsModel.NumberProvided);
        }

        // Tests to make sure model instantiates correctly with a number and the math fact boolean.
        [TestMethod]
        public void ShouldHoldNumberIntegerAndMathFactBoolean()
        {
            ArgumentsModel argumentsModel = new ArgumentsModel();

            argumentsModel.Number = 33;
            argumentsModel.NumberProvided = true;
            argumentsModel.RandomNumber = false;
            argumentsModel.MathFact = true;
            argumentsModel.TriviaFact = false;

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.AreEqual(false, argumentsModel.RandomNumber);
            Assert.AreEqual(true, argumentsModel.MathFact);
            Assert.AreEqual(false, argumentsModel.TriviaFact);
            Assert.AreEqual(true, argumentsModel.NumberProvided);
        }

        // Tests to make sure model instantiates correctly with the random number and math fact booleans set.
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
            Assert.AreEqual(false, argumentsModel.NumberProvided);
        }

        // Tests to make sure model instantiates correctly with the random number and trivia fact booleans set.
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
            Assert.AreEqual(false, argumentsModel.NumberProvided);
        }
    }
}
