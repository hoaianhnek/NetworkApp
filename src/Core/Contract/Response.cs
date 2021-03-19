using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public class Response<TTypeDto>
    {
        public TTypeDto Dto { get; set; }
        public string Message { get; set; }
        public NResponseStatus ResponseCode { get; set; }
    }
}
