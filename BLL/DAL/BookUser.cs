using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class BookUser
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Author Author { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
