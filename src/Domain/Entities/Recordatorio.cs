﻿namespace Domain.Entidades
{
    public class Recordatorio
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Activo { get; set; }
        public virtual Curso Curso { get; set; }
    }
}