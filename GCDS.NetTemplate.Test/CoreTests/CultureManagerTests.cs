using FluentAssertions;
using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using NSubstitute;
using System.Collections.Specialized;
using System.Globalization;

namespace GCDS.NetTemplate.Test.CoreTests
{
    public class CultureManagerTests
    {
        [Theory]
        [InlineData("en", "fr")]
        [InlineData("fr", "en")]
        public void AddTemplateLangugeToogle_ShouldToggleCultureCorrectly(string currentCulture, string expectedCulture)
        {
            // Arrange
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentCulture);
            var queryString = new QueryString("?page=home");

            // Act
            var result = queryString.AddTemplateLangugeToogle();

            // Assert
            result.Should().Contain("?page=home")
                  .And.Contain($"&{CommonConstants.QUERYSTRING_CULTURE_KEY}={expectedCulture}");
        }

        [Theory]
        [InlineData("en")]
        [InlineData("fr")]
        public void SetTemplateCulture_SetsCultureAndAppendsCookie(string cultureName)
        {
            // Arrange
            var httpContext = Substitute.For<HttpContext>();
            var response = Substitute.For<HttpResponse>();
            var cookies = Substitute.For<IResponseCookies>();

            httpContext.Response.Returns(response);
            response.Cookies.Returns(cookies);

            // Act
            httpContext.SetTemplateCulture(cultureName);

            // Assert
            Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.Should().Be(cultureName);

            cookies.Received(1).Append(
            CookieRequestCultureProvider.DefaultCookieName,
            Arg.Is<string>(val => val.Contains(cultureName)),
            Arg.Is<CookieOptions>(opt => opt.Expires.HasValue && opt.Expires.Value > DateTimeOffset.UtcNow)
            );
        }
    }
}
