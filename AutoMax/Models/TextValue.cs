using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models
{
    public class TextValue
    {
        public TextValue()
        {

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>    Constructor. </summary>
        ///
        /// <remarks>    Muhammad, 2/25/2014. </remarks>
        ///
        /// <param name="text">  The text. </param>
        /// <param name="value"> The value. </param>
        ///-------------------------------------------------------------------------------------------------

        public TextValue(string text, string value)
        {
            _text = text;
            _value = value;
        }
        /// <summary>    The text. </summary>
        string _text = string.Empty;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>    Gets or sets the text. </summary>
        ///
        /// <value>  The text. </value>
        ///-------------------------------------------------------------------------------------------------

        public string text { get { return _text; } set { _text = value; } }
        /// <summary>    The value. </summary>
        string _value = string.Empty;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>    Gets or sets the value. </summary>
        ///
        /// <value>  The value. </value>
        ///-------------------------------------------------------------------------------------------------

        public string value { get { return _value; } set { _value = value; } }
    }
    public class LineCharTData
    {
        public int PostingSiteID { get; set; }
        public int Count { get; set; }
        public string Month { get; set; }
    }
    public class DisplayLineChart
    {
        public string category { get; set; }
        public int FBColumn { get; set; }
        public int OSColumn { get; set; }
        public int HRJColumn { get; set; }
    }
}