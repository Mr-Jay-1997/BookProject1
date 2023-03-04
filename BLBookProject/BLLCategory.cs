using DALBookProject.Database;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLBookProject
{
    public class BLLCategory
    {
        DALCategory dalcategory = new DALCategory();
        public List<CategoryModel> GetCategoryList()
        {
            return dalcategory.GetCategoryList();
        }

        public CategoryModel GetCategory(int id)
        {
            return dalcategory.GetCategory(id);
        }

        public CategoryModel CreateCategory(CategoryModel categoryModel)
        {
            return dalcategory.CreateCategory(categoryModel);
        }

        public CategoryModel UpdateCategory(int categoryId, CategoryModel updatedCategory)
        {
            return dalcategory.UpdateCategory(categoryId, updatedCategory);
        }


        public Boolean DeleteCategory(CategoryModel categoryModel)
        {
            
            var result= dalcategory.DeleteCategory(categoryModel);
            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
