﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace TagHelperCreation
{
	public static class ListHelper
	{
		public static HtmlString CreateList(this IHtmlHelper html, string[] items)
		{
			TagBuilder ul = new TagBuilder("ul");
			foreach (string item in items)
			{
				TagBuilder li = new TagBuilder("li");
				// добавляем текст в li
				li.InnerHtml.Append(item);
				// добавляем li в ul
				ul.InnerHtml.AppendHtml(li);
			}
			ul.Attributes.Add("class", "itemList");
            using var writer = new StringWriter();
			ul.WriteTo(writer, HtmlEncoder.Default);
			return new HtmlString(writer.ToString());
		}
	}
}
