namespace DentistsApp.Web.ViewModels.Patient
{
    using System.ComponentModel.DataAnnotations;

    using DentistApp.Web.Infrastructure.Mapping;
    using DentistApp.Data.Models;

    public class PatientCreateViewModel : IMapFrom<Patient>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string PatientNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}