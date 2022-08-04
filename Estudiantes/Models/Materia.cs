using System;
using System.Collections.Generic;

namespace Estudiantes.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int Id { get; set; }
        public Guid IdMath { get; set; }
        public string? Materia1 { get; set; }
        public Guid IdCuatrimestre { get; set; }

        public virtual Cuatrimestre IdCuatrimestreNavigation { get; set; } = null!;
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
