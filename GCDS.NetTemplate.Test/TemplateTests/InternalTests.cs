using FluentAssertions;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Http;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class InternalTests
    {
        [Theory, AutoNSubstituteData]
        public void InternalApp_Initialize_ShouldSetSiteTitle(InternalApp sut)
        {
            // Arrange
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            sut.Inizialize(pageTitle, siteTitle);
            // Assert
            sut.Header.Should().NotBeNull();
            sut.Header.AppHeaderTop.Should().NotBeNull();
            sut.Header.AppHeaderTop.SiteTitle.Text.Should().Be(siteTitle);
        }

        [Theory, AutoNSubstituteData]
        public void InternalApp_Initialize_ShouldSetPageTitle(InternalApp sut)
        {
            // Arrange
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            sut.Inizialize(pageTitle, siteTitle);
            // Assert
            sut.PageTitle.Should().Be(pageTitle);
        }

        [Theory, AutoNSubstituteData]
        public void InternalApp_Initialize_ShouldThrowIfSiteTitleIsNull(InternalApp sut)
        {
            // Arrange
            // Act
            Action act = () => sut.Inizialize(null!, (string)null!);
            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("*siteTitle*");
        }

        [Theory, AutoNSubstituteData]
        public void InternalApp_Inizialize_ShouldSetHeaderAndFooter(InternalApp sut)
        {
            // Arrange
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            sut.Inizialize(pageTitle, siteTitle);
            // Assert
            sut.Header.Should().NotBeNull();
            sut.Footer.Should().NotBeNull();
        }

        [Theory, AutoNSubstituteData]
        public void InternalApp_SetLanguageToggleHref_ShouldSetLangToggleHref(InternalApp sut)
        {
            // Arrange
            string href = "https://example.com/lang-toggle";
            // Act
            sut.SetLanguageToggleHref(href);
            // Assert
            sut.LangToggleHref.Should().Be(href);
        }

        [Theory, AutoNSubstituteData]
        public void InternalApp_DateModified_ShouldReturnVersion(TemplateSettings settings, HttpContext context)
        {
            // Arrange
            var sut = new InternalApp(settings, context);
            // Act
            var dateModified = sut.DateModified;
            // Assert
            dateModified.Text.Should().NotBeNullOrEmpty();
            dateModified.Type.Should().Be(GcdsDateModified.DateModifiedType.version);
        }
    }
}
