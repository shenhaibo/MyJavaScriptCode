using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.DAL;

namespace Siemens.SCM.BLL
{
    public class UserManager
    {
        private string Name { get; set; }

        public UserManager(string name)
        {
            this.Name = name;
        }

        public List<string> GetPrivileges()
        {
            List<string> list = null;
            UserRecordManager manager = new UserRecordManager();
            list = manager.GetUserPrivileges(Name);
            return list;
        }
    }
}
