namespace DentistApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using DentistApp.Data.Models;
    using DentistApp.Data.Migrations;

    public class DentistAppDbContext : IdentityDbContext<User>, IDentistAppDbContext
    {
        public DentistAppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<DentistAppDbContext>(new MigrateDatabaseToLatestVersion<DentistAppDbContext, Configuration>());
        }

        public static DentistAppDbContext Create()
        {
            return new DentistAppDbContext();
        }

        public IDbSet<Patient> Patients { get; set; }

        public IDbSet<Medical> Medicals { get; set; }

        public new DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
