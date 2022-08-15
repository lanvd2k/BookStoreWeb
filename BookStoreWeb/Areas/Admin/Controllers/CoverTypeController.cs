
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Utility;
using BookStoreWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CovertypeController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CovertypeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypeList = _uow.CoverType.GetAll();
            return View(coverTypeList);
        }
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            
            if (ModelState.IsValid)
            {
                _uow.CoverType.Add(coverType);
                TempData["success"] = "Create CoverType successfully";
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverType = _uow.CoverType.GetFirstOrDefault(c => c.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
        {
            
            if (ModelState.IsValid)
            {
                _uow.CoverType.Update(coverType);
                _uow.Save();
                TempData["success"] = "Update CoverType successfully";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverType = _uow.CoverType.GetFirstOrDefault(c => c.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }
        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _uow.CoverType.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _uow.CoverType.Remove(obj);
            TempData["success"] = "Remove CoverType successfully";
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
