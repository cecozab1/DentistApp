namespace DentistApp.Data
{
    using System.Data.Entity;

    using DentistApp.Data.Models;

    public interface IDentistAppDbContext
    {
        IDbSet<Patient> Patients { get; set; }

        IDbSet<Medical> Medicals { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();
    }
}
