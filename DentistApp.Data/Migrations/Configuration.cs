namespace DentistApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using DentistApp.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<DentistAppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DentistAppDbContext context)
        {
        }
    }
}
