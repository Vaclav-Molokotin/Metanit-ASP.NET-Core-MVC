using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ViewEngineCreation.Utils
{
    public class CustomView : IView
    {
        public CustomView(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public async Task RenderAsync(ViewContext context)
        {
            string content = "";
            using (StreamReader streamReader = new StreamReader(Path))
            {
                content = await streamReader.ReadToEndAsync();
            }
            await context.Writer.WriteAsync(content);
        }
    }
}
