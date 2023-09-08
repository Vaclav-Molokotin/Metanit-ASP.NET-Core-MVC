namespace DataTransmissionIntoViewComponent.Components
{
    public class TimerViewComponent
    {
        public string Invoke(bool includeSeconds, bool format24)
        {
            string format;
            format = format24 ? "HH":"hh";
            format = $"{format}:mm";
            format += includeSeconds ? ":ss" : ""; 

            return DateTime.Now.ToString(format);
        }
    }
}
