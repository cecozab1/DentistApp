namespace DentistsApp.Web.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using DentistApp.Data.UnitOfWork;
    using DentistsApp.Web.ViewModels;
    using DentistsApp.Web.ViewModels.User;

    public class DropDownListService
    {
        private IDentistAppData Data { get; set; }

        public DropDownListService(IDentistAppData data)
        {
            this.Data = data;
        }

        public SelectList GetPatientsDropDownList()
        {
            var patients = this.Data.Patients.All()
                .Project()
                .To < PatientDropDownListViewModel>()
                .ToList();

            List<SelectListItem> ddl = new List<SelectListItem>();
            ddl.AddRange(new SelectList(patients, "Id", "FullName"));

            return new SelectList(ddl, "Value", "Text");
        }

        public SelectList GetDentistsDropDownList()
        {
            var patients = this.Data.Users.All()
                .Project()
                .To<UserDropDownListViewModel>()
                .ToList();

            List<SelectListItem> ddl = new List<SelectListItem>();
            ddl.AddRange(new SelectList(patients, "Id", "DentistName"));

            return new SelectList(ddl, "Value", "Text");
        }
    }
}