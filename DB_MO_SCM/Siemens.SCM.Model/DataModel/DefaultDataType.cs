using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siemens.SCM.Model.DataModel
{
    public class DefaultDataType
    {
        public DefaultDataType()
        {
            Enabled = true;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order=1)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public bool Enabled { get; set; }

        public virtual ICollection<DefaultData> DefaultDatas { get; set; }
    }
}
