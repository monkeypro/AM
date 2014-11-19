using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SimpsonsWebApi.Models
{
    public class UserIdentity : GenericIdentity
    {
        public string Password { get; set; }

        public UserIdentity(string name, string password) : base(name)
        {
            Password = password;
        }
    }
}