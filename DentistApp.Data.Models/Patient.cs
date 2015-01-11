namespace DentistApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
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

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
