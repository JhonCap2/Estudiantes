using System;
using System.Collections.Generic;

namespace Estudiantes.Models
{
    public partial class Calificacione
    {
        public int Id { get; set; }
        public Guid IdCalificaciones { get; set; }
        public string? Calificacion { get; set; }
        public Guid IdMath { get; set; }

        public virtual Materia IdMathNavigation { get; set; } = null!;
    }
}
