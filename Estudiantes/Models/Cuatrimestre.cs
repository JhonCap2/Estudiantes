using System;
using System.Collections.Generic;

namespace Estudiantes.Models
{
    public partial class Cuatrimestre
    {
        public Cuatrimestre()
        {
            Materia = new HashSet<Materia>();
        }

        public int Id { get; set; }
        public Guid IdStudent { get; set; }
        public Guid IdCuatrimestre { get; set; }
        public decimal? Numero { get; set; }

        public virtual Estudiante IdStudentNavigation { get; set; } = null!;
        public virtual ICollection<Materia> Materia { get; set; }
    }
}
