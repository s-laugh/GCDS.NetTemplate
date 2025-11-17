using FluentAssertions;
using GCDS.NetTemplate.Core;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace GCDS.NetTemplate.Test.CoreTests
{
    public class InitializerTests
    {
        [Fact]
        public void InitializeTemplate_SetsTemplateInViewData_WithLang()
        {
            // Arrange
            var section = Substitute.For<IConfigurationSection>();
            var configuration = Substitute.For<IConfiguration>();

            configuration.GetSection("TemplateSettings").Returns(section);
            section.Bind(Arg.Do<TemplateSettings>(s => { }));

            var sut = new Initializer(configuration);
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            var context = new DefaultHttpContext();
            var pathBase = "/my/path/base";
            context.Request.PathBase = new PathString(pathBase);

            // Act
            sut.InitializeTemplate(viewData, context, null);

            // Assert
            viewData.Should().NotBeNull().And.HaveCount(1).And.ContainKey(CommonConstants.TEMPLATE_DATA);
            var template = viewData[CommonConstants.TEMPLATE_DATA] as Basic;
            template.Should().NotBeNull();
            template.Header.LangHref.Should().NotBeEmpty();
            template.HeadElements.Should().HaveCount(1);
            template.HeadElements.Select(e => e.Attributes).Select(a => a["href"]).Should().BeEquivalentTo($"{pathBase}/{Assets.BasePath}/images/icon.png");
        }
    }
}
