using FluentAssertions;
using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using NSubstitute;
using System.Globalization;

namespace GCDS.NetTemplate.Test.CoreTests
{
    public class CultureProviderMiddlewareTests
    {
        private readonly CultureProviderMiddleware _provider = new();

        [Fact]
        public async Task DetermineProviderCultureResult_Throws_WhenHttpContextIsNull()
        {
            // Act
            Func<Task> act = () => _provider.DetermineProviderCultureResult(null!);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task DetermineProviderCultureResult_Throws_WhenLocalizationOptionsMissing()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.RequestServices = Substitute.For<IServiceProvider>();
            context.RequestServices.GetService(typeof(IOptions<RequestLocalizationOptions>)).Returns(null);

            // Act
            Func<Task> act = () => _provider.DetermineProviderCultureResult(context);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>()
                .WithParameterName("locOptions");
        }

        [Fact]
        public async Task DetermineProviderCultureResult_ReturnsCulture_WhenSupportedCultureProvided()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.QueryString = new QueryString($"?{CommonConstants.QUERYSTRING_CULTURE_KEY}=fr");

            var options = Options.Create(new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new("fr"), new("en") },
                DefaultRequestCulture = new RequestCulture("en")
            });

            var services = Substitute.For<IServiceProvider>();
            services.GetService(typeof(IOptions<RequestLocalizationOptions>)).Returns(options);
            context.RequestServices = services;

            // Act
            var result = await _provider.DetermineProviderCultureResult(context);

            // Assert
            result.Should().NotBeNull();
            result!.Cultures.Should().ContainSingle().Which.Value.Should().Be("fr");
        }

        [Fact]
        public async Task DetermineProviderCultureResult_FallsBackToDefault_WhenUnsupportedCultureProvided()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.QueryString = new QueryString($"?{CommonConstants.QUERYSTRING_CULTURE_KEY}=de");

            var options = Options.Create(new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new("fr"), new("en") },
                DefaultRequestCulture = new RequestCulture("en")
            });

            var services = Substitute.For<IServiceProvider>();
            services.GetService(typeof(IOptions<RequestLocalizationOptions>)).Returns(options);
            context.RequestServices = services;

            // Act
            var result = await _provider.DetermineProviderCultureResult(context);

            // Assert
            result.Should().NotBeNull();
            result!.Cultures.Should().ContainSingle().Which.Value.Should().Be("en");
        }

        [Fact]
        public async Task DetermineProviderCultureResult_ReturnsNull_WhenNoCultureQuery()
        {
            // Arrange
            var context = new DefaultHttpContext();

            var options = Options.Create(new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new("fr"), new("en") },
                DefaultRequestCulture = new RequestCulture("en")
            });

            var services = Substitute.For<IServiceProvider>();
            services.GetService(typeof(IOptions<RequestLocalizationOptions>)).Returns(options);
            context.RequestServices = services;

            // Act
            var result = await _provider.DetermineProviderCultureResult(context);

            // Assert
            result.Should().BeNull();
        }
    }
}
