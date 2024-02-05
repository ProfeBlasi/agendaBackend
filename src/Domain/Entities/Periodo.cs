namespace Domain.Entidades
{
    public class Periodo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fechas { get; set; }
        public virtual ICollection<EstudiantePeriodo> AlumnoPeriodo { get; set; }
    }
}
