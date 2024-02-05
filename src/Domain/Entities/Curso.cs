namespace Domain.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public string Seccion { get; set; }
        public string Turno { get; set; }
        public string Escuela { get; set; }
        public virtual ICollection<Recordatorio> Recordatorio { get; set; }
        public virtual ICollection<Estudiante> Estudiante { get; set; }

    }
}
