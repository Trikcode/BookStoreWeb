using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        //tell our application that we need implementation( we have registered ApplicatonDbContext)
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <Category> objCategory = _db.Categories;

            return View(objCategory);
        }
        //get
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Category obj)

        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order can't match the Name");
                //ModelState.AddModelError("Name", "The display order can't match the Name");
            }
            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
            //if in diff controller
            //return RedirectToAction("Index", another controller);
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryToDb = _db.Categories.FirstOrDefault(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();

            }
            return View(categoryFromDb);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)

        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order can't match the Name");
                //ModelState.AddModelError("Name", "The display order can't match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated Successfully";
                return RedirectToAction("Index");
                //if in diff controller
                //return RedirectToAction("Index", another controller);
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryToDb = _db.Categories.FirstOrDefault(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();

            }
            return View(categoryFromDb);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ObjCategory = _db.Categories.Find(id);
            if (ObjCategory == null)
            {
                return NotFound();
            }

                _db.Categories.Remove(ObjCategory);
                _db.SaveChanges();
            TempData["success"] = "Category deleted Successfully";
            return RedirectToAction("Index");
                //if in diff controller
                //return RedirectToAction("Index", another controller);
        }
           
    }
    
}
