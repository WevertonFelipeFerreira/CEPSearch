using CEPSearch.Application.Services;
using CEPSearch.Domain.DTOs.Responses;
using CEPSearch.InfraExternal.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Refit;
using System.Net;
using System.Net.Http;
using Xunit;

namespace CEPSearch.Tests.Application.Services
{
    public class CepServiceTests
    {
        private readonly Mock<IViaCepExternalService> _viaCepExternalService;
        private readonly CepService cepService;
        public CepServiceTests()
        {
            _viaCepExternalService = new Mock<IViaCepExternalService>();
            cepService = new CepService(_viaCepExternalService.Object, Mock.Of<ILogger<CepService>>());
        }

        [Fact]
        public async void Get_AddressByCep_Success()
        {
            //Act
            string dummyCep = "13272524";
            _viaCepExternalService.Setup(x => x.GetCep(dummyCep)).ReturnsAsync(It.IsAny<CepResponse>);

            //Arrange
            var result = cepService.GetAddressByCep(dummyCep);

            //Assert
            var exception = await Record.ExceptionAsync(() => result);
            Assert.Null(exception);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Get_AddressByCep_MustFail()
        {
            //Act
            var exception = await ApiException.Create(
                new HttpRequestMessage(),
                HttpMethod.Get,
                new HttpResponseMessage(HttpStatusCode.BadRequest),
                null!);


            string? dummyCep = null;
            _viaCepExternalService.Setup(x => x.GetCep(dummyCep!)).ThrowsAsync(exception);

            //Arrange
            var result = cepService.GetAddressByCep(dummyCep!);

            //Assert
            var expt = await Record.ExceptionAsync(() => result);
            Assert.NotNull(exception);
        }
    }
}
