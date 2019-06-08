using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace LAB_1
{
    class POLIZ : Debug_Lexem_0
    {
        List<string> P = new List<string>();

        List<string> _stack = new List<string>();
        List<string> outPut = new List<string>();

        DataTable Data = new DataTable();

        public POLIZ(string str) : base(str)
        {
            P.Add("(");
            P.Add(") + -");
            P.Add("@ * /");

            newPoliz();
        }

        private void newPoliz()
        {
            Data.Columns.Add("#");
            Data.Columns.Add("outPUT");
            Data.Columns.Add("Stack");
            Data.Columns.Add("inPUT");

            int count = 0;

            for (int i = 0; i < List_Lexem.Count; i++)
            {
                string a0 = List_Lexem[i].Subcategory;



                if (Find_Lexem(a0) == 0)
                {
                    count++;
                    outPut.Add(a0);
                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                }

                if (a0 == "-")
                {
                    if (i - 1 < 0 || List_Lexem[i - 1].Subcategory == "(" || List_Lexem[i - 1].Subcategory == "*" || List_Lexem[i - 1].Subcategory == "/")
                    {
                        a0 = "@";
                    }
                }

                if (a0 == "(" || a0 == ")" || a0 == "+" || a0 == "-" || a0 == "*" || a0 == "/" || a0 == "@")
                {
                    if (_stack.Count == 0)
                    {
                        count++;
                        _stack.Add(a0);
                        Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                    }
                    else
                    {
                        if (a0 != "(" && a0 != ")")
                        {
                            bool check = true;

                            do
                            {
                                int indexStack = getIndex(_stack[_stack.Count - 1]);
                                int indexInPut = getIndex(a0);

                                if (indexStack >= indexInPut)
                                {
                                    count++;
                                    outPut.Add(_stack[_stack.Count - 1]);
                                    _stack.RemoveAt(_stack.Count - 1);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                }
                                else
                                {
                                    count++;
                                    _stack.Add(a0);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                    check = false;
                                }

                            } while (check && _stack.Count > 0);

                            if (_stack.Count == 0)
                            {
                                count++;
                                _stack.Add(a0);
                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                            }
                        }
                        else
                        {
                            if (a0 == "(")
                            {
                                count++;
                                _stack.Add(a0);
                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                            }
                            else
                            {
                                while (_stack[_stack.Count - 1] != "(")
                                {
                                    count++;
                                    outPut.Add(_stack[_stack.Count - 1]);
                                    _stack.RemoveAt(_stack.Count - 1);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                }
                                _stack.RemoveAt(_stack.Count - 1);
                            }
                        }
                    }
                }
            }

            for (int i = _stack.Count - 1; i >= 0; i--)
            {
                count++;
                outPut.Add(_stack[i]);
                _stack.RemoveAt(i);
                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), "");
            }
        }

        private int getIndex(string str)
        {
            for (int j = 0; j < P.Count; j++)
            {
                string[] splitStr = P[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int q = 0; q < splitStr.Count(); q++)
                {
                    if (str == splitStr[q])
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        private string get_outPut(List<string> example)
        {
            string str = string.Empty;

            for (int i = 0; i < example.Count; i++)
            {
                str += example[i].ToString() + " ";
            }

            return str;
        }

        private string get_outPut(List<Lexems> example, int j)
        {
            string str = string.Empty;

            for (int i = j; i < example.Count && i < 10 + j; i++)
            {
                string a0 = List_Lexem[i].Subcategory;
                str += a0 + " ";
            }

            return str;
        }


        public DataTable Get_Data_Stan()
        {
            return Data;
        }
    }
}
