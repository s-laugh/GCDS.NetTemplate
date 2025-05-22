# DotNetTemplates-GCDS
An attempt at simulating the [DotNetTemplates](https://github.com/wet-boew/cdts-DotNetTemplates) for the [CDTS](https://github.com/wet-boew/cdts-sgdc) and [WET](https://github.com/wet-boew/wet-boew), but instead for [GC Design System (GCDS)](https://github.com/cds-snc/gcds-components)

Currently only designed for MVC, although Razore might work and would like to include Blazor.

_NOTE: namespaces and general naming will likely still change as the organziation is finalized to be more adaptable._

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
    Add the `TemplateType` attribute on the contoler or method to change the template type, will default to the `BasicTemplate`
    ```csharp
    [TemplateType(typeof(InternalAppTemplate))]
    public IActionResult Internal()
    ```

6. Ensure your view points one of the templates provided Layouts (matching the tageted tempalte), or create your own using the components and partial views provided.

   Povided Layouts/Templates:
    - `_Layout.Basic` Will loosly match the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS
    - `_Layout.InternalApp` Custom template to build an internal application
    
   Provided Partials & matching Component class: (linked to GCDS matching component if avaliable)
    - GCDS components
      - [Breadcrumbs](https://design-system.alpha.canada.ca/en/components/breadcrumbs/)
      - [Footer](https://design-system.alpha.canada.ca/en/components/footer/)
      - [Header](https://design-system.alpha.canada.ca/en/components/header/)
      - [Link](https://design-system.alpha.canada.ca/en/components/link/)
      - _NavGroup_: A sub-component used in the `TopNav`
      - [Search](https://design-system.alpha.canada.ca/en/components/search/)
      - [Theme and topic menu (`TopicMenu`)](https://design-system.alpha.canada.ca/en/components/theme-and-topic-menu/)
      - [Top navigation (`TopNav`)](https://design-system.alpha.canada.ca/en/components/top-navigation/)
    - Custom components
      - InternalAppHeader: Custom Header for the `InternalAppTemplate`
      - SkipTo: Custom hidden link to skip to a section, used in the `InternalAppTemplate`
    - Other Partials
      - Head: Implements `TemplateSettings` for a `<head>` section
      - Menu: Helper to swap the `TopicMenu` or the `TopNav` for the `Header`

## Developing / Contributing

Anyone can create Issues (Bugs, Feature Requests, Suggestions)

You must be GC employee to contribute. Fork and make a pull request with signed commits.

It's using .NET 8, Visaul Studio or VSCode should work.

Use the Sanity project to run and validate changes locally, as these a files that should not be released in the package.
