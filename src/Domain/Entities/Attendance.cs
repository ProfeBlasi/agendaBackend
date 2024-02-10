namespace Domain.Entidades
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssistanceStatusId { get; set; }
        public virtual Student? Student { get; set; }
        public virtual AssistanceStatus? AssistanceStatus { get; set; }
    }
}