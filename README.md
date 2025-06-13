# DotNetTemplates-GCDS
A quick install template solution to develop and deploy .NET application using [GC Design System (GCDS)](https://github.com/cds-snc/gcds-components). Currently designed for MVC & Razor projects. 

_Open to adapting to Blazor, see [Issue: Include other .NET project types to the templates #2](../../issues/#2) for more details._

## Using / Implementing / Installing

1. Download the `GCDS.NetTemplate` from Nuget.org into an .NET 8 or later MVC project

2. Add the required services to your application in your `Program.cs` enabling the dependancy injection of the template to work
    ```csharp
    builder.Services.AddMvcTemplateServices(); // for MVC projects
    builder.Services.AddRazorTemplateServices(); // for Razor projects
    ```

3. Ensure your view points one of the templates provided Layouts (matching the tageted tempalte, ex. `GCDS.NetTemplate/_Layout.{XXX}`, [_see bellow for changing the template_](#picking-your-template))
   Povided Layouts/Templates:
    - **Basic** template will resemble the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS
    - **InternalApp** is a custom template to build an internal application [_see bellow for template requirements_](#using-internalapp-template)
    - **Splash** is a custom template to build an generic splash page [_see bellow for template requirements_](#using-splash-template)

### Additional Features

#### Translation

Use the built-in Translation by adding additionall configurations to your `Program.cs`

```csharp
builder.Services.ConfigureTemplateCulture();
app.UseRequestLocalization(); // part of .NET
```
### Picking your template

By default, the **Basic** template will be loaded, and it will resemble the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS.

_Note: Even if a template is loaded, you don't have to use it. It only gets used if your `GCDS.NetTemplate/_Layout.{XXX}` matches._

<details>
  <summary>Change the default template</summary>

  **Note: Be sure to use the corrisponding `GCDS.NetTemplate/_Layout.{XXX}` for the chosen template.**

Option 1. Set a default template type globally in the `Program.cs`.

```csharp
builder.Services.AddMvcTemplateServices(typeof(InternalApp)) // for MVC projects
builder.Services.AddRazorTemplateServices(typeof(InternalApp)) // for Razor projects
```

Option 2. Use a different template for a contoller, page or action by applying a `TemplateType` attribute. This Will take precidence over other defaults.

```csharp
[TemplateType(typeof(InternalApp))]
public IActionResult Index() // public class IndexModel : PageModel
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
var template = ViewData.GetTemplate<InternalApp>();
```

It's a good idea to set some basic properties specific to your useage, such as:

```csharp
template.PageTitle = "Text for the browser tab";
```

Since most sties work better with meta data, be sure to add some through the `HeadElements`. You can also add links to scripts and style pages, or any kind of head element you wish.

```csharp
template.HeadElements.AddMeta("description", "This is a custom splash page for testing purposes.");
template.HeadElements.AddStyle("p { font-size: 20px; }");
template.HeadElements.AddLink("https://www.google.ca/css/style.css");
template.HeadElements.AddScript("www.google.ca");
template.HeadElements.AddCustom("tag", new Dictionary<string, string> { { "tagAttribute", "value" } }, "innerHtml");
```

_Note: `Head` and `Script` sections are also avaliable on all templates._

#### Using InternalApp Template

It's recommended to use the `Inizialize` function on this template to set the required properties. This function is chainable to access other properties.

```csharp
template.Inizialize("My Application Title");
// OR
template.Inizialize(new ExtSiteTitle { Text = "Home", Href = "#" })
    .HeadElements.AddMeta("name", "content");
```

You can still self initialize the required props. When doing so you can access the `LangToggleHref` built by the template instaed of creating that yourself.

```csharp
template.Header = new ExtAppHeader
{
    AppHeaderTop = new ExtAppHeaderTop
    {
        LanguageToggle = new GcdsLangToggle { Href = template.LangToggleHref },
        SiteTitle = new ExtSiteTitle
        {
            Text = "My Application",
            Href = Url.Action("Index")
        },
    }
}
```

_Reminder: Be sure to use the `GCDS.NetTemplate/_Layout.InternalApp` when using this template._

#### Using Splash Template

This template will require you to manually create the `LanguageSelector`.

```csharp
template.LanguageSelector = new ExtLanguageSelector("Custom Splash Title", "Titre d'éclaboussure personnalisé", Url.Action("Home"));
```

By default, the splash page will load in either, english or french first depending on the current culture.
This could be nice if you want it to respond to the last language that was used for the site.
However if you need it to stick to one language, ensure to force the culture when loading the page.

```csharp
HttpContext.SetTemplateCulture(CommonConstants.ENGLISH_CULTURE);
```

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
    - [`GcdsBreadcrumbs`](https://design-system.alpha.canada.ca/en/components/breadcrumbs/)
    - [`GcdsDateModified`](https://design-system.alpha.canada.ca/en/components/date-modified/)
    - [`GcdsFooter`](https://design-system.alpha.canada.ca/en/components/footer/)
    - [`GcdsHeader`](https://design-system.alpha.canada.ca/en/components/header/)
    - [`GcdsLangToggle` (Language Toogle)](https://design-system.alpha.canada.ca/en/components/language-toggle/)
    - [`GcdsLink`](https://design-system.alpha.canada.ca/en/components/link/)
    - [`GcdsNavGroup`](https://github.com/cds-snc/gcds-components/tree/main/packages/web/src/components/gcds-nav-group): A sub-component used in the `GcdsTopNav`
    - [`GcdsNavLink`](https://github.com/cds-snc/gcds-components/tree/main/packages/web/src/components/gcds-nav-link): A sub-component used in `GcdsTopNav` and `GcdsNavGroup`
    - [`GcdsSearch`](https://design-system.alpha.canada.ca/en/components/search/)
    - [`GcdsSignature`](https://design-system.alpha.canada.ca/en/components/signature/)
    - [`GcdsTopicMenu` (Theme and topic menu)](https://design-system.alpha.canada.ca/en/components/theme-and-topic-menu/)
    - [`GcdsTopNav` (Top navigation)](https://design-system.alpha.canada.ca/en/components/top-navigation/)
  - Custom components
    - `ExtAppHeader`: Header for the `InternalApp` template
    - `ExtAppHeaderTop`: A top section for the `ExtAppHeader` 
    - `ExtHeadSettings`: Implements `TemplateSettings` for a `<head>` section
    - `ExtHtmlElement`: Enables the rendering of a fully customized html element, used for `HeadElements` (meta tags)
    - `ExtLanguageSelector`: A grid that has english and french links with titles for both, used in the `Splash` template
    - `ExtRandomBackground`: Will randomize a full screen background image base on a set of image paths, used in the `Splash` template
    - `ExtSiteTitle`: Title (link) for the `ExtAppHeaderTop`
    - `ExtSkipTo`: Custom hidden link to skip to a section, used in the `InternalApp` template
  - Other Partials
    - `SlotHeaderMenu`: Helper to swap the `TopicMenu` or the `TopNav` for the `Header`

## Developing / Contributing

Anyone can create Issues (Bugs, Feature Requests, Suggestions)

You must be GC employee to contribute. Fork and make a pull request with signed commits.

It's using .NET 8, Visaul Studio or VSCode should work.

Use the Sanity project to run and validate changes locally, as these a files that should not be released in the package.
