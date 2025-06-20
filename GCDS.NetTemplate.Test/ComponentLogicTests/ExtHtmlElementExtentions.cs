using FluentAssertions;
using GCDS.NetTemplate.Components;


namespace GCDS.NetTemplate.Test.ComponentLogicTests
{
    internal static class CommonValidatorExtentions
    {
        public static void HasAttribute(this ExtHtmlElement element, string key, string value)
        {
            element.Attributes.Should().ContainKey(key)
                .WhoseValue.Should().Be(value);
        }

        public static void HasDefaultMetaAttributes(this ExtHtmlElement element, string name, string content)
        {
            element.TagName.Should().Be("meta");
            element.HasAttribute("name", name);
            element.HasAttribute("content", content);
        }
    }
    public class ExtHtmlElementExtentionTests
    {
        [Fact]
        public void AddScript()
        {
            List<ExtHtmlElement> sut = [];
            string src = "src";
            sut.AddScript(src);

            sut.Should().HaveCount(1);
            var script = sut[0];
            script.TagName.Should().Be("script");
            script.HasAttribute("src", src);
            script.Attributes.Should().NotContainKey("async");
            script.Attributes.Should().NotContainKey("defer");
            script.InnerHtml.Should().Be("");
        }

        [Fact]
        public void AddLink()
        {
            List<ExtHtmlElement> sut = [];
            string href = "href";
            sut.AddLink(href);

            sut.Should().HaveCount(1);
            var link = sut[0];
            link.TagName.Should().Be("link");
            link.HasAttribute("rel", "stylesheet");
            link.HasAttribute("href", href);
            link.InnerHtml.Should().BeNull();
        }

        [Fact]
        public void AddStyle()
        {
            List<ExtHtmlElement> sut = [];
            string style = "style";
            sut.AddStyle(style);

            sut.Should().HaveCount(1);
            var elmt = sut[0];
            elmt.TagName.Should().Be("style");
            elmt.Attributes.Should().BeNullOrEmpty();
            elmt.InnerHtml.Should().Be(style);
        }

        [Fact]
        public void AddMeta_NoTitle()
        {
            List<ExtHtmlElement> sut = [];
            string name = "name";
            string content = "content";
            sut.AddMeta(name, content);

            sut.Should().HaveCount(1);
            var meta = sut[0];
            meta.TagName.Should().Be("meta");
            meta.HasDefaultMetaAttributes(name, content);
            meta.Attributes.Should().NotContainKey("title");
            meta.InnerHtml.Should().BeNull();
        }

        [Fact]
        public void AddMeta_WithTitle()
        {
            List<ExtHtmlElement> sut = [];
            string name = "name";
            string content = "content";
            string title = "title";
            sut.AddMeta(name, content, title);

            sut.Should().HaveCount(1);
            var meta = sut[0];
            meta.TagName.Should().Be("meta");
            meta.HasDefaultMetaAttributes(name, content);
            meta.HasAttribute("title", title);
            meta.InnerHtml.Should().BeNull();
        }

        [Theory, AutoNSubstituteData]
        public void AddCustom_NoHtml(string tag, Dictionary<string, string> attributes)
        {
            List<ExtHtmlElement> sut = [];
            sut.AddCustom(tag, attributes);

            sut.Should().HaveCount(1);
            var elmt = sut[0];
            elmt.TagName.Should().Be(tag);
            elmt.Attributes.Should().BeSameAs(attributes);
            elmt.InnerHtml.Should().BeNull();
        }

        [Theory, AutoNSubstituteData]
        public void AddCustom_WithHtml(string tag, Dictionary<string, string> attributes, string html)
        {
            List<ExtHtmlElement> sut = [];
            sut.AddCustom(tag, attributes, html);

            sut.Should().HaveCount(1);
            var elmt = sut[0];
            elmt.TagName.Should().Be(tag);
            elmt.Attributes.Should().BeSameAs(attributes);
            elmt.InnerHtml.Should().Be(html);
        }
    }
}