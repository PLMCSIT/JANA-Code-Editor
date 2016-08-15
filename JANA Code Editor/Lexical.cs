using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JANA_Code_Editor
{
    public class Lexical
    {
        // INSTANCE PROPERTIES
        private string output { get; set; }
        private string current { get; set; }
        private int currLine { get; set; }
        private int currColumn { get; set; }
        private char delimiter { get; set; }
        private bool hasError { get; set; }
        private bool hasLookahead { get; set; }
        private bool isDelimited { get; set; }
        private bool isSeperator { get; set; }
        private bool wasSymbol { get; set; }
        private char[] code { get; set; }

        private string RW = "get|out|clean|tolower|toupper|exit|main|" +
            "false|stop|true|choice|fall|attempt|handle|do|else|elseif|" +
            "test|then|if|iterate|strlen|until|boolean|char|class|int|" +
            "inherits|new|public|private|real|return|static|string|struct|" +
            "void";

        // Regular Expressions
        private string space = "\\s";
        private string paren = "\\(";
        private string hyphen = "\\-";
        private string semic = ";";
        private string newline = "\\r|\\n";
        private string zero = "0";
        private string und = "_";
        private string colon = ":";
        private string lowalpha = "[a-z]";
        private string upalpha = "[A-Z]";
        private string digit = "[1-9]";
        private string ASCII = ".";
        private string otherSY1 = "\\+";
        private string otherSY2 = "\\-|>";
        private string relop = "=|!";
        private string delRW_1 = ";|\\s";
        private string delRW_2 = ":|\\s|\\r";
        private string delRW_3 = "\\{|\\s|\\r";
        private string delRW_4 = "(|\\s)";
        private string delSY_1 = "\\s|[1-9]";
        private string delSY_2 = "\\s|[A-Z]|[a-z]";
        private string delSY_3 = "\\s|[A-Z]|[a-z]|[1-9]";
        private string delSY_4 = "\\s|.";
        private string delSY_5 = ";|\\r";
        private string delSY_6 = "\\s|[A-Z]|[a-z]|[1-9]|.";
        private string delSY_7 = "\\s|[A-Z]|[a-z]|[1-9]|.|;|\\r";
        private string delSY_8 = "\\n|";
        private string delSY_9 = "\\s|.|;|\\r|";
        private string delSY_10 = "\\s|.|;";
        private string delSY_11 = ":|\\s|\\r||\"";
        private string delid = ";|\\s|=|\\[|";
        private string delit = ";|\\s|\\.";
        private string delch = ";|\\s|'";
        private string delstr = ";|\\s|\"";

        // Identifiers
        private string id = "([a-z]|[A-Z])([a-z]|[A-Z]|[0-9]|_){0,9}";
        private string comment_line = "//";
        private string comment_block = "^(/\\*).*(\\*/)$";

        // Data Values
        private string intType = "^(~)*[1-9][0-9]{0,9}$";
        private string floatType = "^(~|[1-9])[0-9]{0,9}\\.[0-9]{0,10}";
        private string charType = "'.'";
        private string stringType = "^(\").*(\")$";

        // ALL OPERATORS
        private string operators = "\\+|\\-|/|%|\\*\\^|~|@@|\\$\\$|\\$|=|==|==!|>>|<<|>>=|" +
            "<<=|\\+\\+|\\-\\-|\\(|\\)|\\{|\\}|\\[|\\]|-!|\\-\\->|;|:";

        // SEPERATORS
        private string seperators = "\\s|\\r|,";

        // DELIMITERS
        private string delimiters = "\\\"|'";

        /*
        // Logical Operators
        private string logical_and = "@@";
        private string logical_or = "\\|\\|";

        // Relational Operators
        private string equal = "==";
        private string not_equal = "==!";
        private string gt = ">>";
        private string lt = "<<";
        private string gt_equal = ">>=";
        private string lt_equal = "<<=";

        // Other Symbols
        private string increment = "\\+\\+";
        private string decrement = "\\-\\-";

        // Arithmetic Operators
        private string add = "\\+";
        private string subtract = "\\-";
        private string divide = "/";
        //private string wut = "\\";
        private string modulo = "%";
        private string multiply = "\\*";
        private string power = "\\^";
        private string negate = "~";

        private string comma = ",";
        */

        int c = -1;

        // ENTRY POINT.
        public string Start(string[] input)
        {
            code = frmMain.Self.document.Text.ToCharArray();

            while (c < code.Length) scan();

            return output;
        }

        private void scan()
        {
            Regex rgx;
            
            try
            {
                // 0
                if (code[++c] == 'a')
                {
                    // 1
                    if (code[++c] == 't')
                    {
                        // 2
                        if (code[++c] == 't')
                        {
                            // 3
                            if (code[++c] == 'e')
                            {
                                // 4
                                if (code[++c] == 'm')
                                {
                                    // 5
                                    if (code[++c] == 'p')
                                    {
                                        // 6
                                        if (code[++c] == 't')
                                        {
                                            // 7
                                            rgx = new Regex(delRW_3);
                                            if (rgx.IsMatch(code[++c].ToString()))
                                            {
                                                // 8+
                                                frmMain.Self.dGridResults.Rows.Add("attempt", "attempt");
                                            }
                                            else
                                            {
                                                output += "[ERROR] Invalid use of reserved word 'attempt'.";
                                                hasError = true;
                                                frmMain.Self.dGridResults.Rows.Add("attempt", "invalid");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'b')
                {
                    // 9
                    if (code[++c] == 'o')
                    {
                        // 10
                        if (code[++c] == 'o')
                        {
                            // 11
                            if (code[++c] == 'l')
                            {
                                // 12
                                if (code[++c] == 'e')
                                {
                                    // 13
                                    if (code[++c] == 'a')
                                    {
                                        // 14
                                        if (code[++c] == 'n')
                                        {
                                            // 15
                                            rgx = new Regex(space);
                                            if (rgx.IsMatch(code[++c].ToString()))
                                            {
                                                // 16+
                                                frmMain.Self.dGridResults.Rows.Add("boolean", "boolean");
                                            } else
                                            {
                                                output += "[ERROR] Invalid use of reserved word 'boolean'.";
                                                hasError = true;
                                                frmMain.Self.dGridResults.Rows.Add("boolean", "invalid");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'c')
                {
                    // 17
                    if (code[++c] == 'h')
                    {
                        // 18
                        if (code[++c] == 'a')
                        {
                            // 19
                            if (code[++c] == 'r')
                            {
                                // 20
                                rgx = new Regex(space);
                                if (rgx.IsMatch(code[++c].ToString()))
                                {
                                    // 21+
                                    frmMain.Self.dGridResults.Rows.Add("char", "char");
                                } else
                                {
                                    output += "[ERROR] Invalid use of reserved word 'char'.";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("char", "invalid");
                                }
                            }
                        } else if (code[c] == 'o')
                        {
                            // 22
                            if (code[++c] == 'i')
                            {
                                // 23
                                if (code[++c] == 'c')
                                {
                                    // 24
                                    if (code[++c] == 'e')
                                    {
                                        // 25
                                        rgx = new Regex(delRW_2);
                                        if (rgx.IsMatch(code[++c].ToString()))
                                        {
                                            // 26+
                                            frmMain.Self.dGridResults.Rows.Add("choice", "choice");
                                        } else
                                        {
                                            output += "[ERROR] Invalid use of reserved word 'choice'.";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("choice", "invalid");
                                        }
                                    }
                                }
                            }
                        }
                    } else if (code[c] == 'l')
                    {
                        // 27
                        if (code[++c] == 'e')
                        {
                            // 28
                            if (code[++c] == 'a')
                            {
                                // 29
                                if (code[++c] == 'n')
                                {
                                    // 30
                                    rgx = new Regex(paren);
                                    if (rgx.IsMatch(code[++c].ToString()))
                                    {
                                        // 31+
                                        frmMain.Self.dGridResults.Rows.Add("clean", "clean");
                                    } else
                                    {
                                        output += "[ERROR] Invalid use of reserved word 'clean'.";
                                        hasError = true;
                                        frmMain.Self.dGridResults.Rows.Add("clean", "invalid");
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'd')
                {
                    // 32
                    if (code[++c] == 'o')
                    {
                        // 33
                        rgx = new Regex(delRW_3);
                        if (rgx.IsMatch(code[++c].ToString()))
                        {
                            // 34
                            frmMain.Self.dGridResults.Rows.Add("do", "do");
                        } else
                        {
                            output += "[ERROR] Invalid use of reserved word 'do'.";
                            hasError = true;
                            frmMain.Self.dGridResults.Rows.Add("do", "invalid");
                        }
                    }
                } else if (code[c] == 'e')
                {
                    // 35
                    if (code[++c] == 'l')
                    {
                        // 36
                        if (code[++c] == 's')
                        {
                            // 37
                            if (code[++c] == 'e')
                            {
                                // 38
                                rgx = new Regex(delRW_3);
                                if (code[++c] == 'i')
                                {
                                    // 40
                                    if (code[++c] == 'f')
                                    {
                                        // 41
                                        if (rgx.IsMatch(code[++c].ToString()))
                                        {
                                            // 42+
                                            frmMain.Self.dGridResults.Rows.Add("elseif", "elseif");
                                        } else
                                        {
                                            output += "[ERROR] Invalid use of reserved word 'elseif'.";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("elseif", "invalid");
                                        }
                                    }
                                } else if (rgx.IsMatch(code[c].ToString()))
                                {
                                    // 39+
                                    frmMain.Self.dGridResults.Rows.Add("else", "else");
                                } else
                                {
                                    output += "[ERROR] Invalid use of reserved word 'else'.";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("else", "invalid");
                                }
                            }
                        }
                    } else if (code[c] == 'x')
                    {
                        // 43
                        if (code[++c] == 'i')
                        {
                            // 44
                            if (code[++c] == 't')
                            {
                                // 45
                                if (code[++c] == '(')
                                {
                                    // 46
                                    if (code[++c] == ')')
                                    {
                                        // 47
                                        rgx = new Regex(delRW_1);
                                        if (rgx.IsMatch(code[++c].ToString()))
                                        {
                                            // 48+
                                            frmMain.Self.dGridResults.Rows.Add("exit", "exit");
                                        } else
                                        {
                                            output += "[ERROR] Invalid use of reserved word 'exit'.";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("exit", "invalid");
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'f')
                {
                    // 49
                    if (code[++c] == 'a')
                    {
                        // 50
                        if (code[++c] == 'l')
                        {
                            // 51
                            if (code[++c] == 'l')
                            {
                                // 52
                                rgx = new Regex(delRW_2);
                                if (rgx.IsMatch(code[++c].ToString()))
                                {
                                    // 53+
                                    frmMain.Self.dGridResults.Rows.Add("fall", "fall");
                                } else
                                {
                                    output += "[ERROR] Invalid use of reserved word 'fall'.";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("fall", "invalid");
                                }
                            } else if (code[c] == 's')
                            {
                                // 54
                                if (code[++c] == 'e')
                                {
                                    // 55
                                    rgx = new Regex(delRW_1);
                                    if (rgx.IsMatch(code[++c].ToString()))
                                    {
                                        // 56+
                                        frmMain.Self.dGridResults.Rows.Add("false", "false");
                                    }
                                    else
                                    {
                                        output += "[ERROR] Invalid use of reserved word 'false'.";
                                        hasError = true;
                                        frmMain.Self.dGridResults.Rows.Add("false", "invalid");
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'g')
                {
                    // 57
                    if (code[++c] == 'e')
                    {
                        // 58
                        if (code[++c] == 't')
                        {
                            // 59
                            rgx = new Regex(hyphen);
                            if (rgx.IsMatch(code[++c].ToString()))
                            {
                                // 60+
                                frmMain.Self.dGridResults.Rows.Add("get", "get");
                            } else
                            {
                                output += "[ERROR] Invalid use of reserved word 'get'.";
                                hasError = true;
                                frmMain.Self.dGridResults.Rows.Add("get", "invalid");
                            }
                        }
                    }
                } else if (code[c] == 'h')
                {
                    // 61
                    if (code[++c] == 'a')
                    {
                        // 62
                        if (code[++c] == 'n')
                        {
                            // 63
                            if (code[++c] == 'd')
                            {
                                // 64
                                if (code[++c] == 'l')
                                {
                                    // 65
                                    if (code[++c] == 'e')
                                    {
                                        // 66
                                        rgx = new Regex(delRW_3);
                                        if (rgx.IsMatch(code[++c].ToString()))
                                        {
                                            // 67+
                                            frmMain.Self.dGridResults.Rows.Add("handle", "handle");
                                        } else
                                        {
                                            output += "[ERROR] Invalid use of reserved word 'handle'.";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("handle", "invalid");
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'i')
                {
                    // 68
                    if (code[++c] == 'f')
                    {
                        // 69
                        rgx = new Regex(delRW_4);
                        if (rgx.IsMatch(code[++c].ToString()))
                        {
                            // 70+
                            frmMain.Self.dGridResults.Rows.Add("if", "if");
                        } else
                        {
                            output += "[ERROR] Invalid use of reserved word 'if'.";
                            hasError = true;
                            frmMain.Self.dGridResults.Rows.Add("if", "invalid");
                        }
                    }
                }
            } catch
            {

            }
        }
    }
}

        /*
        private void CheckAll(string c)
        {
            Regex rgxSymbols = new Regex(operators);
            Regex rgxSeperators = new Regex(seperators);
            Regex rgxRW = new Regex(RW);
            Regex rgxFloat = new Regex(floatType);
            Regex rgxInt = new Regex(intType);
            Regex rgxChar = new Regex(charType);
            Regex rgxString = new Regex(stringType);
            Regex rgxId = new Regex(id);

            bool found = false;
            bool valid = false;

            if (rgxRW.IsMatch(current))
            {
                found = true;
                switch (current)
                {
                    case "get":
                        Regex rgx = new Regex(hyphen);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "out":
                        rgx = new Regex(hyphen);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "clean":
                        rgx = new Regex(paren);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "tolower":
                        rgx = new Regex(paren);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "toupper":
                        rgx = new Regex(paren);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "exit":
                        rgx = new Regex(paren);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "main":
                        rgx = new Regex(paren);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "false":
                        rgx = new Regex(delRW_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "stop":
                        rgx = new Regex(delRW_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "true":
                        rgx = new Regex(delRW_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "choice":
                        rgx = new Regex(delRW_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "fall":
                        rgx = new Regex(delRW_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "attempt":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "handle":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "do":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "else":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "elseif":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "test":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "then":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "iterate":
                        rgx = new Regex(delRW_4);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "strlen":
                        rgx = new Regex(delRW_4);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "until":
                        rgx = new Regex(delRW_4);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "boolean":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "char":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "class":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "int":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "inherits":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "new":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "public":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "if":
                        rgx = new Regex(delRW_4);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "private":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "real":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "return":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "valid =":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "static":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "string":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "struct":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "void":
                        rgx = new Regex(space);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                }

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of reserved word \"" + current + "\".\r\n";
       
                } else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, current);
                }
            } else if (rgxSymbols.IsMatch(current))
            {
                switch (current)
                {
                    case " ":
                        Regex rgx = new Regex(".");
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "+":
                        rgx = new Regex(delSY_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "-":
                        rgx = new Regex(delSY_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "-!":
                        rgx = new Regex(delSY_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "/":
                        rgx = new Regex(delSY_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    
                    case "%":
                        rgx = new Regex(delSY_1);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "^":
                        rgx = new Regex("\\d");
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "~":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "@@":
                        rgx = new Regex(delSY_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "$$":
                        rgx = new Regex(delSY_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "$":
                        rgx = new Regex("[a-z]|[A-Z]");
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "=":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "==":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "==!":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case ">>":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "<<":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case ">>=":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "<<=":
                        rgx = new Regex(delSY_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "-->":
                        rgx = new Regex(delSY_6);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "++":
                        rgx = new Regex(delSY_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "--":
                        rgx = new Regex(delSY_2);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "(":
                        rgx = new Regex(delSY_11);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case ")":
                        rgx = new Regex(delSY_10);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "{":
                        rgx = new Regex(delSY_6);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "}":
                        rgx = new Regex(delSY_9);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "#":
                        rgx = new Regex("[a-z]|[A-Z]");
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case ";":
                        rgx = new Regex(delSY_8);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case "()":
                        rgx = new Regex(delRW_3);
                        valid = (rgx.IsMatch(c) ? true : false); break;
                    case ":":
                        rgx = new Regex(".");
                        valid = (rgx.IsMatch(c) ? true : false); break;
                }

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of symbol \"" + current + "\".\r\n";
                }
                else
                {
                    if (current == "()")
                    {
                        frmMain.Self.dGridResults.Rows.Add("(", "(");
                        frmMain.Self.dGridResults.Rows.Add(")", ")");
                    } else frmMain.Self.dGridResults.Rows.Add(current, current);
                }
            } else if (rgxChar.IsMatch(current))
            {
                Regex rgx = new Regex(delch);
                valid = (rgx.IsMatch(current) ? true : false);

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of charType \"" + current + "\".\r\n";
                }
                else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, "charType");
                }
            }
            else if (rgxString.IsMatch(current))
            {
                Regex rgx = new Regex(delstr);
                valid = (rgx.IsMatch(current) ? true : false);

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of stringType \"" + current + "\".\r\n";
                }
                else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, "stringType");
                }
            }
            else if (rgxInt.IsMatch(current))
            {
                Regex rgx = new Regex(delit);
                valid = (rgx.IsMatch(current) ? true : false);

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of intType \"" + current + "\".\r\n";
                }
                else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, "intType");
                }
            }
            else if (rgxFloat.IsMatch(current))
            {
                Regex rgx = new Regex(delRW_1);
                valid = (rgx.IsMatch(current) ? true : false);

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of floatType \"" + current + "\".\r\n";
                }
                else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, "floatType");
                }
            }
            else if (rgxId.IsMatch(current))
            {
                Regex rgx = new Regex(delid);
                valid = (rgx.IsMatch(current) ? true : false);

                if (!valid)
                {
                    hasError = true;
                    frmMain.Self.dGridResults.Rows.Add(current, "invalid");
                    output += "[LN " + (currLine + 1) + " COL " + (currColumn + 1) +
                        "] ERROR: Incorrect use of id \"" + current + "\".\r\n";
                }
                else
                {
                    frmMain.Self.dGridResults.Rows.Add(current, "id");
                }
            }
        }

        //private string operators = "\\+|\\-|/|%|\\*\\^|~|@@|\\$\\$|=|==|==!|>>|<<|>>=|" +
        //    "<<=|\\+\\+|\\-\\-|\\(|\\)|\\{|\\}|\\[|\\]";

        private bool CheckSeperator(char column)
        {
            Regex rgxSeperators = new Regex(seperators);

            return (rgxSeperators.IsMatch(column.ToString()) ? true : false);
        }

        private bool CheckSymbol(char column)
        {
            Regex rgxSymbol = new Regex(operators);

            return (rgxSymbol.IsMatch(column.ToString()) ? true : false);
        }
    }
}
*/