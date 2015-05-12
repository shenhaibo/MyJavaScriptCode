using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.Model;

namespace Siemens.SCM.DAL
{
    public class PrivilegeRecordManager
    {
        public string GetPrivilegeFromAction(string actionName, string controllName)
        {
            string result = string.Empty;
            using (UsersContext db = new UsersContext())
            {
                var privilege = db.Privileges.SingleOrDefault(x => x.ControlName == controllName && x.ActionName == actionName);
                if (privilege != null)
                {
                    result = privilege.Name;
                }
            }
            return result;
        }
    }
}
