namespace DentistsApp.Web.ViewModels
{
    using AutoMapper;

    using DentistApp.Data.Models;
    using DentistApp.Web.Infrastructure.Mapping;

    public class PatientDropDownListViewModel : IMapFrom<DentistApp.Data.Models.Patient>, IHaveCustomMappings
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<DentistApp.Data.Models.Patient, PatientDropDownListViewModel>()
                .ForMember(m => m.FullName, opt => opt.MapFrom(p => p.FirstName + " " + p.LastName));
        }
    }
}