using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DTO
{
    public class UpdatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string URLHandle { get; set; }
        public string FeautredImageURL { get; set; }
        public bool Visible { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
