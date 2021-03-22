using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public class Base64ImageUploader
    {
        public static string GenerateImageFileName(string code)
        {
            var filename = code + "--" + DateTimeOffset.Now.ToString("yyyy-MM-dd HH-mm-ss-fff");
            return (filename + SharedPreferences.ImageFileType);
        }
    }
}
