#pragma checksum "C:\Users\ADMIN\OneDrive\Desktop\SEM-5\WAD_PROJECT\TodolistProject\Views\Home\Error.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42ee2c3fcc66b72a4b389405bfbb37676c378d6abf1058389507ccfb80faa1fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"42ee2c3fcc66b72a4b389405bfbb37676c378d6abf1058389507ccfb80faa1fd", @"/Views/Home/Error.cshtml")]
    #nullable restore
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ADMIN\OneDrive\Desktop\SEM-5\WAD_PROJECT\TodolistProject\Views\Home\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>Error</h1>\r\n<p>");
            Write(
#nullable restore
#line 6 "C:\Users\ADMIN\OneDrive\Desktop\SEM-5\WAD_PROJECT\TodolistProject\Views\Home\Error.cshtml"
    ViewBag.ErrorMessage

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 93, "\"", 128, 1);
            WriteAttributeValue("", 100, 
#nullable restore
#line 8 "C:\Users\ADMIN\OneDrive\Desktop\SEM-5\WAD_PROJECT\TodolistProject\Views\Home\Error.cshtml"
          Url.Action("Index", "Home")

#line default
#line hidden
#nullable disable
            , 100, 28, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Go to Home</a>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
