namespace Domain.Entidades
{
    public class EstudiantePeriodo
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int PeriodoId { get; set; }
        public decimal Calificacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
