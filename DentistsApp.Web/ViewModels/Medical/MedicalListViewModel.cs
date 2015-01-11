namespace DentistsApp.Web.ViewModels
{
    using AutoMapper;

    using DentistApp.Data.Models;
    using DentistApp.Web.Infrastructure.Mapping;

    public class MedicalListViewModel : IMapFrom<DentistApp.Data.Models.Medical>, IHaveCustomMappings
    {
        public string DentistName { get; set; }

        public string PatientName { get; set; }

        public string ToothDesctiption { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<DentistApp.Data.Models.Medical, MedicalListViewModel>()
                .ForMember(m => m.DentistName, opt => opt.MapFrom(mlvm => mlvm.User.UserName))
                .ForMember(m => m.PatientName, opt => opt.MapFrom(mlvm => mlvm.Patient.FirstName + " " + mlvm.Patient.LastName));
        }
    }
}