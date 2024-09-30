using Data.Services;
using Data.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Controllers{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase{
        public BooksService _booksService ;
 
        public BooksController(BooksService booksService){
            _booksService = booksService;
        }

        [HttpGet("get-all-books")]

        public IActionResult GetAllBooks(){
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-bu-id/{id}")]
        public IActionResult GetBookById(int id){
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book){
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpPut("updated-book-by-id/{id}")]

        public IActionResult UpdateBookById(int id , [FromBody]BookVM book){
            var updatedBook = _booksService.UpdateBookById(id,book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]

        public IActionResult DeleteBookById(int id){
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}