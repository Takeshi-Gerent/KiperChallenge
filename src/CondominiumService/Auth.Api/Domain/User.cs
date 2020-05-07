using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Domain
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        protected User () { }

        private User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public virtual bool PasswordMatches(string typedPassword) => Password == typedPassword;
    }
}
