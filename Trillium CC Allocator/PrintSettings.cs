using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trillium_CC_Allocation
{
    public class PrintSettings
    {
        // attributes
        public string TopMargin;
        public string BottomMargin;
        public string LeftMargin;
        public string RightMargin;
        public string Header;
        public string Footer;
        public string PrintBG;

        // constructor
        public PrintSettings()
        {
            TopMargin = null;
            BottomMargin = null;
            LeftMargin = null;
            RightMargin = null;
            Header = null;
            Footer = null;
            PrintBG = null;
        }
    }
}
