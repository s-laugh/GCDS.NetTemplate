using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components
{
    public class GcdsNavLink : CommonLinkBase, ISlotHeaderNavLink
    {
        public GcdsNavLink() { }

        [SetsRequiredMembers]
        public GcdsNavLink(string href, string text) : base(href, text) { }

        public bool Current { get; set; } 
    }
}
