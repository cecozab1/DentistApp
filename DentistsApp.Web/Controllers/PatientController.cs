namespace DentistsApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using DentistApp.Data.Models;
    using DentistApp.Data.UnitOfWork;
    using DentistsApp.Web.Controllers.Base;
    using DentistsApp.Web.ViewModels.Patient;

    public class PatientController : BaseController
    {
        public PatientController(IDentistAppData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var patients = this.Data.Patients.All()
                .Project()
                .To<PatientListViewModel>()
                .OrderBy(p => p.FullName);

            return this.View(patients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new PatientCreateViewModel();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var dbPatient = Mapper.Map<Patient>(model);

                this.Data.Patients.Add(dbPatient);
                this.Data.SaveChanges();
                this.RedirectToAction("Index");
            }

            return this.View(model);
        }
    }
}