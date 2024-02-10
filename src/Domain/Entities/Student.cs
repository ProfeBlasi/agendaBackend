using Domain.Entities;

namespace Domain.Entidades
{
    public class Student
    {
        public int Id { get; set; }
        public string LastNameFirstName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; 
        public decimal Average { get; set; } 
        public virtual ICollection<Attendance>? Attendance { get; set; }
        public virtual ICollection<StudentTest>? StudentTest { get; set; }
        public virtual ICollection<StudentPeriod>? StudentPeriod { get; set; }
        public virtual ICollection<StudentObservation>? StudentObservation { get; set; }
        public virtual ICollection<StudentCourse>? StudentCourse { get; set; }
    }
}
