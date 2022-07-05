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
    }
}
