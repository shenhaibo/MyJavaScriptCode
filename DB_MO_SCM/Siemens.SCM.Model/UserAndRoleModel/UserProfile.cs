using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Siemens.SCM.Model
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Column(Order = 1)]
        public string UserName { get; set; }


        [Column(Order = 2)]
        public string UserCode { get; set; }

        [Column(Order = 3)]
        public int Status { get; set; }

        [Column(Order = 4)]
        public string Email { get; set; }

        [Column(Order = 5)]
        public int? Gender { get; set; }

        [Column(Order = 6)]
        public int? CreatorId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
