namespace DentistsApp.Web.ViewModels.Medical
{
    using DentistApp.Web.Infrastructure.Mapping;

    public class MedicalCreateViewModel : IMapFrom<DentistApp.Data.Models.Medical>
    {
        public string UserId { get; set; }

        public long PatientId { get; set; }

        public string ToothDesctiption { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }
    }
}