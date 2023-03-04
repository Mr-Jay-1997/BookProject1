using DALBookProject.Database;
using DALBookProject.Database.Tables;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBookProject
{
    public class DALBook
    {
        public List<BookModel> GetBookList()
        {
            var result = new List<BookModel>();
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    result = db.Books.Where(x => x.bookname != null).Include(x=>x.CATEGORY).Select(x => new BookModel()
                    {
                        BookId = x.bookid,
                        BookName = x.bookname,
                        CategoryName = x.CATEGORY.categoryname,
                        Author = x.author,
                        Publisher = x.publisher,
                        Price = x.price

                    }).ToList();
                }
            }
            catch
            {

            }
            return result;
        }

        public BookModel GetBook(int id)
        {
            var result = new BookModel();
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var book = db.Books.Include(x => x.CATEGORY).FirstOrDefault(x => x.bookid == id);

                    if (book != null)
                    {
                        var bookModel = new BookModel()
                        {
                            BookId= book.bookid,
                            BookName = book.bookname,
                            CategoryName = book.CATEGORY.categoryname,
                            Author = book.author,
                            Publisher = book.publisher,
                            Price = book.price
                        };

                        return bookModel;
                    }

                    //return null;
                }
            }
            catch
            {

            }
            return result;

        }

        public BookModel CreateBook(BookModel bookModel)
        {
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var newBook = new BOOK()
                    {
                        bookid= bookModel.BookId,
                        bookname = bookModel.BookName,
                        categoryid = bookModel.CategoryId,
                        author = bookModel.Author,
                        publisher = bookModel.Publisher,
                        price = bookModel.Price
                    };
                    


                    db.Books.Add(newBook);
                    db.SaveChanges();

                    // Set the BookId property of the input object to the ID of the newly created book
                    bookModel.BookId = newBook.bookid;
                }
                
            }
            catch
            {
                // Handle any exceptions
            }

            // Return the input object
            return bookModel;
        }

        public BookModel UpdateBook(int bookId, BookModel updatedBook)
        {
            using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
            {
                var bookToUpdate = db.Books.FirstOrDefault(b => b.bookid == bookId);
                //db.Books.Attach(bookToUpdate);
                if (bookToUpdate != null)
                {
                    bookToUpdate.bookid = updatedBook.BookId;
                    bookToUpdate.bookname = updatedBook.BookName;
                    bookToUpdate.categoryid = updatedBook.CategoryId;
                    bookToUpdate.author = updatedBook.Author;
                    bookToUpdate.publisher = updatedBook.Publisher;
                    bookToUpdate.price = updatedBook.Price;

                    db.SaveChanges();
                    
                }
            }
            return updatedBook;
        }


        public BookModel DeleteBook(int id, BookModel bookModel)
        {
            try
            {
                using (var db = new BookDbContext(BookDbContext.ops.dbOptions))
                {
                    var bookToDelete = db.Books.FirstOrDefault(b => b.bookid == id);
                    if (bookToDelete != null)
                    {
                        db.Books.Remove(bookToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine(ex.Message);
            }
            return bookModel;
           
        }
         


    }
}
