using Microsoft.Build.Framework;


namespace Blood_Donor_App_v4.Models
{
    public class Donor_info
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string  Phone_number { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
