namespace Domain.Entidades
{
    public class EstadoAsistencia
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
    }
}
