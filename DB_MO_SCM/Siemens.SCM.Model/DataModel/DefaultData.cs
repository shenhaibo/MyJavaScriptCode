using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siemens.SCM.Model.DataModel
{
    public class DefaultData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ID { get; set; }

        public int DefaultDataTypeID { get; set; }

        public virtual DefaultDataType defaultDataType { get; set; }
    }
}
