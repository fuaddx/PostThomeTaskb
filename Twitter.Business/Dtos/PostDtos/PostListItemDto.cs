using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Business.Dtos.PostDtos
{
    public class PostListItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
    }
}
