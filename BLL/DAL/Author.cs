using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }


        public List<Author> Authors { get; set; } = new List<Author>();
    }
}