using StudyingTesting.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingTesting.users
{
    public class User
    {
        public string Username { get; set; }
        public List<User_Role> Roles { get; set; }

        public User(string username, List<User_Role> roles)
        {
            Username = username;
            Roles = roles;
        }

        public bool CanOpenTable()
        {
            return Roles.Contains(User_Role.ADMIN) || Roles.Contains(User_Role.MANAGER);
        }
    }

}
