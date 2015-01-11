namespace DentistsApp.Web.ViewModels.Patient
{
    using AutoMapper;
    using DentistApp.Web.Infrastructure.Mapping;

    public class PatientListViewModel : IMapFrom<DentistApp.Data.Models.Patient>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public string PatientNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<DentistApp.Data.Models.Patient, PatientListViewModel>()
                .ForMember(m => m.FullName, opt => opt.MapFrom(p => p.FirstName + " " + p.MiddleName + " " + p.LastName));
        }
    }
}