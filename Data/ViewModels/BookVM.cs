namespace Data.ViewModels{
    public class BookVM{
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public required string CoverUrl { get; set; }
        public required string Genre { get; set; }

        public int? PublisherId { get; set; }

        public List<int> AuthorIds { get; set; }

    }

    public class BookWithAuthorsVM{
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public required string CoverUrl { get; set; }
        public required string Genre { get; set; }

        public string PublisherName { get; set; }

        public List<string> AuthorNames { get; set; }

    }
}