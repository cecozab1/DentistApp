namespace DentistApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        private ICollection<Medical> medicals { get; set; }

        public Patient()
        {
            this.medicals = new HashSet<Medical>();
        }

        [Key]
        public long Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string MiddleName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string PatientNumber { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Address { get; set; }

        public virtual ICollection<Medical> Medicals
        {
            get { return this.medicals; }
            set { this.medicals = value; }
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
