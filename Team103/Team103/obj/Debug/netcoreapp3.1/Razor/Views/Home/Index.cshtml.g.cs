#pragma checksum "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76c39f73fc25e3fa1f5344d14abc34fd17b4aaee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "Z:\public_html\ASPProject\Team103\Team103\Views\_ViewImports.cshtml"
using Team103;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\public_html\ASPProject\Team103\Team103\Views\_ViewImports.cshtml"
using Team103.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76c39f73fc25e3fa1f5344d14abc34fd17b4aaee", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"406ab5cd08c27d2abbe801387af5da61dd57cb8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team103.Models.TblCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("index-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
 if (Context.User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Hello, and welcome back ");
#nullable restore
#line 10 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
                                                 Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n    </div>\r\n");
#nullable restore
#line 12 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Hello, and welcome to the online cloth shopping website!</h1>\r\n    </div>\r\n");
#nullable restore
#line 18 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section>
    <p style=""text-align:justify;"">Here you can buy various cloth products, such as T-Shirts, Shirts, Jackets, of various well known brands. Customer has to just register on this website and then he or she can buy various cloth products online. You need not to go to shopping mall.</p>
    <br />
    <p style=""text-align:justify;"">We provide best quality cloth material. If you have any complain regarding dispatched order feel free to send us feedback. So we can improve our services.</p>
    <br />
    <p style=""text-align:justify;""><strong>We hope you enjoy your visit. Have fun!</strong></p>
</section>
<hr />
<table>
");
#nullable restore
#line 29 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
     foreach (var category in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1160, "\"", 1221, 3);
#nullable restore
#line 33 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
WriteAttributeValue("", 1167, Url.Action("Product", "Shop"), 1167, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1197, "?id=", 1197, 4, true);
#nullable restore
#line 33 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
WriteAttributeValue("", 1201, category.CategoryPk, 1201, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "76c39f73fc25e3fa1f5344d14abc34fd17b4aaee6335", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1255, "~/Images/", 1255, 9, true);
#nullable restore
#line 34 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 1264, category.ImageFile, 1264, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </a>\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 39 "Z:\public_html\ASPProject\Team103\Team103\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team103.Models.TblCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591