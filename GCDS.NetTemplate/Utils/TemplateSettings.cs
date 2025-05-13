namespace GCDS.NetTemplate.Utils
{
    public class TemplateSettings : ITemplateSettings
    {
        // Set up consts here for easy editing to set as default values
        private const string _gcdsRootPathDefault = "https://cdn.design-system.alpha.canada.ca/@cdssnc";
        private const string _gcdsComponetsVersionDefault = "latest";
        private const string _gcdsCssDirectoryDefault = "/gcds-components@0.34.1/dist/gcds/gcds.css";
        private const string _gcdsModuleDirectoryDefault = "/gcds-components@0.34.1/dist/gcds/gcds.esm.js";
        private const string _gcdsJsDirectoryDefault = "/gcds-components@0.34.1/dist/gcds/gcds.js";
        private const string _gcdsUtilityDirectoryDefault = "/gcds-utility@1.8.0/dist/gcds-utility.min.css";  
        private const string _fontAwesomePathDefault = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css";

        /// <summary>
        /// root path to the GC Design System web location
        /// up to the version
        /// required to be loaded from the appsettings.json file
        /// </summary>
        public string GCDSRootPath { get; set; } = _gcdsRootPathDefault;

        /// <summary>
        /// version of GC Design System that should be targeted
        /// should be loaded from the appsettings.json file
        /// will default to 'latest' if not provided
        /// </summary>
        public string GCDSComponentsVersion { get; set; } = _gcdsComponetsVersionDefault;

        /// <summary>
        /// the directory where the css file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '/gcds-components@{0}/dist/gcds/gcds.css' if not provided
        /// </summary>
        public string GCDSCssDirectory { get; set; } = _gcdsCssDirectoryDefault;

        /// <summary>
        /// will generate a full path to the css file using the GCDSRootPath and GCDSCssDirectory, injecting the GCDSComponentsVersion
        /// </summary>
        public string GCDSCssFullPath
        {
            get
            {
                return GCDSRootPath + String.Format(GCDSCssDirectory, GCDSComponentsVersion);
            }
        }

        /// <summary>
        /// the directory where the js file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '/gcds-components@{0}/dist/gcds/gcds.js' if not provided
        /// </summary>
        public string GCDSJsDirectory { get; set; } = _gcdsJsDirectoryDefault;

        /// <summary>
        /// will generate a full path to the css file using the GCDSRootPath and GCDSJsDirectory, injecting the GCDSComponentsVersion
        /// </summary>
        public string GCDSJsFullPath
        {
            get
            {
                return GCDSRootPath + String.Format(GCDSJsDirectory, GCDSComponentsVersion);
            }
        }

        /// <summary>
        /// the directory where the js module file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '/gcds-components@{0}/dist/gcds/gcds.esm.js' if not provided
        /// </summary>
        public string GCDSModuleDirectory { get; set; } = _gcdsModuleDirectoryDefault;

        /// <summary>
        /// will generate a full path to the css file using the GCDSRootPath and GCDSModuleDirectory, injecting the GCDSComponentsVersion
        /// </summary>
        public string GCDSModuleFullPath
        {
            get
            {
                return GCDSRootPath + String.Format(GCDSModuleDirectory, GCDSComponentsVersion);
            }
        }

        /// <summary>
        /// the url where the font awesome css file is stored
        /// defaults to https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css
        /// </summary>
        public string FontAwesomePath { get; set; } = _fontAwesomePathDefault;

        /// <summary>
        /// the directory where the css file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '/gcds-utility@1.8.0/dist/gcds-utility.min.css' if not provided
        /// </summary>
        public string GCDSUtilityDirectory { get; set; } = _gcdsUtilityDirectoryDefault;

        /// <summary>
        /// will generate a full path to the css file using the GCDSRootPath and GCDSUtilityDirectory
        /// </summary>
        public string GCDSUtilityFullPath
        {
            get
            {
                return GCDSRootPath + GCDSUtilityDirectory;
            }
        }

        /// <summary>
        /// configuration toogle to load the latest bootstrap css from a CDN
        /// </summary>
        public bool LoadBootstrapCdn { get; set; }
    }
}
