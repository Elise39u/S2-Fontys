using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KillerAppS2.Models
{
    public class UserViewModel
    {
        private string _email;
        private string _password;

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        public UserViewModel()
        {

        }

        public UserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
