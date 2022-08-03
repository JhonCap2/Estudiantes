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
        public Guid? IdStudent { get; set; }
        public Guid IdMath { get; set; }
        public string? Nombre { get; set; }

        public virtual Estudiante? IdStudentNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
