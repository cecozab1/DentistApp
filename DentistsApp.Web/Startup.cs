﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentistsApp.Web.Startup))]
namespace DentistsApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
