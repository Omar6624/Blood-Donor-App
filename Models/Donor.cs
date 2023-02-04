namespace Blood_Donor_App_v4.Models
{
    public class Donor
    {
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
