namespace KolokwiumDF.DTOs
{
    public class PatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string TotalAmountMoneySpent { get; set; }
        public int NumberOfVisits { get; set; }
        public List<VisitDto> Visits { get; set; }
    }
}