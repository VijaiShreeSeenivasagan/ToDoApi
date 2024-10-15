using System;

namespace TodoApi.Data.ViewModels
{
    public class AuthorVM
    {
        // Properties of the AuthorVM class
       
        public required string FullName { get; set; }
       
    }

    public class AuthorWithBooksVM
    {
        // Properties of the AuthorWithBooksVM class
        public required string FullName { get; set; }
        public List<string> BookTitles { get; internal set; }
    }
}