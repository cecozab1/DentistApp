namespace DentistApp.Data.UnitOfWork
{
    using DentistApp.Data.Models;
    using DentistApp.Data.Repository;

    public interface IDentistAppData
    {
        IRepository<User> Users { get; }

        IRepository<Patient> Patients { get; }

        IRepository<Medical> Medicals { get; }

        int SaveChanges();
    }
}
