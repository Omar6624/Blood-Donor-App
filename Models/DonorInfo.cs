using System.ComponentModel.DataAnnotations;


namespace Blood_Donor_App_v4.Models
{
    public class DonorInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string  PhoneNumber { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
