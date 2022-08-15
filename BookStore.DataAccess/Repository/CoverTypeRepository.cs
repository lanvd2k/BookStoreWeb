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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly BookStoreDbContext _db;

        public CoverTypeRepository(BookStoreDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
        }
    }
}
