namespace GCDS.NetTemplate.Utils
{
    public interface ITemplateSettings
    {
        /// <summary>
        /// root path to the GC Design System web location
        /// up to the version
        /// </summary>
        string GCDSRootPath { get; set; }

        /// <summary>
        /// version of GC Design System that should be targeted
        /// </summary>
        string GCDSComponentsVersion { get; set; }

        /// <summary>
        /// the directory where the css file is stored
        /// </summary>
        string GCDSCssDirectory { get; set; }

        /// <summary>
        /// should generate a full path to the css file using the GCDSRootPath, GCDSVersion and GCDSCssDirectory
        /// </summary>
        string GCDSCssFullPath { get; }

        /// <summary>
        /// the directory where the js file is stored
        /// </summary>
        string GCDSJsDirectory { get; set; }

        /// <summary>
        /// should generate a full path to the css file using the GCDSRootPath, GCDSVersion and GCDSJsDirectory
        /// </summary>
        string GCDSJsFullPath { get; }

        /// <summary>
        /// the directory where the js module file is stored
        /// </summary>
        string GCDSModuleDirectory { get; set; }

        /// <summary>
        /// should generate a full path to the css file using the GCDSRootPath, GCDSVersion and GCDSModuleDirectory
        /// </summary>
        string GCDSModuleFullPath { get; }

        /// <summary>
        /// the directory where the js module file is stored
        /// </summary>
        string GCDSUtilityDirectory { get; set; }

        /// <summary>
        /// should generate a full path to the css file using the GCDSRootPath, GCDSVersion and GCDSModuleDirectory
        /// </summary>
        string GCDSUtilityFullPath { get; }

        /// <summary>
        /// the url where the font awesome file is stored
        /// </summary>
        string FontAwesomePath { get; set; }

        /// <summary>
        /// configuration toogle to load the latest bootstrap css from a CDN
        /// </summary>
        bool LoadBootstrapCdn { get; set; }

    }
}
