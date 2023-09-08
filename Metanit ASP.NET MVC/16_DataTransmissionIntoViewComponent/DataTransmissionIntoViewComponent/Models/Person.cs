namespace DataTransmissionIntoViewComponent.Models
{
    public record class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                int years = BirthDate.Year;
                int months = BirthDate.Month;
                int days = BirthDate.Day;

                DateTime result = DateTime.Now;

                result = result.AddYears(-years);
                result = result.AddMonths(-months);
                result = result.AddDays(-days);

                return result.Year;
            }
        }
    }
}
