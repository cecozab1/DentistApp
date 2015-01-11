namespace DentistApp.Data.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public virtual void Delete(object id)
        {
            T entity = this.GetById(id);
            this.Delete(entity);
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
