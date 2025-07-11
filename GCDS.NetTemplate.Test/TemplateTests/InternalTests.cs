﻿using FluentAssertions;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.Test.TemplateTests
{
    public class InternalTests
    {
        [Fact]
        public void InternalApp_Initialize_ShouldSetSiteTitle()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new InternalApp(settings);
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            template.Inizialize(pageTitle, siteTitle);
            // Assert
            template.Header.Should().NotBeNull();
            template.Header.AppHeaderTop.Should().NotBeNull();
            template.Header.AppHeaderTop.SiteTitle.Text.Should().Be(siteTitle);
        }

        [Fact]
        public void InternalApp_Initialize_ShouldSetPageTitle()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new InternalApp(settings);
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            template.Inizialize(pageTitle, siteTitle);
            // Assert
            template.PageTitle.Should().Be(pageTitle);
        }

        [Fact]
        public void InternalApp_Initialize_ShouldThrowIfSiteTitleIsNull()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new InternalApp(settings);
            // Act
            Action act = () => template.Inizialize(null!, (string)null!);
            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("*siteTitle*");
        }

        [Fact]
        public void InternalApp_Inizialize_ShouldSetHeaderAndFooter()
        {
            // Arrange
            var settings = new TemplateSettings();
            string siteTitle = "Test Site";
            string pageTitle = "Test Page";
            // Act
            var template = new InternalApp(settings);
            template.Inizialize(pageTitle, siteTitle);
            // Assert
            template.Header.Should().NotBeNull();
            template.Footer.Should().NotBeNull();
        }

        [Fact]
        public void InternalApp_SetLanguageToggleHref_ShouldSetLangToggleHref()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new InternalApp(settings);
            string href = "https://example.com/lang-toggle";
            // Act
            template.SetLanguageToggleHref(href);
            // Assert
            template.LangToggleHref.Should().Be(href);
        }

        [Fact]
        public void InternalApp_DateModified_ShouldReturnVersion()
        {
            // Arrange
            var settings = new TemplateSettings();
            var template = new InternalApp(settings);
            // Act
            var dateModified = template.DateModified;
            // Assert
            dateModified.Text.Should().NotBeNullOrEmpty();
            dateModified.Type.Should().Be(GcdsDateModified.DateModifiedType.version);
        }
    }
}
