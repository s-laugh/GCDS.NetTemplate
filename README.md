# DotNetTemplates-GCDS
An attempt at simulating the DotNetTemplates for the CDTS, but instead for GCDS

Currently only designed for MVC, although would like to include Blazor and Razor.

NOTE: namespaces and general naming will likely still change as the organziation is finalized to be more adaptable.

## Using / Implementing / Installing

1. Download the GCDS.NetTemplate from Nuget.org into an .NET 8 or later MVC project

2. Add at least one configuration values to your `appsettings.json` and any that you want to override from the defaults (defaults are shown bellow)
    ```json
    "TemplateSettings": {
        "GCDSRootPath": "https://cdn.design-system.alpha.canada.ca/@cdssnc",
        "GCDSComponentsVersion": "latest",
        "GCDSCssDirectory": "/gcds-components@{0}/dist/gcds/gcds.css",
        "GCDSJsDirectory": "/gcds-components@{0}/dist/gcds/gcds.js",
        "GCDSModuleDirectory": "/gcds-components@{0}/dist/gcds/gcds.esm.js",
        "FontAwesomePath": "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css",
        "GCDSUtilityDirectory": "/gcds-utility@1.8.0/dist/gcds-utility.min.css",
        "LoadBootstrapCdn": false
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
    - `_Layout.Default`
    - `_Layout.Internal`
    Provided Partials:
    - `Breadcrumbs`
    - `Footer`
    - `Head`
    - `Header`
    - `Menu`
    - `NavLink`
    - `Search`
    - `TopicMenu`
    - `TopNav`

## Developing / Contributing

Anyone can create Issues (Bugs, Feature Requests, Suggestions)

You must be GC employee to contribute. Fork and make a pull request with signed commits.

It's using .NET 8, Visaul Studio or VSCode should work.

Use the Sanity project to run and validate changes locally, as these a files that should not be released in the package.
