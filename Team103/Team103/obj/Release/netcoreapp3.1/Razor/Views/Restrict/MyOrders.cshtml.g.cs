#pragma checksum "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c3bf4764447e6fa44e4ad720053ef429d6b05e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restrict_MyOrders), @"mvc.1.0.view", @"/Views/Restrict/MyOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c3bf4764447e6fa44e4ad720053ef429d6b05e4", @"/Views/Restrict/MyOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"406ab5cd08c27d2abbe801387af5da61dd57cb8e", @"/Views/_ViewImports.cshtml")]
    public class Views_Restrict_MyOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team103.Models.TblOrderLine>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
  
    ViewData["Title"] = "MyOrders";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Orders for ");
#nullable restore
#line 8 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
              Write(Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral(@"    <table class=""table table-sm table-striped table-bordered"">
        <thead>
            <tr>
                <th>
                    Order Date
                </th>
                <th>
                    Product
                </th>
                <th class=""text-right"">
                    Price
                </th>
                <th class=""text-right"">
                    Quanitity
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 28 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 32 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
                    Write($"{item.OrderFkNavigation.OrderDate:d}");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 35 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
                   Write(item.ProductFkNavigation.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-right\">\r\n                        ");
#nullable restore
#line 38 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
                   Write(item.ProductFkNavigation.UnitPrice.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-right\">\r\n                        ");
#nullable restore
#line 41 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
                   Write(item.OrderQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 47 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>No orders for ");
#nullable restore
#line 50 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
                 Write(Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 51 "Z:\public_html\ASPProject\Team103\Team103\Views\Restrict\MyOrders.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team103.Models.TblOrderLine>> Html { get; private set; }
    }
}
#pragma warning restore 1591