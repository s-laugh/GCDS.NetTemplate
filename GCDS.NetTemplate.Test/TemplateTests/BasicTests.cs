using FluentAssertions;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Http;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class BasicTests
    {
        [Theory, AutoNSubstituteData]
        public void Basic_Template_ShouldHaveDefaultHeaderAndFooter(Basic sut)
        {
            // Arrange
            // Act
            sut.Initialize("Test Page");
            // Assert
            sut.Header.Should().NotBeNull();
            sut.Footer.Should().NotBeNull();
            sut.Header.SkipToHref.Should().Be($"#{CommonConstants.SKIP_TO_CONTENT_ID}");
            sut.Footer.Display.Should().Be(GcdsFooter.DisplayType.full);
        }

        [Theory, AutoNSubstituteData]
        public void Basic_Template_DateModified_ShouldReturnLastWriteTime(TemplateSettings settings, HttpContext context)
        {
            // Arrange
            var sut = new Basic(settings, context);
            // Act
            var dateModified = sut.DateModified;
            // Assert
            dateModified.Text.Should().NotBeNullOrEmpty();
            DateTime.TryParse(dateModified.Text, out _).Should().BeTrue();
        }

        [Theory, AutoNSubstituteData]
        public void Basic_Template_SetLanguageToggleHref_ShouldSetLangHref(Basic sut)
        {
            // Arrange
            string href = "https://example.com/lang-toggle";
            // Act
            sut.SetLanguageToggleHref(href);
            // Assert
            sut.Header.LangHref.Should().Be(href);
        }

        [Theory, AutoNSubstituteData]
        public void Basic_Template_Initialize_ShouldSetDefaultValues(Basic sut)
        {
            // Arrange
            // Act
            sut.Initialize("Test Page");
            // Assert
            sut.Lang.Should().NotBeNullOrEmpty();
            sut.PageTitle.Should().Be("Test Page");
            sut.HeadElements.Should().NotBeNull();
            sut.Header.Should().NotBeNull();
            sut.Footer.Should().NotBeNull();
        }
    }
}
