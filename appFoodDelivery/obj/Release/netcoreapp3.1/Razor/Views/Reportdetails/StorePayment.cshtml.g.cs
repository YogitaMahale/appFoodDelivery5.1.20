#pragma checksum "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7da307e87311d651bd01083ab44e10a5071e9b04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportdetails_StorePayment), @"mvc.1.0.view", @"/Views/Reportdetails/StorePayment.cshtml")]
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
#line 1 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\_ViewImports.cshtml"
using appFoodDelivery.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7da307e87311d651bd01083ab44e10a5071e9b04", @"/Views/Reportdetails/StorePayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce4c353ae1028ea07b2b03f0350980e17deaa019", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportdetails_StorePayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<appFoodDelivery.pagination.OrderPagination<StorePaidAmountReportModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StorePayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
  
    ViewBag.Title = "Hotel Payment Report";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12 grid-margin"">
        <div class=""card"">


            <div class=""card-body"">
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da307e87311d651bd01083ab44e10a5071e9b045502", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">Hotel Payment Details</li>\r\n                    </ol>\r\n                </nav><br />\r\n");
#nullable restore
#line 20 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                 using (Html.BeginForm("StorePayment", "Reportdetails", FormMethod.Post))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row"">
                        <div class=""form-group col-md-1"">
                            <label>From Date</label>
                        </div>
                        <div class=""form-group col-md-2"">
                            <div class=""input-group date"" data-provide=""datepicker"">
");
            WriteLiteral("                                <input type=\"text\" id=\"datepicker1\" autocomplete=\"off\" class=\"form-control datepicker\"");
            BeginWriteAttribute("value", " value=\"", 1321, "\"", 1343, 1);
#nullable restore
#line 30 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
WriteAttributeValue("", 1329, ViewBag.from1, 1329, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"from1\">\r\n\r\n                                <div class=\"input-group-addon\">\r\n                                    <span class=\"glyphicon glyphicon-th\"></span>\r\n                                </div>\r\n                            </div>\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("                        </div>\r\n                        <div class=\"form-group col-md-1\">\r\n                            <label>To Date</label>\r\n                        </div>\r\n                        <div class=\"form-group col-md-2\">\r\n");
            WriteLiteral("                            <input type=\"text\" id=\"datepicker2\" autocomplete=\"off\" class=\"datepicker\"");
            BeginWriteAttribute("value", " value=\"", 2494, "\"", 2514, 1);
#nullable restore
#line 50 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
WriteAttributeValue("", 2502, ViewBag.to1, 2502, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"to1\">\r\n");
            WriteLiteral(@"                        </div>
                         


                        <div class=""form-group col-md-1"">
                            <label>Select Store</label>
                        </div>
                        <div class=""form-group col-md-2"">

                            ");
#nullable restore
#line 61 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                       Write(Html.DropDownList("storeid", (IEnumerable<SelectListItem>)ViewData["storelist"], new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                      
                    </div>
                    <div class=""row"" style=""text-align:center;"">
                        <div class=""form-group col-md-4"">
                        </div>
                        <div class=""form-group col-md-4"">
                            <input type=""submit"" name=""search"" value=""Search"" class=""btn btn-primary"" />
                            <input type=""submit"" name=""ExcelFileDownload"" value=""Excel Download"" class=""btn btn-primary"" />
                        </div>
                        <div class=""form-group col-md-4"">
                        </div>
                    </div>
");
#nullable restore
#line 75 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-12 table-responsive-md\" style=\"width:100px;overflow:auto;\">\r\n");
            WriteLiteral("                                <b>  <h4>");
#nullable restore
#line 80 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                    Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4> </b>
                                <table class=""table table-bordered tblShow"">
                                    <thead>
                                        <tr>                                           
                                            
                                            <th>Date</th>
                                            <th>Amount</th>                                           
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 91 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                         foreach (var item in Model)
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td> ");
#nullable restore
#line 95 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                                Write(item.paydate);

#line default
#line hidden
#nullable disable
            WriteLiteral("     </td>\r\n                                                <td>");
#nullable restore
#line 96 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                               Write(item.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                 \r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 100 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table><br />\r\n");
#nullable restore
#line 103 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                  
                                    var disablePrevious = !Model.IsPreviousAvailable ? "disabled" : "";
                                    var disableNext = !Model.IsNextAvailable ? "disabled" : "";
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da307e87311d651bd01083ab44e10a5071e9b0415071", async() => {
                WriteLiteral("\r\n\r\n\r\n                                    Previous\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                              WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                        WriteLiteral(ViewBag.from1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                      WriteLiteral(ViewBag.to1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-to1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                          WriteLiteral(ViewBag.storeid1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["storeid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-storeid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["storeid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5958, "btn", 5958, 3, true);
            AddHtmlAttributeValue(" ", 5961, "btn-primary", 5962, 12, true);
#nullable restore
#line 114 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
AddHtmlAttributeValue(" ", 5973, disablePrevious, 5974, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da307e87311d651bd01083ab44e10a5071e9b0420647", async() => {
                WriteLiteral("\r\n                                    Next\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                              WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 121 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                        WriteLiteral(ViewBag.from1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 122 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                      WriteLiteral(ViewBag.to1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to1"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-to1", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to1"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 124 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
                                          WriteLiteral(ViewBag.storeid1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["storeid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-storeid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["storeid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6513, "btn", 6513, 3, true);
            AddHtmlAttributeValue(" ", 6516, "btn-primary", 6517, 12, true);
#nullable restore
#line 125 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\pic usercode  25.9.2020\appFoodDelivery\21.10.20\13.11.20\appFoodDelivery\appFoodDelivery\Views\Reportdetails\StorePayment.cshtml"
AddHtmlAttributeValue(" ", 6528, disableNext, 6529, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da307e87311d651bd01083ab44e10a5071e9b0426331", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"<script>
    $(function () {
        //$(""#datepicker1"").datepicker({
        //    autoclose: true,
        //        format: 'dd/mm/yyyy'
        //});
        //$(""#datepicker2"").datepicker({
        //    autoclose: true,
        //    format: 'dd/mm/yyyy'
        //});
        $("".datepicker"").datepicker({
            autoclose: true,
            dateFormat: 'dd/mm/yy'
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<appFoodDelivery.pagination.OrderPagination<StorePaidAmountReportModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591