using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum NResponseStatus
    {
        //200
        [Description("Ok")] Ok = 20010,
        [Description("No resource found")] NoData = 20011,
        //500
        [Description("Cannot save data into database")] NotWriteData = 50011,
        //401
        [Description("User not existed")] UserNotExisted = 40110,
        [Description("User existed")] UserExisted = 40111,
        [Description("Could not authenticate you")] Unauthorized = 40112,
        //400
        [Description("Cannot find resource to process")] NotFoundResourceToProcess = 40010,
        [Description("The Image size must be less than 3MB")] MaximizeImageSize = 40011,
        [Description("Base64 string is malformed")] Base64StringIsMalformed = 40012
    }
}
