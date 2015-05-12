using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.DAL;

namespace Siemens.SCM.BLL
{
    public class PrivilegeManager
    {
        public string GetCurrentPrivilegeName(string actionName, string controllName)
        {
            string result = string.Empty;
            PrivilegeRecordManager manager = new PrivilegeRecordManager();
            result = manager.GetPrivilegeFromAction(actionName, controllName);
            return result;
        }
    }
}
