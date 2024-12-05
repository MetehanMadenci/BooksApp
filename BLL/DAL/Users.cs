using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public string password { get; set; }
        public bool IsActive { get; set; }

        public int RoleId {  get; set; }

        public List<BookUser> BookUsers { get; set; } = new List<BookUser>();
    }
}
