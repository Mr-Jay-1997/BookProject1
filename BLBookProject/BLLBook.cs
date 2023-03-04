using DALBookProject;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLBookProject
{
    public class BLLBook
    {
        DALBook dalbook = new DALBook();
        public List<BookModel> GetBookList()
        {
            return dalbook.GetBookList();
        }

        public BookModel GetBook(int id)
        {
            return dalbook.GetBook(id);
        }

        public BookModel CreateBook(BookModel bookModel)
        {
            return dalbook.CreateBook(bookModel);
        }

        public BookModel UpdateBook(int bookId, BookModel updatedBook)
        {
            return dalbook.UpdateBook(bookId, updatedBook);
        }

        
        public BookModel DeleteBook(int id, BookModel bookModel)
        {
            return dalbook.DeleteBook(id, bookModel);
        }

    }
}
