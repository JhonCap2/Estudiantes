namespace Estudiantes.Models
{
    public partial class Cuatrimestre
    {
        public Cuatrimestre()
        {
            Materias = new HashSet<Materia>();
        }

        public int Id { get; set; }
        public Guid IdStudent { get; set; }
        public Guid? IdCuatrimestre { get; set; }
        public string? Numero { get; set; }

        public virtual Estudiante? IdStudentNavigation { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }

        
    }
}

