using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.News.Models.Response
{
    public class DailyNewsResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; } = null!;
    }
}
