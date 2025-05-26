# DotNetTemplates-GCDS
An attempt at simulating the [DotNetTemplates](https://github.com/wet-boew/cdts-DotNetTemplates) for the [CDTS](https://github.com/wet-boew/cdts-sgdc) and [WET](https://github.com/wet-boew/wet-boew), but instead for [GC Design System (GCDS)](https://github.com/cds-snc/gcds-components)

Currently designed for MVC & Razor. Would like to include Blazor.

_NOTE: namespaces and general naming will likely still change as the organziation is finalized to be more adaptable._

## Using / Implementing / Installing

1. Download the `GCDS.NetTemplate` from Nuget.org into an .NET 8 or later MVC project

2. Add the required services to your application in your `Program.cs` enabling the dependancy injection of the template to work
    ```csharp
    builder.Services.AddMvcTemplateServices(); // for MVC projects
    builder.Services.AddRazorTemplateServices(); // for Razor projects
    ```

3. Ensure your view points one of the templates provided Layouts (matching the tageted tempalte, [_see bellow for changing the template_](#picking-your-template))
   Povided Layouts/Templates:
    - `_Layout.Basic` Will resemble the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS
    - `_Layout.InternalApp` Custom template to build an internal application [_see bellow for template requirements_](#using-internalapptemplate)

### Additional Features

#### Translation

Use the built-in Translation by adding additionall configurations to your `Program.cs`
```csharp
builder.Services.ConfigureTemplateCulture();
app.UseRequestLocalization();
```
### Picking your template

By default, the `BasicTemplate` will be loaded, and it will resemble the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS.

<details>
  <summary>Change the default template</summary>

  **Note: Be sure to use the corrisponding `_Layout.XXX` for the chosen template.**

Option 1. Set a default template type globally in the `Program.cs`.

```csharp
builder.Services.AddMvcTemplateServices(typeof(InternalAppTemplate)) // for MVC projects
builder.Services.AddRazorTemplateServices(typeof(InternalAppTemplate)) // for Razor projects
```

Option 2. Use a different template for a contoller/page or action by applying a `TemplateType` attribute. This Will take precidence over other defaults.

```csharp
[TemplateType(typeof(InternalAppTemplate))]
public IActionResult Index() / public class IndexModel : PageModel
```

Option 3. (**MVC only**) Use the template on only some contollers by not registering the service globally in the `Program.cs` and adding a ServiceFilter to the controler that should use it.

```csharp
// Program.cs
builder.Services.AddMvcTemplateServices(global: false)

// Controller
[ServiceFilter(typeof(TemplateActionFilter))] 
public class HomeController : Controller
```

</details>

### Leveraging the templates

In your page or controller, access the template to manipulate it to your needs.
This is how you can edit the breadcrumbs, menu, footer links, or override features like the language toggle.

```csharp
var template = ViewData.GetTemplate<InternalAppTemplate>();
```

#### Using `InternalAppTemplate`

This template will require you to manually create the `Header` with the required `SiteTitle` link.

```csharp
template.Header = new InternalAppHeader()
    {
        SiteTitle = new Link()
        {
            Text = "My Application",
            Href = Url.Page("Index")
        },
    };
```

_Reminder: Be sure to use the `_Layout.InternalApp` when using this template._

### Override Settings

Add configuration values to your `appsettings.json` to override from the defaults (shown in comments)
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

### Leverage the components

Leverage the component partials to build your own templates and features within your page.
Provided partials & matching component classes: (linked to GCDS matching component if avaliable)

_Note: Most GCDS compontes can be used natively within the view so are not buit as a partial_

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
