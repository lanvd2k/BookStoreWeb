
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModels;
using BookStore.Utility;
using BookStoreWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CompanyController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            return View();
        }


        // GET
        public IActionResult Upsert(int? id)
        {
            Company company = new();

            if (id == null || id == 0)
            {
                
                return View(company);
            }
            else
            {
                company = _uow.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);
            }


            
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                
                if(obj.Id == 0)
                {
                    _uow.Company.Add(obj);
                    TempData["success"] = "Create Product successfully";
                }
                else
                {
                    _uow.Company.Update(obj);
                    TempData["success"] = "Update Product successfully";
                }
                
                _uow.Save();
                
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
        

        #region APIs Call
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _uow.Company.GetAll();
            return Json(new {data = companyList });
        }

        
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _uow.Company.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uow.Company.Remove(obj);
            _uow.Save();
            return Json(new { success = true, message = "Delete successfully" });
        }
        #endregion
    }


}
