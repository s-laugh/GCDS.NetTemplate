using FluentAssertions;
using GCDS.NetTemplate.Test;

[assembly: FluentAssertions.Extensibility.AssertionEngineInitializer(
    typeof(AssertionEngineInitializer),
    nameof(AssertionEngineInitializer.AcknowledgeSoftWarning))]

namespace GCDS.NetTemplate.Test
{
    public static class AssertionEngineInitializer
    {
        public static void AcknowledgeSoftWarning()
        {
            License.Accepted = true;
        }
    }
}