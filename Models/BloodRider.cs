using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Blood_Donor_App_v4.Models
{
    public class BloodRider
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [DefaultValue(false)]
        public bool HasVehicle { get; set; }

    }
}
