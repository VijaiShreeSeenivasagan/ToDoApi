using System;
using Data.Models;

namespace TodoApi.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        
        //navigation properties
        public List<Book> Books { get; set; }
    }
}