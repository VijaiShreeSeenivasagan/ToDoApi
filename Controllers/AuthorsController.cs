using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Data.Services;
using TodoApi.Data.ViewModels;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorsController(AuthorService authorsService)
        {
            _authorService = authorsService;
        }
        // POST: api/authors
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books/{id}")]

        public IActionResult GetAuthorWithBooks(int id){
            var response = _authorService.GetAuthorWithBooks(id);
            return Ok(response);        
        }

    

        
    }

}
