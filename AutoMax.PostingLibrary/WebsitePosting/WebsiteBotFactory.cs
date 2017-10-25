using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class WebsiteBotFactory
    {
        private static WebsiteBotFactory instance;

        private WebsiteBotFactory() {}

        public static WebsiteBotFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebsiteBotFactory();
                }
                return instance;
            }
        }
        public WebsiteBot GetWebsiteBot(string websiteName)
        {
            if (websiteName == "Opensooq")
                return new OpensooqBot();
            else if (websiteName == "Haraj")
                return new HarajBot();
            throw new Exception("Website Bot not found");
        }
    }
}
