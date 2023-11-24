namespace SportsApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalMatchesPlayed { get; set; }
        public int Contactnumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
