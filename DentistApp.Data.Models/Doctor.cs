namespace DentistApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }
    }
}
