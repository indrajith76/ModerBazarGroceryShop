#pragma checksum "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "617b5fe6ec23118f6d09acbf216482c3dab99690"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetAllUsers), @"mvc.1.0.view", @"/Views/User/GetAllUsers.cshtml")]
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
#line 1 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\_ViewImports.cshtml"
using ModerBazarGroceryShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\_ViewImports.cshtml"
using ModerBazarGroceryShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"617b5fe6ec23118f6d09acbf216482c3dab99690", @"/Views/User/GetAllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3bdf507da3bd3985d7eadc040fd757bf93e12f2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetAllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
  
    ViewData["Title"] = "GetAllUsers";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""py-5 bg-light"">
    <div class=""container"">
        <h3 class=""display-4"">GetAllCategories</h3>
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">Id</th>
                    <th scope=""col"">User Name</th>
                    <th scope=""col"">Location</th>
                    <th scope=""col"">Phone No</th>
                    <th scope=""col"">Password</th>
                    <th scope=""col"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 21 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 24 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                               Write(item.UserID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 25 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                   Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                   Write(item.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                   Write(item.PhoneNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                   Write(item.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a href=\"#\" class=\"btn btn-warning\">Edit</a>\r\n                        <a href=\"#\" class=\"btn btn-danger\">Delete</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 34 "D:\Alchemy Softwere\C#\ModerBazarGroceryShop\ModerBazarGroceryShop\Views\User\GetAllUsers.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
