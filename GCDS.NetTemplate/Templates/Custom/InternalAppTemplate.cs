using GCDS.NetTemplate.Components.Custom;
using GCDS.NetTemplate.Components.Gcds;
using System.Diagnostics;
using System.Reflection;

namespace GCDS.NetTemplate.Templates.Custom
{
    public class InternalAppTemplate(TemplateSettings settings) : Template(settings), ITemplate
    {
        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public required ExtAppHeader Header { get; set; }

        /// <summary>
        /// Loading all the configurations for the footer component
        /// </summary>
        public GcdsFooter Footer { get; set; } = new GcdsFooter();

        /// <summary>
        /// Apply a last modified date or version number
        /// Will atomatically grab the version from your dll.
        /// </summary>
        public GcdsDateModified DateModified { get; set; } = new GcdsDateModified()
        {
            // get the version number of the project that started (impemented this package) and trim any trailing zeros from the version
            Text = string.Join(".", 
                (FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()?.Location ?? string.Empty).FileVersion ?? string.Empty)
                .Split('.').Reverse().SkipWhile(s => s == "0").Reverse()),
            Type = GcdsDateModified.DateModifiedType.version
        };
    }
}
