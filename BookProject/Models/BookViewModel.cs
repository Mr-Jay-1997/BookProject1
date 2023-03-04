using SharedLibrary.Models;

namespace BookProject.Models
{
    public class BookViewModel
    {
        public List<BookModel> Books { get; set; }
        public List<CategoryModel> Categories { get; set; }

        public BookViewModel(List<BookModel> _books, List<CategoryModel> _categories)
        {
            Books= _books;
            Categories = _categories;
        }

    }
}
