namespace DentistApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medical
    {
        [Key]
        public long Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public long PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string ToothDesctiption { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }
    }
}
