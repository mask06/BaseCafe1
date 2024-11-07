using BaseCafe.BLL.DTOs;
using BaseCafe.BLL.Managers.Abstract;
using BaseCafe.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseCafe.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;

        public CategoryController(IGenericManager<CategoryDTO, Category> categoryManager)
        {
            _categoryManager=categoryManager;
        }

        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            _categoryManager.Add(categoryDTO);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryManager.Find(id);
            
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(CategoryDTO categoryDTO)
        {
            _categoryManager.Update(categoryDTO);
            return RedirectToAction(nameof(Index));
        }

    }
}
