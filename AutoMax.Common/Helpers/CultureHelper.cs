using AutoMax.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Common.Helpers
{
    public class CultureHelper
    {
        public static string CULTURE { get { return "culture"; } }

        /// <summary>
        /// Sets culture and returns value
        /// </summary>
        /// <param name="culture">Culture value</param>
        /// <returns>Current culture</returns>
        public static Culture Set(Culture culture)
        {
            return (Culture)SessionHelper.Write(CULTURE, culture);
        }

        /// <summary>
        /// Returns current culture
        /// </summary>
        /// <returns>Current culture</returns>
        public static Culture Get()
        {
            return SessionHelper.Read<Culture>(CULTURE);
        }
    }
}
