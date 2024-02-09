namespace Domain.Entidades
{
    public class DiaNoLaborable
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
