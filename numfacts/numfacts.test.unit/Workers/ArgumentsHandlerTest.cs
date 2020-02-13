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
            // Arrange
            string[] args = new string[1] { "/r/t" };

            // Act
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            // Assert
            Assert.AreEqual("/r", splitArguments[0]);
            Assert.AreEqual("/t", splitArguments[1]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsWithSpaces()
        {
            // Arrange
            string[] args = new string[1] { "/r /t" };

            // Act
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            // Assert
            Assert.AreEqual("/r", splitArguments[0]);
            Assert.AreEqual("/t", splitArguments[1]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsInSeparateElements()
        {
            // Arrange
            string[] args = new string[2] { "33" , "/r/t" };

            // Act
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            // Assert
            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        [TestMethod]
        public void ShouldSeparateArgumentsInSeparateElementsWithSpaces()
        {
            // Arrange
            string[] args = new string[2] { "33", "/r /t" };

            // Act
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            // Assert
            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        [TestMethod]
        public void ShouldNotSeparateProperlySpacedElements()
        {
            // Arrange
            string[] args = new string[3] { "33", "/r", "/t" };

            // Act
            string[] splitArguments = ArgumentsHandler.BreakApartArguments(args);

            // Assert
            Assert.AreEqual("33", splitArguments[0]);
            Assert.AreEqual("/r", splitArguments[1]);
            Assert.AreEqual("/t", splitArguments[2]);
        }

        // CreateArgumentsModelFromUserInput tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenInvalidArgumentIsPassedIn()
        {
            // Arrange
            string[] args = new string[3] { "33", "/m", "sdflkjdsfs" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfNumberIsNotFirstArgument()
        {
            // Arrange
            string[] args = new string[2] { "/m", "33" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        [TestMethod]
        public void ShouldCreateModelWithSingleIntegerArgument()
        {
            // Arrange
            string[] args = new string[1] { "33" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            Assert.AreEqual(33, argumentsModel.Number);
            Assert.IsTrue(argumentsModel.NumberProvided);
        }

        [TestMethod]
        public void ShouldCreateModelWithAllPossibleArguments()
        {
            // Arrange
            string[] args = new string[4] { "33", "/r", "/m", "/t" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
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
            // Arrange
            string[] args = new string[2] { "33", "/m" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Act
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            // Assert
            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithNumberAndTriviaFact()
        {
            // Arrange
            string[] args = new string[2] { "33", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Act
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            // Assert
            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithRandomNumberAndMathFact()
        {
            // Arrange
            string[] args = new string[2] { "/r", "/m" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Act
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            // Assert
            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        public void ShouldConsiderModelValidWithRandomNumberAndTriviaFact()
        {
            // Arrange
            string[] args = new string[2] { "/r", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Act
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);

            // Assert
            Assert.IsTrue(modelIsValid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBothNumberAndRandomNumberAreRequested()
        {
            // Arrange
            string[] args = new string[2] { "33", "/r" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBothMathAndTriviaFactsAreRequested()
        {
            // Arrange
            string[] args = new string[2] { "/m", "/t" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenNumberIsProvidedButFactIsNot()
        {
            // Arrange
            string[] args = new string[1] { "33" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenRandomNumberIsRequestedButFactIsNot()
        {
            // Arrange
            string[] args = new string[1] { "/r" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenMathFactIsProvidedButNumberIsNot()
        {
            // Arrange
            string[] args = new string[1] { "/m" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenTriviaFactIsProvidedButNumberIsNot()
        {
            // Arrange
            string[] args = new string[1] { "/t" };

            // Act
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            // Assert
            bool modelIsValid = ArgumentsHandler.ValidateArgumentsModel(argumentsModel);
        }
    }
}
