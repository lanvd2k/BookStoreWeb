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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly BookStoreDbContext _db;

        public CompanyRepository(BookStoreDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(Company coverType)
        {
            _db.Companies.Update(coverType);
        }
    }
}
