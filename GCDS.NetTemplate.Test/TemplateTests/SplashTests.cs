using FluentAssertions;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Http;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class SplashTests
    {
        [Theory, AutoNSubstituteData]
        public void Splash_Template_Initialize_ShouldSetDefaultValues(TemplateSettings settings, ExtLanguageSelector languageSelector, HttpContext context)
        {
            // Arrange
            var template = new Splash(settings, context) { LanguageSelector = languageSelector };
            // Act
            template.Initialize("Test Splash Page");
            // Assert
            template.Lang.Should().NotBeNullOrEmpty();
            template.PageTitle.Should().Be("Test Splash Page");
            template.HeadElements.Should().NotBeNull();
        }
    }
}
