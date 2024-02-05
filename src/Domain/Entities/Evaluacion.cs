namespace Domain.Entidades
{
    public class Evaluacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ICollection<EstudianteEvaluacion> EstudianteEvaluacion { get; set; }
    }
}
