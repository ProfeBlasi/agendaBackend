namespace Domain.Entidades
{
    public class EstudianteEvaluacion
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
        public decimal Calificacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Evaluacion Evaluacion { get; set; }
    }
}
