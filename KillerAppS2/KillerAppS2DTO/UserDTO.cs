using System;

namespace KillerAppS2DTO
{
    public class UserDTO
    {
        private int UserID { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int CurHP { get; set; }
        public int MaxHP { get; set; }
    }
}
