using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ViewEngineCreation.Utils
{
    public class CustomViewEngine : IViewEngine
    {
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            // если передано имя представления - ищем по имени. Иначе ищем по наименованию действия вызывающего метод
            string viewPath = $"Views/{viewName}.cshtml"; ;
            if (string.IsNullOrEmpty(viewName))
            {
                viewPath = $"Views/{context.RouteData.Values["action"]}.cshtml";
            }

            // Если файл представления найден, возвращаем представление
            if (File.Exists(viewPath))
            {
                return ViewEngineResult.Found(viewPath, new CustomView(viewPath));
            }
            // Иначе все грустно
            else
            {
                return ViewEngineResult.NotFound(viewName, new string[] { viewPath });
            }
        }

        public ViewEngineResult GetView(string? executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, new string[] { });
        }
    }
}
