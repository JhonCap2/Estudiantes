using System;
using System.Collections.Generic;

namespace Estudiantes.Models
{
    public partial class Calificacione
    {
        public int Id { get; set; }
        public Guid? IdMath { get; set; }
        public Guid IdCal { get; set; }
        public decimal? Calificacion { get; set; }

        public virtual Materia? IdMathNavigation { get; set; }
    }
}
