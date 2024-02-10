namespace Domain.Entidades
{
    public class StudentObservation
    {
        public int Id { get; set; }
        public int StudenteId { get; set; }
        public int ObservationssId { get; set; }
        public string Observation { get; set; } = string.Empty;
        public virtual Student? Student { get; set; }
        public virtual Observations? Observations { get; set; }
    }
}
