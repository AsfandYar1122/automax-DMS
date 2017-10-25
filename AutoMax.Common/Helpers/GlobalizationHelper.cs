using AutoMax.Common.Enums;
using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Common.Helpers
{
    public class GlobalizationHelper
    {
        public static string GLOBALIZATION { get { return "globalization"; } }

        /// <summary>
        /// Returns value of specific AutoGlobalizion's key from cache
        /// </summary>
        /// <param name="key">Key of AutoGlobalization</param>
        /// <returns>Value of AutoGlobaliztion</returns>
        public string GetResourceValue(string key)
        {
            List<AutoGlobalization> autoGlobalizations = GetAllFromCache();
            AutoGlobalization autoGlobalization = autoGlobalizations.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            switch (CultureHelper.Get())
            {
                case Culture.EN:
                    return autoGlobalization.En;
                case Culture.AR:
                    return autoGlobalization.Ar;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Loads all data of AutoGlobalization in cache from database
        /// </summary>
        public void LoadAllInCache()
        {

        }

        /// <summary>
        /// Returns the list of all AutoGlobalization from cache
        /// </summary>
        /// <returns>List of AutoGlobalization</returns>
        public static List<AutoGlobalization> GetAllFromCache()
        {
            return CacheHelper.Read<List<AutoGlobalization>>(GLOBALIZATION);
        }

    }
}
