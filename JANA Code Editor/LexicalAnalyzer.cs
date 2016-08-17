using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JANA_Code_Editor
{
    public class LexicalAnalyzer
    {
        LexicalReader reader { get; set; }

        public LexicalAnalyzer(string code)
        {
            reader = new LexicalReader(code.ToCharArray());
        }
    }
}