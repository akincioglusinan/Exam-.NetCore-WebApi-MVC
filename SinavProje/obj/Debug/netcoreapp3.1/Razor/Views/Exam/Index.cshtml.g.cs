#pragma checksum "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f75e1b73fa98d5ef0763b355a19c5434a487ca92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Exam_Index), @"mvc.1.0.view", @"/Views/Exam/Index.cshtml")]
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
#line 1 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\_ViewImports.cshtml"
using SinavProje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\_ViewImports.cshtml"
using SinavProje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f75e1b73fa98d5ef0763b355a19c5434a487ca92", @"/Views/Exam/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3365ec7359c51c81a6b7e733c7ba8888860ee6f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Exam_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SinavProje.Core.Utilities.Results.IDataResult<List<SinavProje.Entities.Concrete.Entities.Exam>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
  
    ViewData["Title"] = "Exams";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Exams</h1>\r\n<div class=\"container\">\r\n    <div class=\"row justify-content-md-center\">\r\n        <div class=\"col\" >\r\n");
#nullable restore
#line 11 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
              
                if (Model.Success)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th scope=""col"">#</th>
                                <th scope=""col"">Title</th>
                                <th scope=""col"">Date</th>
                                <th scope=""col"">Delete</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 24 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                              
                                int i = 1;
                                foreach (var exam in Model.Data)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th scope=\"row\">");
#nullable restore
#line 29 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 1174, "\"", 1239, 4);
            WriteAttributeValue("", 1181, "/", 1181, 1, true);
#nullable restore
#line 30 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
WriteAttributeValue("", 1182, exam.Id, 1182, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1190, "/", 1190, 1, true);
#nullable restore
#line 30 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
WriteAttributeValue("", 1191, exam.Title.Replace(" ","-").Replace(".", "dot"), 1191, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 30 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                                                                                                            Write(exam.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                        <td>");
#nullable restore
#line 31 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                                       Write(exam.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 1374, "\"", 1401, 2);
            WriteAttributeValue("", 1381, "/removeexam/", 1381, 12, true);
#nullable restore
#line 32 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
WriteAttributeValue("", 1393, exam.Id, 1393, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\"> X </a></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 34 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                                    i++;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 39 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h2>");
#nullable restore
#line 42 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                       Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 43 "C:\Users\sinan\source\repos\SinavProje\SinavProje\Views\Exam\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SinavProje.Core.Utilities.Results.IDataResult<List<SinavProje.Entities.Concrete.Entities.Exam>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
