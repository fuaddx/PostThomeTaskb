using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Post:BaseEntity
    {
        public string Content { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int UpdatedCount { get; set; }
        public string AppUserId { get; set; }
        public string AuthorName { get; set; }
        public AppUser AppUser { get; set; }
    }
}
