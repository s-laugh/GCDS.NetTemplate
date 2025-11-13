namespace GCDS.NetTemplate.Templates
{
    public class TemplateSettings //: ITemplateSettings
    {
        // Set up consts here for easy editing to set as default values
        private const string _gcdsRootPathDefault = "https://cdn.design-system.alpha.canada.ca/";
        private const string _gcdsComponentsVersionDefault = "latest";
        private const string _gcdsComponentsStylePathDefault = "@cdssnc/gcds-components@{0}/dist/gcds/gcds.css";
        private const string _gcdsComponentsModulePathDefault = "@cdssnc/gcds-components@{0}/dist/gcds/gcds.esm.js";
        private const string _gcdsCssShortcutsPathDefault = "@gcds-core/css-shortcuts@latest/dist/gcds-css-shortcuts.min.css";
        private const bool _splashLoadsDefaultBackgroundImage = true;

        /// <summary>
        /// root path to the GC Design System web location
        /// up to the version
        /// will default to 'https://cdn.design-system.alpha.canada.ca/' if not provided
        /// </summary>
        public string GcdsRootPath { get; set; } = _gcdsRootPathDefault;

        /// <summary>
        /// version of GC Design System that should be targeted
        /// should be loaded from the appsettings.json file
        /// will default to 'latest' if not provided
        /// </summary>
        public string GcdsComponentsVersion { get; set; } = _gcdsComponentsVersionDefault;

        /// <summary>
        /// the directory where the css file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '@cdssnc/gcds-components@{0}/dist/gcds/gcds.css' if not provided
        /// </summary>
        public string GcdsComponentsStylePath { get; set; } = _gcdsComponentsStylePathDefault;

        /// <summary>
        /// will generate a full path to the css file using the GcdsRootPath and GcdsComponentsStylePath, injecting the GcdsComponentsVersion
        /// </summary>
        public string GcdsComponentsStyleFullPath
        {
            get
            {
                return Path.Combine(GcdsRootPath, string.Format(GcdsComponentsStylePath, GcdsComponentsVersion));
            }
        }

        /// <summary>
        /// the directory where the js module file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '@cdssnc/gcds-components@{0}/dist/gcds/gcds.esm.js' if not provided
        /// </summary>
        public string GcdsComponentsModulePath { get; set; } = _gcdsComponentsModulePathDefault;

        /// <summary>
        /// will generate a full path to the css file using the GcdsComponentsModulePath and GcdsComponentsModulePath, injecting the GcdsComponentsVersion
        /// </summary>
        public string GcdsComponentsModuleFullPath
        {
            get
            {
                return Path.Combine(GcdsRootPath, string.Format(GcdsComponentsModulePath, GcdsComponentsVersion));
            }
        }

        /// <summary>
        /// the directory where the css file is stored
        /// can be loaded from the appsettings.json file
        /// will default to '@gcds-core/css-shortcuts@latest/dist/gcds-css-shortcuts.min.css' if not provided
        /// </summary>
        public string GcdsCssShortcutsPath { get; set; } = _gcdsCssShortcutsPathDefault;

        /// <summary>
        /// will generate a full path to the css file using the GcdsRootPath and GcdsCssShortcutsPath
        /// </summary>
        public string GcdsCssShortcutsFullPath
        {
            get
            {
                return Path.Combine(GcdsRootPath, GcdsCssShortcutsPath);
            }
        }

        public bool SplashLoadsDefaultBackgroundImage { get; set; } = _splashLoadsDefaultBackgroundImage;
    }
}
