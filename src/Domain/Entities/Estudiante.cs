namespace Domain.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string ApellidoNombres { get; set; }
        public string Apodo { get; set; }
        public string Telefono { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public decimal Promedio { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<EstudianteEvaluacion> AlumnoEvaluacion { get; set; }
        public virtual ICollection<EstudiantePeriodo> AlumnoPeriodo { get; set; }
        public virtual ICollection<EstudianteObservaciones> AlumnoObservaciones { get; set; }
    }
}
