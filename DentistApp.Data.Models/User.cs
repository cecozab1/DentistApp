namespace DentistApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        private ICollection<Medical> medicals { get; set; }
        private ICollection<Patient> patients { get; set; }

        public User()
        {
            this.patients = new HashSet<Patient>();
            this.medicals = new HashSet<Medical>();
        }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Uin { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Speciality { get; set; }

        public virtual ICollection<Patient> Patients
        {
            get { return this.patients; }
            set { this.patients = value; }
        }

        public virtual ICollection<Medical> Medicals
        {
            get { return this.medicals; }
            set { this.medicals = value; }
        }
    }
}
