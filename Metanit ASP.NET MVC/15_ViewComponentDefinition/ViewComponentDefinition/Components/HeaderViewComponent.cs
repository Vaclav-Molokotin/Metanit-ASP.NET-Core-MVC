using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDefinition.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<string> InvokeAsync()
        {
            using (StreamReader reader = new StreamReader("Files/header.txt"))
                return await reader.ReadToEndAsync();
        }
    }
}
