using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Blood_Donor_App_v4.Areas.Identity.Pages.Account;
using System.ComponentModel;

namespace Blood_Donor_App_v4.Models
{
    public class DonorOtherInfo:IdentityUser
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "BloodType")]
        [Required]
        public string BloodType { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }


        [Display(Name = "IsActive")]
        [DefaultValue(true)]
        [Required]
        public bool IsActive { get; set; }




    }
}
