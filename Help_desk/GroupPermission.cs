using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk
{
    public class GroupPermission
    {
        [Key]
        public int Id { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
