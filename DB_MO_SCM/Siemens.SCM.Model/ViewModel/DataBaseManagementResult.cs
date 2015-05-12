using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siemens.SCM.Model.ViewModel
{
    public class DataBaseManagementResult
    {
        public DataBaseManagementResult()
        {
            Status = false;
            ErrorMessage = string.Empty;
        }

        public bool Status { get; set; }
        public string ErrorMessage { get; set; }

    }
}
