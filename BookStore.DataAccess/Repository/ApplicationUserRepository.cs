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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly BookStoreDbContext _db;

        public ApplicationUserRepository(BookStoreDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
