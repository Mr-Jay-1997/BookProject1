using DALBookProject.Database.Tables;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBookProject.Database
{
    public class DALCategory
    {
        public List<CategoryModel> GetCategoryList()
        {
            var result = new List<CategoryModel>();
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    result = db.Categories.Where(x => x.categoryname != null).Select(x => new CategoryModel()
                    {
                        CategoryId = x.categoryid,
                        CategoryName = x.categoryname
                        

                    }).ToList();
                }
            }
            catch
            {

            }
            return result;
        }

       

        public CategoryModel GetCategory(int id)
        {
            var result = new CategoryModel();
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var category = db.Categories.FirstOrDefault(x => x.categoryid == id);

                    if (category != null)
                    {
                        var categoryModel = new CategoryModel()
                        {
                            CategoryId = category.categoryid,
                            CategoryName = category.categoryname
                            
                        };

                        return categoryModel;
                    }

                    //return null;
                }
            }
            catch
            {

            }
            return result;

        }

        public CategoryModel CreateCategory(CategoryModel categoryModel)
        {
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var newCategory = new CATEGORY()
                    {
                        categoryid = categoryModel.CategoryId,
                        categoryname = categoryModel.CategoryName
                       
                    };

                    db.Categories.Add(newCategory);
                    db.SaveChanges();

                    // Set the BookId property of the input object to the ID of the newly created book
                    categoryModel.CategoryId = newCategory.categoryid;
                }
            }
            catch
            {
                // Handle any exceptions
            }

            // Return the input object
            return categoryModel;
        }

        public CategoryModel UpdateCategory(int categoryId, CategoryModel updatedCategory)
        {
            using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
            {
                var categoryToUpdate = db.Categories.FirstOrDefault(b => b.categoryid == categoryId);
                //db.Books.Attach(bookToUpdate);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.categoryid = updatedCategory.CategoryId;
                    categoryToUpdate.categoryname = updatedCategory.CategoryName;
                    

                    db.SaveChanges();

                }
            }
            return updatedCategory;
        }


        public Boolean DeleteCategory(CategoryModel categoryModel)
        {
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var categoryToDelete = db.Categories.Where(b => b.categoryid == categoryModel.CategoryId).FirstOrDefault();
                    if (categoryToDelete != null)
                    {
                        db.Categories.Remove(categoryToDelete);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                // Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    }
}
