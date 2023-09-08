using DataTransmissionIntoViewComponent.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace DataTransmissionIntoViewComponent.Components
{
    public class PersonInfoViewComponent
    {
        public HtmlString Invoke(List<Person> persons)
        {
            TagBuilder ul = new TagBuilder("ul");
            for (int i = 0; i < persons.Count; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append($"Пользватель {i+1}\n ID: {persons[i].Id}\tИмя: {persons[i].Name}\tВозраст: {persons[i].Age}\n\n\n");
                ul.InnerHtml.AppendHtml(li);
            }
            StringWriter textWriter = new StringWriter();
            ul.WriteTo(textWriter, HtmlEncoder.Default);
            return new HtmlString(textWriter.ToString());
        }
    }
}
