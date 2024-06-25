namespace KolokwiumDF.DTOs
{
    public class VisitDto
    {
        public int IdVisit { get; set; }
        public string Doctor { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
    }
}