using _8MileRD.DataAccess.Repository.IRepository;
using _8MileRD.Models;
using _8MileRD2.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace _8MileRD.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save() => _db.SaveChanges();
        public void Update(Category obj) => _db.Categoies.Update(obj);

    }
}
