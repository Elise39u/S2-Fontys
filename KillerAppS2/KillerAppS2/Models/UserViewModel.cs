using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KillerAppS2.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = " ")]
        private string _email;

        [Required(ErrorMessage = " ")]
        private string _password;

        [Required(ErrorMessage = " ")]
        private string _firstname;

        [Required(ErrorMessage = " ")]
        private string _lastname;
        
        private string _prefix;
        private string _username;
        private int _attack;
        private int _defence;
        private int _curhp;
        private int _maxhp;

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string Username { get => _username; set => _username = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defence { get => _defence; set => _defence = value; }
        public int CurHP { get => _curhp; set => _curhp = value; }
        public int MaxHP { get => _maxhp; set => _maxhp = value; }
        public string FirstName { get => _firstname; set => _firstname = value; }
        public string LastName { get => _lastname; set => _lastname = value; }
        public string Prefix { get => _prefix; set => _prefix = value; }

        public UserViewModel()
        {

        }

        public UserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserViewModel(string firstName, string prefix, string lastName, string email, string password)
        {
            FirstName = firstName;
            Prefix = prefix;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public UserViewModel(string username, int attack, int defence, int curHP, int maxHP)
        {
            Username = username;
            Attack = attack;
            Defence = defence;
            CurHP = curHP;
            MaxHP = maxHP;
        }
    }
}
