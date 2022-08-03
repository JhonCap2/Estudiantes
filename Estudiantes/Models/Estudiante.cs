using System;
using System.Collections.Generic;

namespace Estudiantes.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Cuatrimestres = new HashSet<Cuatrimestre>();
        }

        public int Id { get; set; }
        public Guid IdStudent { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Carrera { get; set; }

        public virtual ICollection<Cuatrimestre> Cuatrimestres { get; set; }
    }
}
