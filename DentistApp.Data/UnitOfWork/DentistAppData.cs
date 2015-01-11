namespace DentistApp.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;

    using DentistApp.Data.Models;
    using DentistApp.Data.Repository;

    public class DentistAppData : IDentistAppData
    {
        private IDictionary<Type, object> repositories;

        public DentistAppData(IDentistAppDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDentistAppDbContext Context { get; set; }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                return this.GetRepository<Patient>();
            }
        }

        public IRepository<Medical> Medicals
        {
            get
            {
                return this.GetRepository<Medical>();
            }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
