namespace DentistsApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using DentistApp.Data.Models;
    using DentistApp.Data.UnitOfWork;
    using DentistsApp.Web.Controllers.Base;
    using DentistsApp.Web.ViewModels;
    using DentistsApp.Web.Infrastructure.Services;
    using DentistsApp.Web.ViewModels.Medical;

    public class MedicalController : BaseController
    {
        private DropDownListService DropDownListsService { get; set; }

        public MedicalController(IDentistAppData data)
            : base(data)
        {
            this.DropDownListsService = new DropDownListService(this.Data);
        }

        public ActionResult Index()
        {
            var medicals = this.Data.Medicals
                .All()
                .Project()
                .To<MedicalListViewModel>()
                .OrderBy(m => m.DentistName);

            return this.View(medicals);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.ViewBag.PatientsDropDownList = this.DropDownListsService.GetPatientsDropDownList();
            this.ViewBag.DentistsDropDownList = this.DropDownListsService.GetDentistsDropDownList();

            var model = new MedicalCreateViewModel();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(MedicalCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var dbMedical = Mapper.Map<Medical>(model);

                this.Data.Medicals.Add(dbMedical);
                this.Data.SaveChanges();
                this.RedirectToAction("Index", "Medical");
            }

            return this.View(model);
        }
    }
}