using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IAuthorsService
    {
        public IQueryable<AuthorsModel> Query();
        public ServiceBase Create(Author record);
        public ServiceBase Update(Author record);
        public ServiceBase Delete(int id);

    }
    public class AuthorService : ServiceBase, IAuthorsService
    {
        public AuthorService(Db db) : base(db)
        {
        }

        public IQueryable<AuthorsModel> Query()
        {
            return _db.Authors.OrderBy(s => s.Name).Select(s=> new AuthorsModel() { Record = s }); 
        }
        public ServiceBase Create(Author record)
        {
            if (_db.Authors.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Authors with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Authors.Add(record);
            _db.SaveChanges();
            return Success("Authors created succesfully");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Authors.Include(s => s.Authors).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Authors can't be found");
            if (entity.Authors.Any())
                return Error("Authors has relational books.");
            _db.Authors.Remove(entity);
            _db.SaveChanges();
            return Success("Authors deleted succesfully");
        }

     

        public ServiceBase Update(Author record)
        {
            if (_db.Authors.Any(s => s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Authors with the same name exists!");
            var entity = _db.Authors.SingleOrDefault(s => s.Id == record.Id);
            if (entity is null)
                return Error("Authors can't be found");
            entity.Name = record.Name?.Trim();
            _db.Authors.Update(entity);
            _db.SaveChanges();
            return Success("Authors created succesfully");
            
        }
    }
}
