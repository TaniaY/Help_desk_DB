using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

        public List<GroupPermission> GroupPermissions { get; set; }
        public Permission()
        {
            GroupPermissions = new List<GroupPermission>();
        }
    }
}
