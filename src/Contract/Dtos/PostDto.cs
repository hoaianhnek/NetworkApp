using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime? UploadDate { get; set; }
        public List<string> ImagePath { get; set; }
    }
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public List<string> ImagePaths { get; set; }
        public string HashTag { get; set; }
    }
}
