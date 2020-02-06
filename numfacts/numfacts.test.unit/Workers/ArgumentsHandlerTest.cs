using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using numfacts.Models;
using numfacts.Workers;

namespace numfacts.test.unit.Workers
{
    [TestClass]
    public class ArgumentsHandlerTest
    {
        // Should throw an exception if at least one argument isn't passed in.
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenNoArgumentsArePassedIn()
        {
            string[] args = new string[0];
            bool argumentsModelIsValid = ArgumentsHandler.ArgumentsWerePassedIn(args);
        }

        // Should return true with at least one argument. 
        [TestMethod]
        public void ShouldReturnTrueWhenAtLeastOneArgumentIsPassedIn()
        {
            string[] args = new string[1] { "33" };
            bool argumentsModelIsValid = ArgumentsHandler.ArgumentsWerePassedIn(args);

            Assert.IsTrue(argumentsModelIsValid);
        }

        // Should throw an exception if we provide an invalid argument
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenInvalidArgumentIsPassedIn()
        {
            string[] args = new string[3] { "33", "/m", "sdflkjdsfs" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        // Should throw an exception if we put the number anywhere but the first argument.
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionIfNumberIsNotFirstArgument()
        {
            string[] args = new string[2] { "/m", "33" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);
        }

        // Should create a model if a single number argument is passed in.
        [TestMethod]
        public void ShouldCreateModelWithSingleIntegerArgument()
        {
            string[] args = new string[1] { "33" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            Assert.AreEqual(33, argumentsModel.Number);
        }

        // Should create a model if all possible arguments are passed in
        [TestMethod]
        public void ShouldCreateModelWithAllPossibleArguments()
        {
            string[] args = new string[4] { "33", "/r", "/m", "/t" };
            ArgumentsModel argumentsModel = ArgumentsHandler.CreateArgumentsModelFromUserInput(args);

            Assert.AreEqual(33, argumentsModel.Number);
            Assert.IsTrue(argumentsModel.RandomNumber);
            Assert.IsTrue(argumentsModel.MathFact);
            Assert.IsTrue(argumentsModel.TriviaFact);
        }
    }
}
