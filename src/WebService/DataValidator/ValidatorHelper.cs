using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebService.DataValidator
{
    public class ValidatorHelper
    {
        public void CheckMissingParamater(string propertyName, object propertyValue)
        {
            if (propertyValue == null
               || (propertyValue is string && string.IsNullOrWhiteSpace((string)propertyValue))
               || (propertyValue is int && (int)propertyValue == 0))
            {
                throw new IOException("Dữ liệu truyền thiếu");
            }
        }
    }
}