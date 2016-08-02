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
        private string newline = "\\n";
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
        private string delRW_2 = ":|\\s|\\n";
        private string delRW_3 = "\\{|\\s|\\n";
        private string delRW_4 = "(|\\s)";
        private string delSY_1 = "\\s|[1-9]";
        private string delSY_2 = "\\s|[A-Z]|[a-z]";
        private string delSY_3 = "\\s|[A-Z]|[a-z]|[1-9]";
        private string delSY_4 = "\\s|.";
        private string delSY_5 = ";|\\n";
        private string delSY_6 = "\\s|[A-Z]|[a-z]|[1-9]|.";
        private string delSY_7 = "\\s|[A-Z]|[a-z]|[1-9]|.|;|\\n";
        private string delSY_8 = "\\n|";
        private string delSY_9 = "\\s|.|;|\\n|";
        private string delSY_10 = "\\s|.|;";
        private string delSY_11 = ":|\\s|\\n||\"";
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
            "<<=|\\+\\+|\\-\\-|\\(|\\)|\\{|\\}|\\[|\\]|-!|\\-\\->|;";

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

        // ENTRY POINT.
        public string Start(string[] input)
        {
            string col = "";
            delimiter = '"';
            hasError = false;
            hasLookahead = false;
            isDelimited = false;
            current = "";

            for (currLine = 0; currLine < input.Length; currLine++)
            {
                char[] line = input[currLine].Trim().ToCharArray();

                for (currColumn = 0; currColumn < line.Length; currColumn++)
                {
                    char column = line[currColumn];
                    col = column.ToString();
                    
                        if (col == "\r\n" || column == ' ' || column == '\t')
                        {
                            CheckAll(column.ToString());
                            current = "";
                        } else if (column == ',')
                        {
                            CheckAll(column.ToString());
                            frmMain.Self.dGridResults.Rows.Add(column, column);
                            current = "";
                        }
                        else if (CheckSymbol(column))
                        {
                            if (wasSymbol) current += column;
                            else
                            {
                                CheckAll(column.ToString());
                                current = column.ToString();
                            }
                        }
                        else
                        {
                            current += column;
                        }

                        wasSymbol = CheckSymbol(column);
                        //isSeperator = CheckSeperator(column);
                    }

                CheckAll(col.ToString());
                current = "";
            }

            if (!hasError) output = "No Errors.";

            return output;
        }

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
                    case "+":
                        Regex rgx = new Regex(delSY_1);
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
                    frmMain.Self.dGridResults.Rows.Add(current, current);
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