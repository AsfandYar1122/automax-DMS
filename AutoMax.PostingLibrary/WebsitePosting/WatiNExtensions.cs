using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public static class WatiNExtensions
    {
        public static void ForceChange(this Element e)
        {
            e.DomContainer.Eval("$('#" + e.Id + "').change();");
        }
    }
}
