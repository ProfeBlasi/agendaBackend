namespace Domain.Entidades
{
    public class Course
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Section { get; set; } = string.Empty;
        public string Shift { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
    }
}
