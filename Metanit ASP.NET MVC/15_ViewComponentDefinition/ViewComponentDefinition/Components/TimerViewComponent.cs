using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDefinition.Components
{
    // Разные способы определения класса ViewComponent
    [ViewComponent]
    public class TimerViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        }

        
    }
}
