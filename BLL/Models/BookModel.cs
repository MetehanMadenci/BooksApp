using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }
         
        public string Name => Record.Name;
        [DisplayName("Top Seller")]// title: DisplayNameFor HTML Helper
        public string IsTopSeller => Record.IsTopSeller ? "Top Seller" : "Not a Top Seller";
        [DisplayName("Publication Date")]
        public string PublicationDate => !Record.PublicationDate.HasValue ? string.Empty : Record.PublicationDate.Value.ToString("MM/dd/yyyy");

        [DisplayName("Page Numbers:")]
        public short NumberOfPages =>Record.NumberOfPages;
        public string Author => Record.Author?.Name;
    }
}
