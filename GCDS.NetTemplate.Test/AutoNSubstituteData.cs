using AutoFixture;
using AutoFixture.Xunit2;

namespace GCDS.NetTemplate.Test
{
    internal class AutoNSubstituteDataAttribute : AutoDataAttribute 
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture())
        { }
    }
}
