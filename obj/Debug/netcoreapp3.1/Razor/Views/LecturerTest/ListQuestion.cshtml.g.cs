#pragma checksum "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3376282251ffc47d43f7517b3f0014d1b8187deb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LecturerTest_ListQuestion), @"mvc.1.0.view", @"/Views/LecturerTest/ListQuestion.cshtml")]
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
#line 1 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\_ViewImports.cshtml"
using Psychology;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\_ViewImports.cshtml"
using Psychology.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
using Psychology.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3376282251ffc47d43f7517b3f0014d1b8187deb", @"/Views/LecturerTest/ListQuestion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02304d9e0099c1bb265af37444505ad201ed7f55", @"/Views/_ViewImports.cshtml")]
    public class Views_LecturerTest_ListQuestion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LecturerUpdateQuestionViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateQuestion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
  
    Layout = "_Lecturer";
    ViewData["Title"] = "Список вопросов";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<article class=""post"">
    <header>
        <div class=""title"">
            <h2>Список вопросов</h2>
        </div>
    </header>
    <table style=""margin-top: 20px; margin-bottom: -2px"">
        <tr><th style=""width:5%"">№</th><th>Текст вопроса</th></tr>
    </table>
    <div class=""table-wrapper"" style=""overflow-x: auto; max-height: 500px; "">
        <table>
            <tr style=""display:none"">

            </tr>
");
#nullable restore
#line 22 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
              
                int i = 1;
                foreach (var Question in Model.ListQuestion)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td style=\"width:5%\">\r\n                            ");
#nullable restore
#line 28 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3376282251ffc47d43f7517b3f0014d1b8187deb5130", async() => {
#nullable restore
#line 31 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
                                                                                                                           Write(Question.Text);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-TestId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
                                                                 WriteLiteral(Model.TestId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["TestId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-TestId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["TestId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
                                                                                                      WriteLiteral(Question.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuestionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-QuestionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["QuestionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "C:\Users\mlaym\OneDrive\Рабочий стол\Psychology\Views\LecturerTest\ListQuestion.cshtml"
                    i++;
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</article>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LecturerUpdateQuestionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
