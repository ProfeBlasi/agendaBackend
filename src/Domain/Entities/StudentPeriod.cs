namespace Domain.Entidades
{
    public class StudentPeriod
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PeriodId { get; set; }
        public decimal Qualification { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Period? Period { get; set; }
    }
}
