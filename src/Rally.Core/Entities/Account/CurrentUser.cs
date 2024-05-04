using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Core.Entities.Account
{
    public class CurrentUser(string Id, string Email, IEnumerable<string> Roles)
    {
        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
