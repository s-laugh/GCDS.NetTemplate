A quick install template solution to develop and deploy .NET application using [GC Design System (GCDS)](https://github.com/cds-snc/gcds-components). Currently designed for MVC & Razor projects. 

# Implementing / Installing

1. Download the `GCDS.NetTemplate` from Nuget.org into an .NET 8 or later MVC project

2. Add the required services to your application in your `Program.cs` enabling the dependency injection of the template to work
    ```csharp
    builder.AddMvcTemplateServices(); // for MVC projects
    builder.AddRazorTemplateServices(); // for Razor projects
    ```

3. Ensure your view points one of the provided Layouts:
    - `GCDS.NetTemplate/_Layout` default layout for most pages
    - `GCDS.NetTemplate/_Layout.SideNav` customized layout when using the `SideNav` property
    - `GCDS.NetTemplate/_Layout.Splash` custom layout for use specifically with the `Splash` template, [_see bellow for more info_](#using-splash-template)

# Picking your template

By default, the **Basic** template will be loaded, and it will resemble the [Basic](https://design-system.alpha.canada.ca/en/page-templates/basic/) template from GCDS.

_Note: Even if a template is loaded, you don't have to use it. It only gets used if you are using one of the provided layouts._

Option 1. Set a default template type globally in the `Program.cs`.

```csharp
builder.Services.AddMvcTemplateServices(typeof(InternalApp)) // for MVC projects
builder.Services.AddRazorTemplateServices(typeof(InternalApp)) // for Razor projects
```

Option 2. Use a different template for a controller, page or action by applying a `TemplateType` attribute. This Will take precedence over other defaults.

```csharp
[TemplateType(typeof(InternalApp))]
public IActionResult Index() // public class IndexModel : PageModel
```

Option 3. (**MVC only**) Use the template on only some controllers by not registering the service globally in the `Program.cs` and adding a ServiceFilter to the controller that should use it.

```csharp
// Program.cs
builder.Services.AddMvcTemplateServices(global: false)

// Controller
[ServiceFilter(typeof(TemplateActionFilter))] 
public class HomeController : Controller
```

## Using InternalApp Template

It's recommended to use the `Initialize` function on this template to set the required properties. This function is chainable to access other properties.

```csharp
template.Initialize("My Application Title");
// OR
template.Initialize(new ExtSiteTitle { Text = "Home", Href = "#" })
    .HeadElements.AddMeta("name", "content");
```

You can still self initialize the required props. When doing so you can access the `LangToggleHref` built by the template instead of creating that yourself.

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

## Using Splash Template

Remember to Initialize the template!

```csharp
template.Initialize("Page Name", new ExtLanguageSelector("Custom Splash Title", "Titre d'éclaboussure personnalisé", Url.Action("Home")));
```

By default, the splash page will load in either, english or french first depending on the current culture.
This could be nice if you want it to respond to the last language that was used for the site.
However if you need it to stick to one language, ensure to force the culture when loading the page.

```csharp
HttpContext.SetTemplateCulture(CommonConstants.ENGLISH_CULTURE);
```

_Reminder: Be sure to use the `GCDS.NetTemplate/_Layout.Splash` when using this template

## Side (Left) Nav Variant

Available on the Basic and Internal template.

**Steps to use**
1. Target the left menu layout variant
    ```cshtml
    Layout = "GCDS.NetTemplate/_Layout.SideNav";
    ```

2. Set the `SideNav` property of your template has with either `GcdsSideNav` or `CustomPartial`
    ```csharp
    template.SideNav = new GcdsSideNav
    {
        Label = "Left Nav",
        Links =
        [
            new GcdsNavLink { Text = new HtmlString("Link 1"), Href = "#" },
            new GcdsNavGroup { Label = "Group 1",
                Links =
                [
                    new GcdsNavLink("#", "Link 1.1"),
                    new GcdsNavLink("#", "Link 1.2")
                ]
            },
            new GcdsNavLink ("#", "Link 2")
        ],
        StyleOverride = "background-color: #e1e4e7;"
    };
    // OR
    template.SideNav = new CustomPartial() { ViewName = "Banner", Model = new Banner { Text = "This is my custom menu" } };
    ```

3. _(Optional)_ Add `PreContent` section in your view, to come before the left menu, and wrap everything in the `main` tag
   ```html
   @section PreContent {
     <h1>Page H1 can go here</h1>
   }
   ```

4. _(Optional)_ Add `PostContent` section in your view, to come after the left menu and main body
   ```html
   @section PostContent {
     <p>Other pre-footer content can go here</p>
     <p>Will be after the `main` tag if PreContent is not provided</p>
   }
   ```

</details>

# Leveraging the templates

In your page or controller, access the template to manipulate it to your needs.
This is how you can edit the breadcrumbs, menu, footer links, or override features like the language toggle. The `Initialize` function will prompt you to add required fields.

```csharp
var template = ViewData.GetTemplate<InternalApp>();
template.Initialize(...)
```

## Adding Head data
 
Since most sites work better with meta data, be sure to add some through the `HeadElements`. You can also add links to scripts and style pages, or any kind of head element you wish.

```csharp
template.HeadElements.AddMeta("description", "This is a custom splash page for testing purposes.");
template.HeadElements.AddStyle("p { font-size: 20px; }");
template.HeadElements.AddLink("https://www.google.ca/css/style.css");
template.HeadElements.AddScript("www.google.ca");
template.HeadElements.AddCustom("tag", new Dictionary<string, string> { { "tagAttribute", "value" } }, "innerHtml");
```

_Note: `Head` and `Script` sections are also available on all templates._

## Dynamic ViewData 

While everything can be adjusted server side in code, sometimes the view needs to also adjust template settings and values. 

### Breadcrumbs & PageTitle

Adjust the breadcrumbs, and the browser's Page title
```cshtml
ViewBag.PageTitle = "Home Page"; // should use a localizer here
ViewBag.Breadcrumbs = new List<GcdsLink> {
    new("#", "Go back") // should use a Url.Action here
};
```

How they are used can also be modified with the following attributes: (the default is "Replace")
```csharp
public enum ViewDataAction { Replace, Prepend, Append }
template.PageTitleAction = TemplateBase.ViewDataAction.Append;
template.Header.Breadcrumbs.ItemsAction = TemplateBase.ViewDataAction.Prepend;
```

### SideNavWidth

Will default to `320px` the property will accept text so any %, px, em, ext. will work.
```cshtml
ViewBag.SideNavWidth = "20%";
```
[_Must be used on the SideNav layout_](#side-left-nav-variant)

### PageIdentifier

Will render on all templates (except Splash)  
This will render a identifier text bellow the DateModified
```cshtml
ViewBag.PageIdentifier = "CND-1";
```

## Override Settings

Add configuration values to your `appsettings.json` to override from the defaults (shown in comments)
```json
"TemplateSettings": {
    "GcdsRootPath": "https://cdn.design-system.alpha.canada.ca/",
    "GcdsComponentsVersion": "latest",
    "GcdsComponentsStylePath": "@gcds-core/components@{0}/dist/gcds/gcds.css",
    "GcdsComponentsModulePath": "@gcds-core/components@{0}/dist/gcds/gcds.esm.js",
    "GcdsCssShortcutsPath": "@gcds-core/css-shortcuts@latest/dist/gcds-css-shortcuts.min.css"
    "SplashLoadsDefaultBackgroundImage": true
}
```
GcdsComponentsVersion will be injected into `{0}`.
GcdsCssShortcutsPath has a distinct version it uses directly only.

## Leverage the components

Leverage the component partials to build your own templates and features within your page.
Provided partials & matching component classes: (linked to GCDS matching component if available)

_Note: Most GCDS components can be used natively within the view so are not built as a partial_

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
    - [`GcdsSideNav` (Left Menu)](https://design-system.alpha.canada.ca/en/components/side-navigation/)
  - Custom components
    - `ExtAppHeader`: Header for the `InternalApp` template
    - `ExtAppHeaderTop`: A top section for the `ExtAppHeader` 
    - `ExtHeadSettings`: Implements `TemplateSettings` for a `<head>` section
    - `ExtHtmlElement`: Enables the rendering of a fully customized html element, used for `HeadElements` (meta tags)
    - `ExtLanguageSelector`: A grid that has english and french links with titles for both, used in the `Splash` template
    - `ExtRandomBackground`: Will randomize a full screen background image base on a set of image paths, used in the `Splash` template
    - `ExtSiteTitle`: Title (link) for the `ExtAppHeaderTop`
    - `ExtSkipTo`: Custom hidden link to skip to a section, used in the `InternalApp` template
    - `ExtPageIdentifier`: Identify the page by a unique string provided via ViewData
  - Other Partials
    - `SlotHeader`: Helper to swap the `GcdsHeader` or the `ExtAppHeader` for the common layout
    - `SlotHeaderMenu`: Helper to swap the `GcdsTopicMenu` or the `GcdsTopNav` or `CustomPartial` for the `GcdsHeader.Menu` and `ExtAppHeader.Menu`
    - `SlotNavLinks`: Helper to iterate over a `IEnumerable<ISlotNavLink>` to swap the `GcdsNavLink` and the `GcdsNavGroup` for the `GcdsSideNav.Links` and `GcdsTopNav.Links`.
    - `SlotSideNav` : Helper to swap the `GcdsSideNav` or the `CustomPartial` for the Side Menu template variants.
    - `CustomPartial`: Enables providing a partial name, model, and view data, to load a fully custom partial.

# Additional Features

## Translation

Use the built-in Translation by adding additional configurations to your `Program.cs`

```csharp
builder.Services.ConfigureTemplateCulture();
app.UseRequestLocalization(); // part of .NET
```

# Developing / Contributing

Anyone can create Issues (Bugs, Feature Requests, Suggestions)

You must be GC employee to contribute. Fork and make a pull request with signed commits.

It's using .NET 8, Visual Studio or VSCode should work.

Use the Sanity project to run and validate changes locally, as these a files that should not be released in the package.
