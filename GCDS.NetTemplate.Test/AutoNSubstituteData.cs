using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Test
{
    internal class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AppCustomization()))
        { }
    }
        
    internal class AppCustomization : CompositeCustomization
    {
        public AppCustomization()
            : base(new CoreCustomization(), new AutoNSubstituteCustomization())
        { }
    }

    internal class CoreCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<HttpContext>(() => new DefaultHttpContext());
            fixture.Register(() => new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary()));
        }
    }
}
