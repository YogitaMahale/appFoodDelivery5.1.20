#pragma checksum "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b176d3bbbf2e2526bef96d58a25b6261aa26528c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Notification), @"mvc.1.0.view", @"/Views/Shared/_Notification.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b176d3bbbf2e2526bef96d58a25b6261aa26528c", @"/Views/Shared/_Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce4c353ae1028ea07b2b03f0350980e17deaa019", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
 if (TempData["success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        ");
#nullable restore
#line 4 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
   Write(TempData["success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 10 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
     if (TempData["error"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger alert-dismissible fade show\" role=\"alert\">\r\n            ");
#nullable restore
#line 16 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
       Write(TempData["error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n                <span aria-hidden=\"true\">&times;</span>\r\n            </button>\r\n        </div>\r\n");
#nullable restore
#line 22 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "F:\yogita 6.8.19\appFoodDelivery\appFoodDelivery\Views\Shared\_Notification.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
