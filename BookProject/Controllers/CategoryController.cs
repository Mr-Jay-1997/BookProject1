using BLLBookProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BookProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        BLLCategory bllcategory = new BLLCategory();
        public IActionResult Index()
        {
            var categoryList = bllcategory.GetCategoryList();
            return View(categoryList);
        }

        public IActionResult Details(int id)
        {
            var category = bllcategory.GetCategory(id);
            return View(category);
        }

        public IActionResult Create()
        {
            var categoryModel = new CategoryModel();
            return PartialView("_CreatePartialView",categoryModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel categoryModel)
        {
            try
            {
                categoryModel = bllcategory.CreateCategory(categoryModel);
                return RedirectToAction(nameof(Index));

            }
            catch
            {

            }
            return PartialView("_CreatePartialView", categoryModel);

        }

        public IActionResult Edit(int id)
        {
            var updatedCategory = new CategoryModel();
            updatedCategory = bllcategory.GetCategory(id);
            return PartialView("_EditPartialView",updatedCategory);
        }

        [HttpPost]
        public IActionResult Edit(int categoryId, CategoryModel updatedCategory)
        {
            try
            {
                updatedCategory = bllcategory.UpdateCategory(categoryId, updatedCategory);

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoryModel = new CategoryModel();
            categoryModel = bllcategory.GetCategory(id);
            return PartialView("_DeletePartialView",categoryModel);
        }
        [HttpPost]
        public IActionResult Delete(CategoryModel categoryModel)
        {
            try
            {
                //ModelState.Remove("CategoryName");
                if(ModelState.IsValid)
                {
                    var result= bllcategory.DeleteCategory(categoryModel);

                    if(result== true)
                    {
                        TempData["success"] = "category  successfully deleted";
                    }
                    else
                    {
                        TempData["error"] = "category not deleted";
                    }
                }
                else
                {
                    TempData["error"] = "please check fields";
                }
            
            }
            catch
            {
                // Handle any exceptions
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
