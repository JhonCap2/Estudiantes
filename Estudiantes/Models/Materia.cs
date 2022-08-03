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
        public Guid? IdCuatrimestre { get; set; }
        public Guid IdMath { get; set; }
        public string? Nombre { get; set; }

        public virtual Calificacione? IdCalificacionesNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
