
namespace Data.Models{
    public class Book{
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public required string CoverUrl { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<object> Book_Authors { get; internal set; }
    }
}