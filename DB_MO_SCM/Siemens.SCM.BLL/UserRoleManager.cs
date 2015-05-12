using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.Model;
using Siemens.SCM.Model.ViewModel;
using Siemens.SCM.DAL;

namespace Siemens.SCM.BLL
{
    public class UserRoleManager
    {
        public DataBaseManagementResult AddRole(Role role)
        {
            DataBaseManagementResult result = null;
            DataBaseOperate<Role> operate = new DataBaseOperate<Role>();
            result = operate.Add(role);
            return result;
        }

        public DataBaseManagementResult UpdateRole(Role role)
        {
            DataBaseManagementResult result = null;
            DataBaseOperate<Role> operate = new DataBaseOperate<Role>();
            result = operate.Update(role);
            return result;
        }

        public Role GetRoleFromID(int id)
        {
            Role result = null;
            RoleRecord ope = new RoleRecord();
            result = ope.Select(id);
            return result;
        }

        public Role GetRoleFromName(string name)
        {
            Role result = null;
            RoleRecord ope = new RoleRecord();
            result = ope.Select(name);
            return result;
        }
    }
}
