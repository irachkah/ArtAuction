#pragma checksum "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e0c012c7ac5d319cb66263ad7ac0e0fedd09b7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collectors_CollectorView), @"mvc.1.0.view", @"/Views/Collectors/CollectorView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Collectors/CollectorView.cshtml", typeof(AspNetCore.Views_Collectors_CollectorView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e0c012c7ac5d319cb66263ad7ac0e0fedd09b7f", @"/Views/Collectors/CollectorView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Collectors_CollectorView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArtAuction.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Collectors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCollector", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Painting"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Artists", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ArtistView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
  
    ViewData["Title"] = "Delete Collector";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(108, 61, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h3 class=\"mt-3 text-center\"> ");
            EndContext();
            BeginContext(170, 15, false);
#line 8 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                             Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(185, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(188, 14, false);
#line 8 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                               Write(Model.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(202, 35, true);
            WriteLiteral("</h3>\r\n    <p class=\"text-center\"> ");
            EndContext();
            BeginContext(238, 11, false);
#line 9 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                       Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(249, 34, true);
            WriteLiteral("</p>\r\n    <p class=\"text-center\"> ");
            EndContext();
            BeginContext(284, 10, false);
#line 10 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                       Write(Model.City);

#line default
#line hidden
            EndContext();
            BeginContext(294, 3, true);
            WriteLiteral(" , ");
            EndContext();
            BeginContext(298, 13, false);
#line 10 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                     Write(Model.Country);

#line default
#line hidden
            EndContext();
            BeginContext(311, 41, true);
            WriteLiteral(" </p>\r\n    <p class=\"text-center\"> Role: ");
            EndContext();
            BeginContext(353, 10, false);
#line 11 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                             Write(Model.Role);

#line default
#line hidden
            EndContext();
            BeginContext(363, 63, true);
            WriteLiteral("  </p>\r\n    <p class=\"text-center\"> Is gallery representative: ");
            EndContext();
            BeginContext(427, 22, false);
#line 12 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                  Write(Model.IsRepresentative);

#line default
#line hidden
            EndContext();
            BeginContext(449, 7, true);
            WriteLiteral(" </p>\r\n");
            EndContext();
#line 13 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
     if (Model.IsRepresentative)
    {

#line default
#line hidden
            BeginContext(497, 47, true);
            WriteLiteral("        <p class=\"text-center\"> Place of work: ");
            EndContext();
            BeginContext(545, 13, false);
#line 15 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                          Write(Model.Gallery);

#line default
#line hidden
            EndContext();
            BeginContext(558, 7, true);
            WriteLiteral(" </p>\r\n");
            EndContext();
#line 16 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
    }

#line default
#line hidden
            BeginContext(572, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 17 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
     if (User.IsInRole("Administrator"))
    {

#line default
#line hidden
            BeginContext(621, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(629, 216, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e0c012c7ac5d319cb66263ad7ac0e0fedd09b7f9605", async() => {
                BeginContext(731, 107, true);
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger btn-block btn-lg mb-3\" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 19 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                                         WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(845, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
    }

#line default
#line hidden
            BeginContext(854, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 24 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
     if (!Model.IsRepresentative)
    {

#line default
#line hidden
            BeginContext(904, 117, true);
            WriteLiteral("        <div class=\"album py-5 bg-light\">\r\n            <div class=\"container\">\r\n\r\n                <div class=\"row\">\r\n");
            EndContext();
#line 30 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                     foreach (var painting in Model.Paintings)
                    {

#line default
#line hidden
            BeginContext(1108, 144, true);
            WriteLiteral("                        <div class=\"col-md-4\">\r\n                            <div class=\"card mb-4 box-shadow\">\r\n                                ");
            EndContext();
            BeginContext(1252, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9e0c012c7ac5d319cb66263ad7ac0e0fedd09b7f13809", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1283, "~/content/paintings/", 1283, 20, true);
#line 34 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
AddHtmlAttributeValue("", 1303, painting.ImgId, 1303, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1335, 117, true);
            WriteLiteral("\r\n                                <div class=\"card-body\">\r\n                                    <h4 class=\"card-text\">");
            EndContext();
            BeginContext(1453, 14, false);
#line 36 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                     Write(painting.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1467, 110, true);
            WriteLiteral("</h4>\r\n                                    <p class=\"card-text\"><span class=\"font-weight-bold\">Artist:</span> ");
            EndContext();
            BeginContext(1577, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e0c012c7ac5d319cb66263ad7ac0e0fedd09b7f16165", async() => {
                BeginContext(1663, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1665, 15, false);
#line 37 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                                                                                                                                                         Write(painting.Artist);

#line default
#line hidden
                EndContext();
                BeginContext(1680, 1, true);
                WriteLiteral(" ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                                                                                                                             WriteLiteral(painting.ArtistId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1685, 109, true);
            WriteLiteral("</p>\r\n                                    <p class=\"card-text\"><span class=\"font-weight-bold\"> Style:</span> ");
            EndContext();
            BeginContext(1795, 14, false);
#line 38 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                                                                                                  Write(painting.Style);

#line default
#line hidden
            EndContext();
            BeginContext(1809, 114, true);
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 42 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
                    }

#line default
#line hidden
            BeginContext(1946, 60, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 46 "E:\Projects VS\GraceArtAuction\Views\Collectors\CollectorView.cshtml"
    }

#line default
#line hidden
            BeginContext(2013, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArtAuction.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
