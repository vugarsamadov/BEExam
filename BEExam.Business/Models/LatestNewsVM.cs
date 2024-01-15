namespace BEExam.Business.Models;
    public class LatestNewsVM
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

