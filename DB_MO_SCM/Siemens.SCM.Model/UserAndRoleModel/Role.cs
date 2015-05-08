using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Siemens.SCM.Model
{
    [Table("webpages_Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int RoleId { get; set; }

        [Column(Order = 1)]
        public int? ParentId { get; set; }      //父级角色ID

        [Required]
        [Column(Order = 2)]
        public string RoleName { get; set; }

        [Column(Order = 3)]
        public int TreeLevel { get; set; }

        [Column(Order = 4)]
        public string TreePath { get; set; }

        [Column(Order = 5)]
        public int Status { get; set; }

        [Column(Order = 6)]
        public string Description { get; set; }

        [ForeignKey("ParentId")]
        public virtual Role Parent { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<Role> Children { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }
        public virtual ICollection<Privilege> Privileges { get; set; }
    }
}
