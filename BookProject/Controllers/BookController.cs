using BLLBookProject;
using BookProject.Models;
using DALBookProject.Database;
using DALBookProject.Database.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SharedLibrary.Models;
using System.Globalization;

namespace BookProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        BLLBook bllbook = new BLLBook();
        public IActionResult Index()
        {
            var bookList = bllbook.GetBookList();
            return View(bookList);
        }

        public IActionResult Details(int id)
        {
            var book = bllbook.GetBook(id);
            return View(book);
        }

        public IActionResult Create()
        {
            using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
            {
                var bookModel = new BookModel();
                BLLCategory bLLCategory = new BLLCategory();
                ViewBag.Categories = GetCategories();
                return View(bookModel);
            }
        }

        [HttpPost]
        public IActionResult Create(BookModel bookModel)
        {
            try
            {
                bookModel = bllbook.CreateBook(bookModel);
                return RedirectToAction(nameof(Index));

            }
            catch
            {

            }
            return View(bookModel);
            
        }

        public IActionResult Edit(int id)
        {
            BLLCategory bLLCategory = new BLLCategory();
            ViewBag.Categories = GetCategories();
            var updatedBook = new BookModel();
            updatedBook = bllbook.GetBook(id);
            
            return View(updatedBook);
        }

        [HttpPost]
        public IActionResult Edit(int bookId, BookModel updatedBook)
        {
            try
            {
                updatedBook = bllbook.UpdateBook(bookId, updatedBook);

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var bookModel = new BookModel();
            bookModel = bllbook.GetBook(id);
            return View(bookModel);
        }
        [HttpPost]
        public IActionResult Delete(int id, BookModel bookModel)
        {
            try
            {

                bookModel= bllbook.DeleteBook(id,bookModel);
                
            }
            catch
            {
                // Handle any exceptions
            }
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetCategories()
        {
            var lstcategories = new List<SelectListItem>();
            BLLCategory bLLCategory= new BLLCategory();
            List<CategoryModel> categories = bLLCategory.GetCategoryList();
            lstcategories = categories.Select(ut=> new SelectListItem()
            {
                Value = ut.CategoryId.ToString(),
                Text = ut.CategoryName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "---Select Category---"
            };
            lstcategories.Insert(0, defItem);
            return lstcategories;
        }
    }
}
