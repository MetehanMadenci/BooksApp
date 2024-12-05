using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BLL.DAL
{
   
        public class Db : DbContext
        {
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

            public DbSet<Users> Users { get; set; }

            public DbSet<BookUser> BookUsers { get; set; }

            public Db(DbContextOptions options) : base(options)
            {

            }

        
    }
}
