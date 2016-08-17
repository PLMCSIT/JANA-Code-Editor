using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JANA_Code_Editor
{
    public class LexicalReader
    {
        private int line { get; set; }
        private int column { get; set; }
        private int index { get; set; }
        private char[] code { get; set; }

        public LexicalReader(char[] input)
        {
            line = 0;
            column = 0;
            index = -1;
            code = input;
        }

        public char Next()
        {
            index++;
            return code[index];
        }

        public char Lookahead()
        {
            return code[index + 1];
        }
    }
}
