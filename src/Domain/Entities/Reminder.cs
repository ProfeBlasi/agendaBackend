namespace Domain.Entidades
{
    public class Reminder
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime DateExpiration { get; set; }
        public bool IsActive { get; set; }
        public virtual Course? Course { get; set; }
    }
}