#pragma checksum "C:\Users\mlaym\OneDrive\Документы\GitHub\Psychology\Views\LecturerTest\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23ba951978da5cda8bc8f0fada8f8bf45083f1a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LecturerTest_Info), @"mvc.1.0.view", @"/Views/LecturerTest/Info.cshtml")]
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
#line 1 "C:\Users\mlaym\OneDrive\Документы\GitHub\Psychology\Views\_ViewImports.cshtml"
using Psychology;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mlaym\OneDrive\Документы\GitHub\Psychology\Views\_ViewImports.cshtml"
using Psychology.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\mlaym\OneDrive\Документы\GitHub\Psychology\Views\LecturerTest\Info.cshtml"
using Psychology.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ba951978da5cda8bc8f0fada8f8bf45083f1a6", @"/Views/LecturerTest/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"639ce787e3b9395d23e60e3d857c35ac7374684a", @"/Views/_ViewImports.cshtml")]
    public class Views_LecturerTest_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\mlaym\OneDrive\Документы\GitHub\Psychology\Views\LecturerTest\Info.cshtml"
  
    Layout = "_Lecturer";
    ViewData["Title"] = "Шаблоны тестов";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ba951978da5cda8bc8f0fada8f8bf45083f1a64335", async() => {
                WriteLiteral(@"

    <article class=""post"">
        <header>
            <div class=""title"">
                <h2>Шаблон для тестов с ответами в виде шкалы (от 1 до ...)</h2>
            </div>
        </header>

        <p>#название: <i>название теста на этой же строке через пробел (максимум 150 символов)</i></p>

        <p>#описание: <i>описание теста на этой строке через пробел или с новой строки (максимум 400 символов)</i></p>

        <p>#тип: 1</p>

        <p>#размер: <i>количество вопросов в тесте на этой же строке через пробел</i></p>

        <p>#шкала: <i>количество ответов на вопрос на этой же строке через пробел</i></p>

        <p>#перемешивание: <i>+/- на этой же строке через пробел</i></p>

        <p>#инструкция: <i>инструкция к прохождению теста на этой строке через пробел или с новой строки (максимум 500 символов)</i></p>

        <p>#обработка: <i>рекомендации к тесту на этой же строе через пробел или с новой строки (количество символов не ограничено)</i></p>

        <p>
      ");
                WriteLiteral(@"      #тест_начало
            <br />+в: <i>текст вопроса на этой же строке через пробел (максимум 300 символов)</i>
            <br />+в:
            <br />#тест_конец
        </p>
        <p>
            #критерии_начало
            <br />+к: <i>название критерия на этой же строке через пробел (максимум 100 символов)</i>
            <br />-в: <i>1 2 - пример. на этой же строке через пробел</i>
            <br />+к:
            <br />-в:
            <br />#критерии_конец
        </p>

    </article>

    <article class=""post"">
        <header>
            <div class=""title"">
                <h2>Шаблон для тестов с ответами Да/Нет</h2>
            </div>
        </header>

        <p>#название: <i>название теста на этой же строке через пробел (максимум 150 символов)</i></p>

        <p>#описание: <i>описание теста на этой строке через пробел или с новой строки (максимум 400 символов)</i></p>

        <p>#тип: 2</p>

        <p>#размер: <i>количество вопросов в тесте на этой же стр");
                WriteLiteral(@"оке через пробел</i></p>

        <p>#перемешивание: <i>+/- на этой же строке через пробел</i></p>

        <p>#инструкция: <i>инструкция к прохождению теста на этой строке через пробел или с новой строки (максимум 500 символов)</i></p>

        <p>#обработка: <i>рекомендации к тесту на этой же строе через пробел или с новой строки (количество символов не ограничено)</i></p>

        <p>
            #тест_начало
            <br />+в: <i>текст вопроса на этой же строке через пробел (максимум 300 символов)</i>
            <br />+в:
            <br />#тест_конец
        </p>

        <p>
            #критерии_начало
            <br />+к: <i>название критерия на этой же строке через пробел (максимум 100 символов)</i>
            <br />-в: <i>1(2) 2(1) - пример. на этой же строке через пробел, в скобках указывается номер ответа, за который начисляется бал (1 - ДА, 2 - НЕТ)</i>
            <br />+к:
            <br />-в:
            <br />#критерии_конец
        </p>

    </article>

    <");
                WriteLiteral(@"article class=""post"">
        <header>
            <div class=""title"">
                <h2>Стандартный шаблон</h2>
            </div>
        </header>

        <p>#название: <i>название теста на этой же строке через пробел (максимум 150 символов)</i></p>

        <p>#описание: <i>описание теста на этой строке через пробел или с новой строки (максимум 400 символов)</i></p>

        <p>#тип: 3</p>

        <p>#размер: <i>количество вопросов в тесте на этой же строке через пробел</i></p>

        <p>#шкала: <i>количество ответов на вопрос на этой же строке через пробел</i></p>

        <p>#перемешивание: <i>+/- на этой же строке через пробел</i></p>

        <p>#инструкция: <i>инструкция к прохождению теста на этой строке через пробел или с новой строки (максимум 500 символов)</i></p>

        <p>#обработка: <i>рекомендации к тесту на этой же строе через пробел или с новой строки (количество символов не ограничено)</i></p>

        <p>
            #тест_начало
            <br />+в: <i>т");
                WriteLiteral(@"екст вопроса на этой же строке через пробел (максимум 300 символов)</i>
            <br />-о: <i>текст ответа на этой же строке через пробел (максимум 150 символов)</i>
            <br />-о:
            <br />+в:
            <br />-о:
            <br />-о:
            <pbr />#тест_конец
        </p>
        <p>
            #критерии_начало
            <br />+к: <i>название критерия на этой же строке через пробел (максимум 100 символов)</i>
            <br />-в: <i>1(2) 2(1) - пример. на этой же строке через пробел, в скобках указывается номер ответа, за который начисляется бал</i>
            <br />+к
            <br />-в:
            <br />#критерии_конец
        </p>

    </article>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
