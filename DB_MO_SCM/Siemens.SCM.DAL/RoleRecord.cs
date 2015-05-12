using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.Model;

namespace Siemens.SCM.DAL
{
    public class RoleRecord
    {
        public Role Select(int id)
        {
            Role result = null;
            using (UsersContext db = new UsersContext())
            {
                result = db.Roles.SingleOrDefault(x => x.RoleId == id);
            }
            return result;
        }

        public Role Select(string name)
        {
            Role result = null;
            using (UsersContext db = new UsersContext())
            {
                result = db.Roles.SingleOrDefault(x => x.RoleName == name);
                //db.Database.ExecuteSqlCommand("");
            }
            return result;
        }
    }
}
