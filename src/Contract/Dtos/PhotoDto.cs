using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImagePath { get; set; }
    }
}
