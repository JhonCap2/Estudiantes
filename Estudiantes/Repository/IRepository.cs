namespace Estudiantes.Repository
{
    internal interface IRepository<TEntity>
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(int Id);
        public void Add(TEntity Data);
        public void Update(TEntity Data);
        public void Delete(int Id);
        public void Save();
    }
}
