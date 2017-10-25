using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Common
{
    public enum Language
    {
        English = 0, Arabic = 1
    }

    public sealed class SharedStorage
    {
        private static readonly Lazy<SharedStorage> lazy =
            new Lazy<SharedStorage>(() => new SharedStorage());

        public static SharedStorage Instance { get { return lazy.Value; } }

        private SharedStorage()
        {
        }

        public string GetDropDownBindValue(string value)
        {
            if (LastSelectedLanguage == Models.Common.Language.Arabic)
            {
                return "Arabic" + value;
            }

            return value;
        }

        public Language LastSelectedLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void SetLanguageSelected()
        {
            var culterinfo = System.Threading.Thread.CurrentThread.CurrentCulture.CompareInfo;
            if (culterinfo.Name == "en-US")
            {
                LastSelectedLanguage = Language.English;
            }
            else if (culterinfo.Name == "ar-AR")
            {
                LastSelectedLanguage = Language.Arabic;
            }
            else
            {
                LastSelectedLanguage = Language.English;
            }
        }

    }
}
