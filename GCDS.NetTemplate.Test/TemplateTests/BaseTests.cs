using FluentAssertions;
using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class BaseTests
    {
        [Fact]
        public void TemplateBase_Initialize_ShouldSetDefaultValues()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new Basic(settings);
            // Act
            template.Initialize("Test Page");
            // Assert
            template.Lang.Should().NotBeNullOrEmpty();
            template.PageTitle.Should().Be("Test Page");
            template.HeadElements.Should().NotBeNull();
            template.Header.Should().NotBeNull();
            template.Footer.Should().NotBeNull();
        }

        [Fact]
        public void TemplateBase_SetLanguageToggleHref_ShouldSetHref()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new Basic(settings);
            string href = "https://example.com/lang-toggle";
            // Act
            template.SetLanguageToggleHref(href);
            // Assert
            template.Header.LangHref.Should().Be(href);
        }
    }
}
