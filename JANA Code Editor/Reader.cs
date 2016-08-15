using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JANA_Code_Editor
{
    public class Reader
    {
        private string[] lines { get; set; }
        private char[] column { get; set; }
        private int current { get; set; }
        private int lineNumber { get; set; }

        public Reader()
        {
            lines = frmMain.Self.document.Lines;
            lineNumber = 0;
            current = -1;
        }

        public char next()
        {
            if (current < lines[lineNumber].Length)
            {
                current++;
                return column[current];
            } else
            {
                lineNumber++;
                current = -1;
                return next();
            }
        }
    }
}
