using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public static class Utils
    {
        public static string GetAppSettingBaseURL()
        {
            return System.Configuration.ConfigurationManager.AppSettings["MyBaseUrlLocal"];
        }
        public static string GetDefaultUserAvatar()
        {
            return System.Configuration.ConfigurationManager.AppSettings["DefaultUserAvatar"];
        }
        public static string GetDefaultUserCoverImage()
        {
            return System.Configuration.ConfigurationManager.AppSettings["DefaultUserCoverImage"];
        }
    }
}