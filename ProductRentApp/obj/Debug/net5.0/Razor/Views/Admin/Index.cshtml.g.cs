#pragma checksum "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35be0204a215f5b9ccea7dd19cff0cdb4d790b97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\ProductRentApp\Views\_ViewImports.cshtml"
using ProductRentApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\ProductRentApp\Views\_ViewImports.cshtml"
using ProductRentApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35be0204a215f5b9ccea7dd19cff0cdb4d790b97", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55f842e6028b8902cd8f977dcbf501659d5a6ab1", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductRentApp.Models.ListedProductsPending>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35be0204a215f5b9ccea7dd19cff0cdb4d790b973190", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://use.fontawesome.com/releases/v5.0.8/css/all.css\">\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35be0204a215f5b9ccea7dd19cff0cdb4d790b974353", async() => {
                WriteLiteral("\r\n    <ul class=\"nav nav-pills nav-fill\">\r\n        <li class=\"nav-item\">\r\n            <a id=\"step1tab\" class=\"nav-link\" onClick=\"switchPill(1)\"");
                BeginWriteAttribute("href", " href=\"", 528, "\"", 569, 1);
#nullable restore
#line 12 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
WriteAttributeValue("", 535, Url.Action("ADRequests", "Admin"), 535, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">AD Requests</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a id=\"step2tab\" class=\"nav-link\" onClick=\"switchPill(2)\"");
                BeginWriteAttribute("href", " href=\"", 703, "\"", 750, 1);
#nullable restore
#line 15 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
WriteAttributeValue("", 710, Url.Action("UserVerification", "Admin"), 710, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">User Verification</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a id=\"step3tab\" class=\"nav-link\" onClick=\"switchPill(3)\"");
                BeginWriteAttribute("href", " href=\"", 890, "\"", 934, 1);
#nullable restore
#line 18 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
WriteAttributeValue("", 897, Url.Action("ReturnRequest", "Admin"), 897, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Return Requests</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a id=\"step4tab\" class=\"nav-link\" onClick=\"switchPill(4)\"");
                BeginWriteAttribute("href", " href=\"", 1072, "\"", 1113, 1);
#nullable restore
#line 21 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1079, Url.Action("ListedProd", "Admin"), 1079, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Listed Products</a>
        </li>
        <li class=""nav-item dropdown"">
            <a id=""step5tab"" onClick=""switchPill(5)"" class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"" role=""button"" aria-haspopup=""true"" aria-expanded=""false"">My Profile</a>
            <div class=""dropdown-menu"">
                <p class=""dropdown-item"">UserName : ");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
                                               Write(ViewBag.adminid);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />Gmail : ");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
                                                                             Write(ViewBag.adminname);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />City : ");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
                                                                                                            Write(ViewBag.adminloc);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <div class=\"dropdown-divider\"></div>\r\n                <a class=\"dropdown-item\"");
                BeginWriteAttribute("href", " href=\"", 1653, "\"", 1690, 1);
#nullable restore
#line 28 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1660, Url.Action("Login", "LogReg"), 1660, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Logout</a>
            </div>
        </li>
    </ul>
    <br />
    <div class=""row"">
        <div class=""col-6"">
            <div class=""card text-white bg-warning mb-3"" style=""max-width: 18rem;margin-left:100px;"">
                <div class=""card-header text-center font-weight-bold"">AD Requests</div>
                <div class=""card-body text-center"">
                    <h5 class=""card-title"">AD Requests</h5>
                    <h4 class=""card-text"">");
#nullable restore
#line 39 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
                                     Write(ViewBag.pending);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>
                </div>
            </div>
        </div>
        <div class=""col-6"">
            <div class=""card text-white bg-primary mb-3"" style=""max-width: 18rem;margin-left:100px;"">
                <div class=""card-header text-center font-weight-bold"">AD Approved</div>
                <div class=""card-body text-center"">
                    <h5 class=""card-title"">Approved AD's </h5>
                    <h4 class=""card-text"">");
#nullable restore
#line 48 "C:\Users\Admin\source\repos\ProductRentApp\Views\Admin\Index.cshtml"
                                     Write(ViewBag.approved);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"" language=""javascript"">
    function switchPill(a) {
        for (var i = 1; i <= 5; i++) {
            if (i == a) {
                $(""#step"" + a + ""tab"").addClass(""active"");
            }
            else {
                $(""#step"" + i + ""tab"").removeClass(""active"");

            }
        }
    }
</script>");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductRentApp.Models.ListedProductsPending> Html { get; private set; }
    }
}
#pragma warning restore 1591
