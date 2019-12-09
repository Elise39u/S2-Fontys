using System;

namespace KillerAppS2DTO
{
    public class UserDTO
    {
        public int UserID { get; set;  }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int CurHP { get; set; }
        public int MaxHP { get; set; }

        public UserDTO(int userID, string username, string email, string password, int attack, int defence, int curHP, int maxHP)
        {
            UserID = userID;
            Username = username;
            Email = email;
            Password = password;
            Attack = attack;
            Defence = defence;
            CurHP = curHP;
            MaxHP = maxHP;
        }

        public UserDTO()
        {
        }
    }
}
