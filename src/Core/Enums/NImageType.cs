using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum NImageType
    {
        [Description("Avatar")] Avatar = 1,
        [Description("CoverImage")] CoverImage = 2,
        [Description("Post")] Post = 3
    }
}
