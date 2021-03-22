using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public class SharedPreferences
    {
        public static string ImageUploadFolder = "Upload/Images";
        public static int MaximumImageFileSize = 10 * 1024 * 1024;
        public static string ImageFileType = ".jpg";
    }
}
