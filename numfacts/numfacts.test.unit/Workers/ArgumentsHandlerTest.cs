using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Models;
using numfacts.Workers;

namespace numfacts.test.unit.Workers
{
    [TestClass]
    public class ArgumentsHandlerTest
    {
        // BreakApartArguments tests
        [TestMethod]
        public void ShouldSeparateArgumentsWithNoSpaces()
        {
            string[] args = new string[1] { "/r/t" };
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            Assert.AreEqual("/r", splitArguments[0]);
            Assert.AreEqual("/t", splitArguments[1]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsWithSpaces()
        {
            string[] args = new string[1] { "/r /t" };
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            Assert.AreEqual("/r", splitArguments[0]);
            Assert.AreEqual("/t", splitArguments[1]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsInSeparateElements()
        {
            string[] args = new string[2] { "33" , "/r/t" };
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsInSeparateElementsWithSpaces()
        {
            string[] args = new string[2] { "33", "/r /t" };
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        [TestMethod]
        public void ShouldNotSeparateProperlySpacedElements()
        {
            string[] args = new string[3] { "33", "/r", "/t" };
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        // CreateArgumentsModelFromUserInput tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenInvalidArgumentIsPassedIn()
        {
            string[] args = new string[3] { "33", "/m", "sdflkjdsfs" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfNumberIsNotFirstArgument()
        {
            string[] args = new string[2] { "/m", "33" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        [TestMethod]
        public void ShouldCreateModelWithSingleIntegerArgument()
        {
            string[] args = new string[1] { "33" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.IsTrue(argumentsModel.NumberProvided);
        }

        [TestMethod]
        public void ShouldCreateModelWithAllPossibleArguments()
        {
            string[] args = new string[4] { "33", "/r", "/m", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.IsTrue(argumentsModel.RandomNumber);
            Assert.IsTrue(argumentsModel.MathFact);
            Assert.IsTrue(argumentsModel.TriviaFact);
            Assert.IsTrue(argumentsModel.NumberProvided);
        }

        // ValidateArgumentsModel tests

        [TestMethod]
        public void ShouldConsiderModelValidWithNumberAndMathFact()
        {
            string[] args = new string[2] { "33", "/m" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithNumberAndTriviaFact()
        {
            string[] args = new string[2] { "33", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithRandomNumberAndMathFact()
        {
            string[] args = new string[2] { "/r", "/m" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithRandomNumberAndTriviaFact()
        {
            string[] args = new string[2] { "/r", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBothNumberAndRandomNumberAreRequested()
        {
            string[] args = new string[2] { "33", "/r" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBothMathAndTriviaFactsAreRequested()
        {
            string[] args = new string[2] { "/m", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenNumberIsProvidedButFactIsNot()
        {
            string[] args = new string[1] { "33" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenRandomNumberIsRequestedButFactIsNot()
        {
            string[] args = new string[1] { "/r" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenMathFactIsProvidedButNumberIsNot()
        {
            string[] args = new string[1] { "/m" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenTriviaFactIsProvidedButNumberIsNot()
        {
            string[] args = new string[1] { "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }
    }
}
