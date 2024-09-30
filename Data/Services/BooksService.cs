using System.Xml.Serialization;
using Data.Models;
using Data.ViewModels;

namespace Data.Services{
    public class BooksService{

        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book){
            var _book = new Book(){
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rate = book.isRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks(){
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId){
            return _context.Books.FirstOrDefault(n=> n.Id == bookId);
        }

        public Book UpdateBookById(int bookId , BookVM book){
            var _book = _context.Books.FirstOrDefault(n=> n.Id == bookId);
            if(_book!=null){
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.isRead = book.isRead;
                _book.DateRead = book.isRead ? book.DateRead.Value : null;
                _book.Rate = book.isRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int id){
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);
            if(_book != null){
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }

    }
}