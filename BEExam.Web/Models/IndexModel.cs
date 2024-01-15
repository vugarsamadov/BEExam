using BEExam.Business.Dtos;

namespace BEExam.Web.Models
{
    public class IndexModel
    {
        public IEnumerable<LatestNewsDto> LatestNews { get; set; }
    }
}
