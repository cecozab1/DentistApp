namespace DentistsApp.Web.Controllers.Base
{
    using System.Threading;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using DentistApp.Data.UnitOfWork;

    public class BaseController : Controller
    {
        //protected User CurrentUser
        //{
        //    get
        //    {
        //        return this.Data.Users.GetById(this.GetUserId());
        //    }
        //}

        protected IDentistAppData Data;

        public BaseController(IDentistAppData data)
        {
            this.Data = data;
        }

        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}