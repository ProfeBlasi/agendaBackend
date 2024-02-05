namespace Domain.Entidades
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int EstadoAsistenciaId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual EstadoAsistencia EstadoAsistencia { get; set; }
    }
}