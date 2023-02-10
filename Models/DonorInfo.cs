using Blood_Donor_App_v4.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donor_App_v4.Models
{
    public class DonorInfo: IdentityUser
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string  PhoneNumber { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        
/*        public string RegId { get; set; }
        [ForeignKey("RegId")]
        public RegisterModel RegisterModel { get; set; }
*/
    }
        
}
