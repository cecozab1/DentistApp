namespace DentistApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    using DentistApp.Data;
    using DentistApp.Data.Common;
    using DentistApp.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DentistAppDbContext>
    {
        private UserStore<User> UserStore { get; set; }
        private UserManager<User> UserManager { get; set; }

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DentistAppDbContext context)
        {
            this.UserStore = new UserStore<User>(context);
            this.UserManager = new UserManager<User>(this.UserStore);
            RandomGenerator.RandomStringWithSpaces(3, 30);

            SeedUsers(context);
            SeedPatients(context);
            SeedMedicals(context);
        }

        private void SeedMedicals(DentistAppDbContext context)
        {
            if (!context.Medicals.Any())
            {
                var patients = context.Patients.ToList();
                var users = context.Users.ToList();

                for (int i = 0; i < 100; i++)
                {
                    var medical = new Medical
                    {
                        Diagnosis = RandomGenerator.RandomStringWithSpaces(10, 100),
                        ToothDesctiption = RandomGenerator.RandomStringWithSpaces(10, 50),
                        Treatment = RandomGenerator.RandomStringWithSpaces(10, 100),
                        PatientId = patients[RandomGenerator.RandomNumber(1, patients.Count - 1)].Id,
                        UserId = users[RandomGenerator.RandomNumber(1, users.Count - 1)].Id.ToString(),
                    };

                    context.Medicals.AddOrUpdate(medical);
                    context.SaveChanges();
                }
            }
        }

        private void SeedPatients(DentistAppDbContext context)
        {
            if (!context.Patients.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    var parient = new Patient
                    {
                        FirstName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        MiddleName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        LastName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        PatientNumber = RandomGenerator.RandomStringWithNumbers(10, 10),
                        PhoneNumber = RandomGenerator.RandomStringWithNumbers(10, 10),
                        Address = RandomGenerator.RandomStringWithSpaces(10, 50),
                    };

                    context.Patients.AddOrUpdate(parient);
                    context.SaveChanges();
                }
            }
        }

        private void SeedUsers(DentistAppDbContext context)
        {
            if (!context.Users.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    var usernameAndEmail = string.Format("{0}@{0}.com", RandomGenerator.RandomStringWithoutSpaces(2, 10));
                    var user = new User
                    {
                        Email = usernameAndEmail,
                        UserName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        FirstName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        LastName = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        Uin = RandomGenerator.RandomStringWithNumbers(10, 10),
                        Speciality = RandomGenerator.RandomStringWithoutSpaces(3, 30),
                        PhoneNumber = RandomGenerator.RandomStringWithNumbers(10, 10),
                    };

                    this.UserManager.Create(user, "parola");
                    context.SaveChanges();
                }
            }
        }
    }
}
