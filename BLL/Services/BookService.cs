using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    
    public class BookService : ServiceBase, IService<Book, BookModel>
    {
        public BookService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Book record)
        {
            if (_db.Books.Any(b => b.Name.ToLower() == record.Name.ToLower().Trim() && b.PublicationDate == record.PublicationDate))
                return Error("Book with same name and publication date exits! ");
            record.Name = record.Name?.Trim();
            _db.Books.Add(record);
            _db.SaveChanges();
            return Success("Book created succesfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Books.Include(b => b.BookUsers).SingleOrDefault(b => b.Id == id);
            if (entity is null)
                return Error("Book can't be found.");
            _db.BookUsers.RemoveRange(entity.BookUsers);
            _db.Books.Remove(entity);
            _db.SaveChanges();
            return Success("Book deleted succesfully.");

        }

        public IQueryable<BookModel> Query()
        {
            return _db.Books.Include(b => b.Author).OrderByDescending(b => b.PublicationDate).ThenByDescending(b => b.IsTopSeller).ThenBy(b => b.Name).Select(b => new BookModel() { Record = b });
        }

        public ServiceBase Update(Book record)
        {
            if (_db.Books.Any(b => b.Id != record.Id && b.Name.ToLower() == record.Name.ToLower().Trim() && b.PublicationDate == record.PublicationDate))
                return Error("Book with same name and publication date exits! ");
            record.Name = record.Name?.Trim();
            _db.Books.Update(record);
            _db.SaveChanges();
            return Success("Book updated succesfully.");
        }
    }
}
