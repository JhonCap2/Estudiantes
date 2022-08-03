using Estudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudiantes.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EstudianteContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(EstudianteContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }

        public void Add(TEntity Data) => _dbSet.Add(Data);

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int Id) => _dbSet.Find(Id);

        public void Delete(int ID)
        {
            var dataToDelete = _dbSet.Find(ID);
            _dbSet.Remove(dataToDelete);
        }

        public void Save() => _dbContext.SaveChanges();

        public void Update(TEntity Data) => _dbContext.Entry(Data).State = EntityState.Modified;

    }
}
