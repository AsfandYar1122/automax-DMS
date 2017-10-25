using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace AutoMax.Common.Helpers
{
    public class CacheHelper
    {
        public static object Write(string key, object value)
        {
            HttpContext.Current.Cache[key] = value;
            return value;
        }

        public static T Read<T>(string key)
        {
            return (T)HttpContext.Current.Cache[key];
        }
    }
}
