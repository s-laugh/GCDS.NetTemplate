# DotNetTemplates-GCDS
An attempt at simulating the [DotNetTemplates](https://github.com/wet-boew/cdts-DotNetTemplates) for the [CDTS](https://github.com/wet-boew/cdts-sgdc) and [WET](https://github.com/wet-boew/wet-boew), but instead for [GC Design System (GCDS)](https://github.com/cds-snc/gcds-components)

Currently only designed for MVC, although would like to include Blazor and Razor.

NOTE: namespaces and general naming will likely still change as the organziation is finalized to be more adaptable.

## Using / Implementing / Installing

1. Download the `GCDS.NetTemplate` from Nuget.org into an .NET 8 or later MVC project

2. Add at least one configuration values to your `appsettings.json` and any that you want to override from the defaults (defaults are shown bellow)
    ```json
    "TemplateSettings": {
        "GCDSRootPath": "https://cdn.design-system.alpha.canada.ca/@cdssnc",
        "GCDSComponentsVersion": "latest",
        "GCDSCssDirectory": "/gcds-components@{0}/dist/gcds/gcds.css", //will have the `GCDSComponentsVersion` injected, alternatively a version can be provided directly in place of `{0}`
        "GCDSJsDirectory": "/gcds-components@{0}/dist/gcds/gcds.js", //will have the `GCDSComponentsVersion` injected, alternatively a version can be provided directly in place of `{0}`
        "GCDSModuleDirectory": "/gcds-components@{0}/dist/gcds/gcds.esm.js", //will have the `GCDSComponentsVersion` injected, alternatively a version can be provided directly in place of `{0}`
        "FontAwesomePath": "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css",
        "GCDSUtilityDirectory": "/gcds-utility@1.8.0/dist/gcds-utility.min.css",
        "LoadBootstrapCdn": false // loads Bootstarp v5.3.6 from their CDN
    }
    ```

3. Add the required services to your application in your `Program.cs` enabling the dependancy injection of the template to work
    ```csharp
    // template
    builder.Services.AddWebTemplateModelAccessor();
    builder.Services.ConfigureWebTemplateCulture();
    ```

4. Add the MVC localization in your `Program.cs` to use the defualt language toggle 
    ```csharp
    app.UseRequestLocalization();
    ```

5. Use the `TemplateActionFilter` on any Controller that you want to use the template with
   ```csharp
    [TemplateActionFilter]
    public class HomeController : Controller
    ```

6. Ensure your view points one of the templates provided Layouts, or create your own using the components and partial views provided.

   Povided Layouts:
    - `_Layout.Default` Will loosly match the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS
    - `_Layout.Internal` Custom template to build an internal application
    
   Provided Partials & matching Component class: (linked to GCDS matching component if avaliable)
    - Breadcrumbs: [Breadcrumbs](https://design-system.alpha.canada.ca/en/components/breadcrumbs/)
    - Footer: [Footer](https://design-system.alpha.canada.ca/en/components/footer/)
    - **Head**: Implements `TemplateSettings`
    - Header: [Header](https://design-system.alpha.canada.ca/en/components/header/)
    - **Menu**: Implements either the `TopicMenu` or the `TopNav`
    - __NavLink__: A sub-component for the `TopNav` using the `Link` class
    - Search: [Search](https://design-system.alpha.canada.ca/en/components/search/)
    - TopicMenu: [Theme and topic menu](https://design-system.alpha.canada.ca/en/components/theme-and-topic-menu/)
    - TopNav: [Top navigation](https://design-system.alpha.canada.ca/en/components/top-navigation/)

## Developing / Contributing

Anyone can create Issues (Bugs, Feature Requests, Suggestions)

You must be GC employee to contribute. Fork and make a pull request with signed commits.

It's using .NET 8, Visaul Studio or VSCode should work.

Use the Sanity project to run and validate changes locally, as these a files that should not be released in the package.
