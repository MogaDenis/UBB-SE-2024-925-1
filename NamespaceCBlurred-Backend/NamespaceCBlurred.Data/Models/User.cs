namespace NamespaceCBlurred.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;    

        public string Salt { get; set; } = string.Empty;

        private string HashedPassword { get; set; } = string.Empty;

        public bool VerifyPassword(string hashedPasswordAttempt)
        {
            return HashedPassword == hashedPasswordAttempt;
        }

        public string GetHashedPassword()
        {
            return HashedPassword;
        }
    }
}
