#pragma checksum "D:\Task4\ConsoleApp.Web\Views\Tasks\Task1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "332fd415e0247062c17bd5765a5721e4ff8cc73b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tasks_Task1), @"mvc.1.0.view", @"/Views/Tasks/Task1.cshtml")]
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
#line 1 "D:\Task4\ConsoleApp.Web\Views\_ViewImports.cshtml"
using ConsoleApp.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Task4\ConsoleApp.Web\Views\_ViewImports.cshtml"
using ConsoleApp.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"332fd415e0247062c17bd5765a5721e4ff8cc73b", @"/Views/Tasks/Task1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6811fe6ca13940cc3a48d5ec39fb6b2ee3d832f3", @"/Views/_ViewImports.cshtml")]
    public class Views_Tasks_Task1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Task4\ConsoleApp.Web\Views\Tasks\Task1.cshtml"
      
    ViewData["Title"] = "Задание 1";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Задание 1. Рассчитать данные о площадях и объемах каждого помещения.</h2><p></p>\r\n    <table class=\"table\">\r\n        <tbody>\r\n\r\n");
#nullable restore
#line 10 "D:\Task4\ConsoleApp.Web\Views\Tasks\Task1.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 13 "D:\Task4\ConsoleApp.Web\Views\Tasks\Task1.cshtml"
               Write(Html.DisplayFor(modelItem => item));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 15 "D:\Task4\ConsoleApp.Web\Views\Tasks\Task1.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
