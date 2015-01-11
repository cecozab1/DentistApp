namespace DentistsApp.Web.ViewModels.User
{
    using AutoMapper;

    using DentistApp.Web.Infrastructure.Mapping;

    public class UserDropDownListViewModel : IMapFrom<DentistApp.Data.Models.User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string DentistName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<DentistApp.Data.Models.User, UserDropDownListViewModel>()
                .ForMember(m => m.DentistName, opt => opt.MapFrom(p => "doc. " + p.FirstName + " " + p.LastName));
        }
    }
}