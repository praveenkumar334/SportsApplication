namespace SportsApplication.Models
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalMatchesPlayed { get; set; }
        public int Contactnumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public string Password { get; set; }

        public string Confirmpwd { get; set; }
        public int RoleId { get; set; }
    }
}
