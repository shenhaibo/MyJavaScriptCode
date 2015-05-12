using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.Model;
using System.Threading.Tasks;

namespace Siemens.SCM.DAL
{
    public class UserRecordManager
    {
        public List<string> GetUserPrivileges(string name)
        {
            List<string> privileges = new List<string>();
            using (UsersContext db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.SingleOrDefault(x => x.UserName == name);
                if (user != null)
                {
                    Parallel.ForEach(user.Roles, role =>
                    {
                        Parallel.ForEach(role.Privileges, item =>
                        {
                            privileges.Add(item.Name);
                        });
                    });
                }
            }
            return privileges;
        }
    }
}
