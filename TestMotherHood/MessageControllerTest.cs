using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using MotherHood;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

namespace TestMotherHood
{
    public class MessageControllerTest:  IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MessageControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task TestIndex()
        {
            var client = _factory.CreateClient();
            //act
            var response = await client.GetAsync("/");
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);

        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Messages/Index")]
        [InlineData("/Messages/Details/1")]
        [InlineData("/Messages/Edit/1")]
        [InlineData("/Messages/Create")]
        [InlineData("/Tema")]
        public async Task TestUserLogin(string url)
        {
            var client = _factory.CreateClient();
            //act
            var response = await client.GetAsync("/");
            int code = (int)response.StatusCode;
            var pageContents = await response.Content.ReadAsStringAsync();
            //assert
            Assert.Equal(200, code);
            Assert.Contains("Bejelentkezés", pageContents.ToString());
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Messages/Index")]
        [InlineData("/Messages/Create")]
        [InlineData("/Tema")]
        public async Task TestAllIndexPage(string url)
        {
            //Arange,Act,Assert
            //Arange

            //felhasznalo betoltese TestAuthHandler classbol
            var factory = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
                });
            });

            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            //act
            var response = await client.GetAsync(url);
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);
        }
    }
}
