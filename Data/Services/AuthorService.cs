using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using TodoApi.Data.Models;
using TodoApi.Data.ViewModels;

namespace TodoApi.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

       public void AddAuthor(AuthorVM author){
            var _author = new Author(){
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId){
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM(){
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select( n=> n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }


    }

   
}