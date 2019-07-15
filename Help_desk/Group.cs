using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

        public List<UserGroup> UserGroups { get; set; }
        public List<GroupPermission> GroupPermissions { get; set; }
        public Group()
        {
            UserGroups = new List<UserGroup>();
            GroupPermissions = new List<GroupPermission>();
        }
    }
}
