namespace Domain.Entidades
{
    public class EstudianteObservaciones
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int ObservacionesId { get; set; }
        public string Observacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Observaciones Observaciones { get; set; }
    }
}
