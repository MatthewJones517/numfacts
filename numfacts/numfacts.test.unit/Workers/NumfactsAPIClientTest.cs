using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using Moq;
using numfacts.Builders;
using numfacts.Models;
using numfacts.Workers;

namespace numfacts.test.unit.Workers
{
    [TestClass]
    public class NumfactsAPIClientTest
    {
        [TestMethod]
        public void ShouldReturnURLForRandomNumberMathFact()
        {
            // Arrange
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            ArgumentsModel argumentsModel = argumentsModelBuilder.WithRandomNumber().WithMathFact().Build();

            // Act
            string endpointUrl = NumfactsAPIClient.BuildAPIEndpointUrl(argumentsModel);

            // Assert
            Assert.AreEqual($"https://numbersapi.p.rapidapi.com/random/math", endpointUrl);
        }

        [TestMethod]
        public void ShouldReturnURLForProvidedNumberTriviaFact()
        {
            // Arrange
            ArgumentsModelBuilder argumentsModelBuilder = new ArgumentsModelBuilder();
            ArgumentsModel argumentsModel = argumentsModelBuilder.WithNumber(33).WithTriviaFact().Build();

            // Act
            string endpointUrl = NumfactsAPIClient.BuildAPIEndpointUrl(argumentsModel);

            // Assert
            Assert.AreEqual($"https://numbersapi.p.rapidapi.com/33/trivia", endpointUrl);
        }

       [TestMethod]
       public void ShouldReturnApiResponseModelForProvidedNumberTriviaFact()
        {
            // Arrange
            APIResponseModel apiResponseModel = new APIResponseModel();
            apiResponseModel.Number = 33;
            apiResponseModel.Type = "trivia";
            apiResponseModel.Text = "some text";
            apiResponseModel.Found = true;

            Mock<IRestClient> mockIRestClient = new Mock<IRestClient>();
            mockIRestClient.Setup(x => x.Execute<APIResponseModel>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<APIResponseModel>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = apiResponseModel,
                });

            NumfactsAPIClient numfactsAPIClient = new NumfactsAPIClient(mockIRestClient.Object);

            // Act
            APIResponseModel response = numfactsAPIClient.GetNumFact();

            // Assert
            Assert.AreEqual(33, response.Number);
            Assert.AreEqual("trivia", response.Type);
            Assert.AreEqual("some text", response.Text);
            Assert.IsTrue(response.Found);
        }

        [TestMethod]
        public void ShouldReturnApiResponseModelForRandomNumberMathFact()
        {
            // Arrange
            APIResponseModel apiResponseModel = new APIResponseModel();
            apiResponseModel.Number = 2030;
            apiResponseModel.Type = "math";
            apiResponseModel.Text = "some text";
            apiResponseModel.Found = true;

            Mock<IRestClient> mockIRestClient = new Mock<IRestClient>();
            mockIRestClient.Setup(x => x.Execute<APIResponseModel>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<APIResponseModel>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = apiResponseModel,
                });

            NumfactsAPIClient numfactsAPIClient = new NumfactsAPIClient(mockIRestClient.Object);

            // Act
            APIResponseModel response = numfactsAPIClient.GetNumFact();

            // Assert
            Assert.AreEqual(2030, response.Number);
            Assert.AreEqual("math", response.Type);
            Assert.AreEqual("some text", response.Text);
            Assert.IsTrue(response.Found);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionOnAPIError()
        {
            // Arrange
            APIResponseModel apiResponseModel = new APIResponseModel();
            apiResponseModel.Number = 2030;
            apiResponseModel.Type = "math";
            apiResponseModel.Text = "some text";
            apiResponseModel.Found = true;

            Mock<IRestClient> mockIRestClient = new Mock<IRestClient>();
            mockIRestClient.Setup(x => x.Execute<APIResponseModel>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<APIResponseModel>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = "Internal Server Error",
                });

            NumfactsAPIClient numfactsAPIClient = new NumfactsAPIClient(mockIRestClient.Object);

            // Act
            APIResponseModel response = numfactsAPIClient.GetNumFact();
        }
    }
}
