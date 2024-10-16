
using TodoApi.Data.Models;

namespace Data.Models{
    public class Book{
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public required string CoverUrl { get; set; }
        public required string Genre { get; set; }
        public DateTime DateAdded { get; set; }

        //navigation properties
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
        
    }
}