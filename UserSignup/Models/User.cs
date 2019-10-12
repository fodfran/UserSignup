using System;
namespace UserSignup.Models
{
    public class User
    {
        public static int nextUserId = 1;
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoinTime { get; set; }

        public User()
        {
            UserId = nextUserId++;
            JoinTime = DateTime.Now;
        }
    }
}
