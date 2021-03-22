using Core.Enums;
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Core.Utility
{
    public class ImageUploader
    {
        public static ImageFile UploadImage(string fileName, string base64ImageData, string imageType)
        {
            var imageFile = new ImageFile();
            NResponseStatus? error = null;

            var imageData = Convert.FromBase64String(base64ImageData);
                
            if (imageData.Length > SharedPreferences.MaximumImageFileSize) error = NResponseStatus.MaximizeImageSize;
            else
            {
                var folderName = imageType;
                var host = ConfigurationManager.AppSettings["MyBaseUrlLocal"];/*https://localhost:44343*/
                var prefix = ConfigurationManager.AppSettings["PrefixImage"];
                var fullPath = prefix + folderName + '/' + fileName;
                //save path
                string savePath = HttpContext.Current.Server.MapPath("~" + fullPath);
                //image url 
                string imageUrl = host + fullPath;

                MemoryStream ms = new MemoryStream(imageData);
                Image img = Image.FromStream(ms);
                img.Save(savePath, ImageFormat.Jpeg);
                imageFile.OrginalImage = imageUrl;
            }

            return imageFile;
        }
    }
    public class ImageFile
    {
        public string OrginalImage { get; set; }
        public string ThumbImage { get; set; }
    }
}
