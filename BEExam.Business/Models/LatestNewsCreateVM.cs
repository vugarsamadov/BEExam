using Microsoft.AspNetCore.Http;

namespace BEExam.Business.Models
{
    public class LatestNewsCreateVM
    {
        public string AuthorName { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
