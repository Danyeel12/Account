using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public class Person
    {
        private string Password;
        public event EventHandler OnLogin;
        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get;private set; }
        public Person(string name, string sin)
        {
            Name = name;
            Sin= sin;
            Password = sin.Substring(0, 3).GetHashCode().ToString();
        }
        public void Login(string password)
        {

            if (password.GetHashCode().ToString() == Password)
            {
                IsAuthenticated = true;
                OnLogin.Invoke(this, new LoginEventArgs(Name, true));
            }
            else
            {
                IsAuthenticated = false;
                OnLogin.Invoke(this, new LoginEventArgs(Name, false));
                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
            }
        }
        public void Logout()
        {
            IsAuthenticated = false;
        }
        public override string ToString()
        {
            return $" {Name} {(IsAuthenticated ? "Logged in" : "Not logged in")}";
        }
    }
}
