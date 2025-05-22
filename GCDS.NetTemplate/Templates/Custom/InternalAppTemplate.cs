using GCDS.NetTemplate.Components.Custom;
using GCDS.NetTemplate.Components.Gcds;

namespace GCDS.NetTemplate.Templates.Custom
{
    public class InternalAppTemplate(TemplateSettings settings) : Template(settings), ITemplate
    {      
        public required InternalAppHeader Header { get; set; }

        public Footer Footer { get; set; } = new Footer();
    }
}
