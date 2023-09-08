using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BindModel.Infrastructure
{
    public class CustomDateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;   // "Запасной" привязчик, вызываемый в случае если
                                                        // с помощью провайдера значений не были найдены значения с ключами Date и Time

        public CustomDateTimeModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // с помощью поставщика значений получаем данные из запроса
            var datePartValues = bindingContext.ValueProvider.GetValue("Date");
            var timePartValues = bindingContext.ValueProvider.GetValue("Time");

            // если не найдено значений с данными ключами, вызываем привязчик модели по умолчанию
            if(datePartValues == ValueProviderResult.None || timePartValues == ValueProviderResult.None)
            {
                return fallbackBinder.BindModelAsync(bindingContext);
            }

            // получаем значения
            string? date = datePartValues.FirstValue;
            string? time = timePartValues.FirstValue;

            // Парсим дату и время
            DateTime.TryParse(date, out DateTime parsedDateValue);
            DateTime.TryParse(time, out DateTime parsedTimeValue);

            // Объединяем полученные значения в один объект DateTime
            var result = new DateTime(parsedDateValue.Year,
                            parsedDateValue.Month,
                            parsedDateValue.Day,
                            parsedTimeValue.Hour,
                            parsedTimeValue.Minute,
                            parsedTimeValue.Second);

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;


        }
    }
}
