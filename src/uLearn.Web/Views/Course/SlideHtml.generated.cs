﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uLearn.Web.Views.Course
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using uLearn;
    using uLearn.Model.Blocks;
    using uLearn.Web.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class SlideHtml
    {

public static System.Web.WebPages.HelperResult Slide(BlockRenderContext context, int currentScore = 0)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\'slide\'>\r\n\t\t<h1>\r\n\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, context.Slide.Title);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t\t<span class=\"score\">");


WebViewPage.WriteTo(@__razor_helper_writer, Score(currentScore, context.Slide.MaxScore));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</span>\r\n\t\t</h1>\r\n\r\n");


 		foreach (var block in context.Slide.Blocks)
		{
			
WebViewPage.WriteTo(@__razor_helper_writer, Block((dynamic)block, context));

                                  
		}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult Score(int currentScore, int maxScore)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


  
WebViewPage.WriteTo(@__razor_helper_writer, maxScore == 0 ? "" : string.Format("{0}/{1}", currentScore, maxScore));

                                                                           
});

                                                                           }


public static System.Web.WebPages.HelperResult Block(MdBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


  
WebViewPage.WriteTo(@__razor_helper_writer, MvcHtmlString.Create(block.Markdown.RenderMd(context.BaseUrl)));

                                                                  
});

                                                                  }


public static System.Web.WebPages.HelperResult Block(CodeBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea class=\'code code-sample\' data-lang=\"");


    WebViewPage.WriteTo(@__razor_helper_writer, block.LangId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-ver=\"");


                             WebViewPage.WriteTo(@__razor_helper_writer, block.LangVer);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");


                                             WebViewPage.WriteTo(@__razor_helper_writer, block.Code);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



});

}


public static System.Web.WebPages.HelperResult Block(TexBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	foreach (var texLine in block.TexLines)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"tex\">\\displaystyle ");


WebViewPage.WriteTo(@__razor_helper_writer, texLine.Trim());

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n");


	}

});

}


public static System.Web.WebPages.HelperResult Block(YoutubeBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"video-container\">\r\n\t\t<iframe class=\'embedded-video\' width=\'864\' heig" +
"ht=\'480\' src=\'https://www.youtube.com/embed/");


                                                  WebViewPage.WriteTo(@__razor_helper_writer, block.VideoId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\' allowfullscreen></iframe>\r\n\t</div>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"	<div>
		<a href=""javascript://"" class=""popover-trigger""
			title=""Как ускорить видео?""
			data-content=""Если по иконке с шестеренкой нет возможности ускорить видео, то вам нужно &lt;a target='blank' href='http://youtube.com/html5'>вручную включить&lt;/a> использование HTML5-плеера."">Как ускорить видео?</a>
	</div>
");



});

}


public static System.Web.WebPages.HelperResult Block(ImageGaleryBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"flexslider\">\r\n\t\t<ul class=\"slides\">\r\n");


 			foreach (var imageUrl in block.ImageUrls)
			{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<li>\r\n\t\t\t\t\t<img src=\"");


WebViewPage.WriteTo(@__razor_helper_writer, string.Format("{0}/{1}", context.BaseUrl, imageUrl));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" alt=\"");


                               WebViewPage.WriteTo(@__razor_helper_writer, imageUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" />\r\n\t\t\t\t</li>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t</ul>\r\n\t</div>\r\n");



});

}


public static System.Web.WebPages.HelperResult Block(ExerciseBlock block, BlockRenderContext context)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 
	ExerciseBlockData data = context.GetBlockData(block) ?? new ExerciseBlockData();
	var action = data.CanSkip ? "$('#ShowSolutionsAlert').modal('show')" : string.Format("window.location='{0}'", data.AcceptedSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea id=\"secretCodeExercise\" class=\'hide\'>");


     WebViewPage.WriteTo(@__razor_helper_writer, block.ExerciseInitialCode.EnsureEnoughLines(4));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<div class=\"sphere-engine-tm\">Powered by <a target=\"blank\" href=\"http://sphere-e" +
"ngine.com\">Sphere Engine™</a> and <a target=\"blank\" href=\"http://codemirror.net/" +
"\">CodeMirror</a></div>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<textarea class=\'code code-exercise\' data-lang=\"");


      WebViewPage.WriteTo(@__razor_helper_writer, block.LangId);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");


                      WebViewPage.WriteTo(@__razor_helper_writer, data.LatestAcceptedSolution ?? block.ExerciseInitialCode.EnsureEnoughLines(4));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</textarea>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t<script>\r\n\t\tfunction cleanUserCode() {\r\n\t\t\tvar $secretCodeExercise = $(\'#secretC" +
"odeExercise\');\r\n\t\t\t$(\'.code-exercise\')[0].codeMirrorEditor.setValue($secretCodeE" +
"xercise.text());\r\n\t\t}\r\n\t</script>\r\n");


	if (data.ShowControls)
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"solution-control btn-group ctrl-group\">\r\n\t\t\t<button type=\"button\" c" +
"lass=\"run-solution-button btn btn-primary no-rounds ");


                                    WebViewPage.WriteTo(@__razor_helper_writer, data.IsLti ? "run-solution-button-lti" : "");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" data-url=\"");


                                                                                             WebViewPage.WriteTo(@__razor_helper_writer, data.RunSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\tRun\r\n\t\t\t</button>\r\n\r\n");


  			 var e = ((ExerciseSlide)context.Slide).Exercise.HintsMd; 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t<button id=\"GetHintButton\" type=\"button\" class=\"btn btn-default hints-btn\" onc" +
"lick=\" showHintForUser(\'");


                                                              WebViewPage.WriteTo(@__razor_helper_writer, context.Course.Id);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\', \'");


                                                                                    WebViewPage.WriteTo(@__razor_helper_writer, context.Slide.Index);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\', \'");


                                                                                                            WebViewPage.WriteTo(@__razor_helper_writer, e.Count);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\') \" data-url=\"");


                                                                                                                                   WebViewPage.WriteTo(@__razor_helper_writer, data.GetHintUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\tGet hint\r\n\t\t\t</button>\r\n");


 			if (!data.IsLti)
			{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t<button type=\"button\" class=\"btn btn-default giveup-btn\" onclick=\"");


                           WebViewPage.WriteTo(@__razor_helper_writer, action);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\t\t\t\t\tShow solutions\r\n\t\t\t\t</button>\r\n");


			}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t<button type=\"button\" class=\"btn btn-default reset-btn no-rounds\" onclick=\" cl" +
"eanUserCode() \">\r\n\t\t\t\tReset\r\n\t\t\t</button>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"run-result run-service-error\">\r\n\t\t\t<div class=\"run-verdict label-wa" +
"rning\">Ошибка сервера :(</div>\r\n\t\t\t<pre class=\"no-rounds\"><code class=\"run-detai" +
"ls\"></code></pre>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"run-result run-compile-error\">\r\n\t\t\t<div class=\"run-verdict label-da" +
"nger\">Ошибка компиляции</div>\r\n\t\t\t<pre class=\"no-rounds\"><code class=\"run-detail" +
"s\"></code></pre>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"		<div class=""run-result run-style-error"">
			<div class=""run-verdict label-danger"">Нарушение стилевых требований</div>
			<pre class=""no-rounds""><code class=""run-details""></code></pre>
			<div>
				<small>В некоторых ситуациях стилевые проверки тут могут быть жестче, чем необходимо в реальной жизни.</small>
			</div>
		</div>
");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"run-result run-wa\">\r\n\t\t\t<div class=\"run-verdict label-danger\">Невер" +
"ный результат</div>\r\n\t\t\t<div class=\"diff-table tablesorter\"></div>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"run-result run-wa-no-diff\">\r\n\t\t\t<div class=\"run-verdict label-dange" +
"r\">Неверный результат</div>\r\n\t\t\t<pre class=\"no-rounds\"><code class=\"run-details\"" +
"></code></pre>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"run-result run-success\">\r\n\t\t\t<div class=\"run-verdict label-success " +
"clearfix\">Успех!</div>\r\n\t\t\t<pre class=\"no-rounds\"><code class=\"run-details\"></co" +
"de></pre>\r\n\t\t</div>\r\n");




WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div class=\"panel-group ctrl-group\" id=\"hints-accordion\">\r\n\t\t\t<div id=\"hints-pl" +
"ace\"></div>\r\n\t\t</div>\r\n");


		if (!data.IsLti)
		{
			
WebViewPage.WriteTo(@__razor_helper_writer, Alert(data));

               
		}
	}
	else
	{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t<div>\r\n\t\t\t<h3>Подсказки</h3>\r\n\t\t\t<ol>\r\n");


 				foreach (var hint in block.HintsMd)
				{

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t\t\t<li>\r\n\t\t\t\t\t\t");


WebViewPage.WriteTo(@__razor_helper_writer, MvcHtmlString.Create(hint.RenderMd(context.BaseUrl)));

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\t\t\t\t\t</li>\r\n");


				}

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\t\t\t</ol>\r\n\t\t</div>\r\n");


	}

});

}


public static System.Web.WebPages.HelperResult Alert(ExerciseBlockData data)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {


 

WebViewPage.WriteLiteralTo(@__razor_helper_writer, @"	<div class=""modal fade"" id=""ShowSolutionsAlert"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
		<div class=""modal-dialog"">
			<div class=""modal-content"">
				<div class=""modal-header"">
					<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
					<h4 class=""modal-title"">Внимание</h4>
				</div>
				<div class=""modal-body"">
					<p>Вы потеряете возможность получить баллы за эту задачу, если продолжите.</p>
				</div>
				<div class=""modal-footer"">
					<a class=""btn btn-default"" href=""");


WebViewPage.WriteTo(@__razor_helper_writer, data.AcceptedSolutionUrl);

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">Продолжить</a>\r\n\t\t\t\t\t<button type=\"button\" class=\"btn btn-primary\" data-dismiss" +
"=\"modal\">Отмена</button>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n");



});

}


    }
}
#pragma warning restore 1591
