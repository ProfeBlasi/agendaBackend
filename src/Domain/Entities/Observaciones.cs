namespace Domain.Entidades
{
    public class Observaciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fechas { get; set; }
        public virtual ICollection<EstudianteObservaciones> AlumnoObservaciones { get; set; }
    }
}
