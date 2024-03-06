using _8MileRD.DataAccess.Repository.IRepository;
using _8MileRD.Models;
using _8MileRD2.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8MileRD.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; private set; }
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            categoryRepository = new CategoryRepository(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
