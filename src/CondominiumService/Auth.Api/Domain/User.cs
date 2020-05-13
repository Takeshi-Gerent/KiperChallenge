using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Domain
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        protected User() { }

        private User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public static User WithId(int id, string userName, string password)
        {
            return new User(id, userName, password);
        }


        public virtual bool PasswordMatches(string typedPassword) => Password == typedPassword;
    }
}
