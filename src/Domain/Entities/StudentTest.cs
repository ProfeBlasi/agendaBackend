namespace Domain.Entidades
{
    public class StudentTest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TestId { get; set; }
        public decimal Qualification { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Test? Test { get; set; }
    }
}
