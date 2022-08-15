using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStoreWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BookStoreDbContext _db;

        public CategoryRepository(BookStoreDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
