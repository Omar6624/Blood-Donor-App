using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Blood_Donor_App_v4.Areas.Identity.Pages.Account;

namespace Blood_Donor_App_v4.Models
{
    public class DonorOtherInfo:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string BloodType { get; set; }
        [Required]
        public string Gender { get; set; }




    }
}
