#pragma checksum "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d77a0fa8f410ff2a97e670fe2d4a4d0d88e19a0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers_Delete), @"mvc.1.0.view", @"/Views/Customers/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customers/Delete.cshtml", typeof(AspNetCore.Views_Customers_Delete))]
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
#line 1 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\_ViewImports.cshtml"
using Lab31_MVC_Core_Entity_Northwind;

#line default
#line hidden
#line 2 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\_ViewImports.cshtml"
using Lab31_MVC_Core_Entity_Northwind.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d77a0fa8f410ff2a97e670fe2d4a4d0d88e19a0f", @"/Views/Customers/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3dfb2da11cfdc63cadb1723cf21df756c3eeb6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Customers_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Lab31_MVC_Core_Entity_Northwind.Models.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(100, 169, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Customer</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(270, 47, false);
#line 15 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(317, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(361, 43, false);
#line 18 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(404, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(448, 47, false);
#line 21 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ContactName));

#line default
#line hidden
            EndContext();
            BeginContext(495, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(539, 43, false);
#line 24 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ContactName));

#line default
#line hidden
            EndContext();
            BeginContext(582, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(626, 48, false);
#line 27 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ContactTitle));

#line default
#line hidden
            EndContext();
            BeginContext(674, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(718, 44, false);
#line 30 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ContactTitle));

#line default
#line hidden
            EndContext();
            BeginContext(762, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(806, 43, false);
#line 33 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(849, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(893, 39, false);
#line 36 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(932, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(976, 40, false);
#line 39 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1016, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1060, 36, false);
#line 42 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1140, 42, false);
#line 45 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Region));

#line default
#line hidden
            EndContext();
            BeginContext(1182, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1226, 38, false);
#line 48 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Region));

#line default
#line hidden
            EndContext();
            BeginContext(1264, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1308, 46, false);
#line 51 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1354, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1398, 42, false);
#line 54 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1440, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1484, 43, false);
#line 57 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1527, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1571, 39, false);
#line 60 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1654, 41, false);
#line 63 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1695, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1739, 37, false);
#line 66 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1776, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1820, 39, false);
#line 69 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Fax));

#line default
#line hidden
            EndContext();
            BeginContext(1859, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1903, 35, false);
#line 72 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Fax));

#line default
#line hidden
            EndContext();
            BeginContext(1938, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1976, 215, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2857f19c28494d78a7fb251a27d5c09b", async() => {
                BeginContext(2002, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2012, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "72e471fe1f8d438799fd1066b21b8bc3", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 77 "C:\Users\Ramone Nelson\Engineering45\Week4\Day4\Lab 1\Lab31_MVC_Core_Entity_Northwind\Views\Customers\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CustomerID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2056, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(2140, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "745290124afc442ba05a671ed44c8e5b", async() => {
                    BeginContext(2162, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2178, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2191, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Lab31_MVC_Core_Entity_Northwind.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591