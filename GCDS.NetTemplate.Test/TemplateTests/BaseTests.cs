using FluentAssertions;
using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class BaseTests
    {
        [Theory, AutoNSubstituteData]
        public void TemplateBase_Initialize_ShouldSetDefaultValues(Basic sut)
        {
            // Act
            sut.Initialize("Test Page");
            // Assert
            sut.Lang.Should().NotBeNullOrEmpty();
            sut.PageTitle.Should().Be("Test Page");
            sut.HeadElements.Should().NotBeNull();
            sut.Header.Should().NotBeNull();
            sut.Footer.Should().NotBeNull();
        }

        [Theory, AutoNSubstituteData]
        public void TemplateBase_SetLanguageToggleHref_ShouldSetHref(Basic sut)
        {
            // Arrange
            string href = "https://example.com/lang-toggle";
            // Act
            sut.SetLanguageToggleHref(href);
            // Assert
            sut.Header.LangHref.Should().Be(href);
        }
    }
}
