using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public short NumberOfPages { get; set; }
       
        public DateTime? PublicationDate { get; set; }
        
        public int? AuthorId { get; set; }
        public bool IsTopSeller { get; set; }   
        public Author Author { get; set; }
        public List<BookUser> BookUsers { get; set; } = new List<BookUser>();
    }
}
