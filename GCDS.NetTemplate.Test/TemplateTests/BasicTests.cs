using FluentAssertions;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class BasicTests
    {
        [Fact]
        public void Basic_Template_ShouldHaveDefaultHeaderAndFooter()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new Basic(settings);
            // Act
            template.Initialize("Test Page");
            // Assert
            template.Header.Should().NotBeNull();
            template.Footer.Should().NotBeNull();
            template.Header.SkipToHref.Should().Be($"#{CommonConstants.SKIP_TO_CONTENT_ID}");
            template.Footer.Display.Should().Be(GcdsFooter.DisplayType.full);
        }

        [Fact]
        public void Basic_Template_DateModified_ShouldReturnLastWriteTime()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new Basic(settings);
            // Act
            var dateModified = template.DateModified;
            // Assert
            dateModified.Text.Should().NotBeNullOrEmpty();
            DateTime.TryParse(dateModified.Text, out _).Should().BeTrue();
        }

        [Fact]
        public void Basic_Template_SetLanguageToggleHref_ShouldSetLangHref()
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

        [Fact]
        public void Basic_Template_Initialize_ShouldSetDefaultValues()
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
    }
}
