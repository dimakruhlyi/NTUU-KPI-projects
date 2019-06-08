using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Coursework
{
    class Debug_Poliz : Debug_Syntax
    {
        List<string> P = new List<string>();

        List<string> _stack = new List<string>();
        protected List<string> outPut = new List<string>();
        protected List<List_Mitka> Mitka = new List<List_Mitka>();

        DataTable Data = new DataTable();

        string idn = string.Empty;
        int index = 0;
        int index1 = 0;

        public Debug_Poliz(string str) : base(str)
        {
            P.Add("if { for");
            P.Add("to");
            P.Add("step");
            P.Add("(");
            P.Add("} else )");
            P.Add(";");
            P.Add("=");
            P.Add("> < != ==");
            P.Add("+ -");
            P.Add("@");
            P.Add("* /");

            if (get_check_error() == false)
            {
                MessageBox.Show("Успішний синтаксис!");
                newPoliz();

                MessageBox.Show(get_outPut(outPut), "Успішний поліз!");

                for (int i = 0; i < outPut.Count(); i++)
                {
                    if (outPut[i][0] == 'm' && outPut[i][outPut[i].Count() - 1] == ':')
                    {
                        string a = outPut[i].Substring(0, outPut[i].Count() - 1);

                        Mitka.Add(new List_Mitka { _NameMitka = a, _ValueMitka1 = i + 1 });
                    }
                }
            }
        }

        private void newPoliz()
        {
            Data.Columns.Add("#");
            Data.Columns.Add("outPUT");
            Data.Columns.Add("Stack");
            Data.Columns.Add("inPUT");

            int count = 0;
            int index3 = index1;

            for (int i = 3; i < List_Lexem.Count - 1; i++)
            {
                string a0 = List_Lexem[i].Subcategory;

                bool check1 = true;

                while (check1)
                {
                    if (a0 == "int" || a0 == "float")
                    {
                        for (int j = i + 1; j < List_Lexem.Count; j++)
                        {
                            if (List_Lexem[j].Subcategory == ";")
                            {
                                i = j + 1;
                                break;
                            }
                        }


                        a0 = List_Lexem[i].Subcategory;
                    }
                    else
                    {
                        check1 = false;
                    }
                }

                if (i == List_Lexem.Count - 1)
                {
                    break;
                }

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

                if (a0 == "(" || a0 == ")" || a0 == "+" || a0 == "-" || a0 == "*" || a0 == "/" || a0 == "@" || a0 == ">" || a0 == "<" || a0 == "!=" || a0 == "==" || a0 == "=")
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
                                if (_stack[_stack.Count - 1] == "read")
                                {
                                    count++;
                                    outPut.Add("R");
                                    _stack.RemoveAt(_stack.Count - 1);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                }
                                else
                                {
                                    if (_stack[_stack.Count - 1] == "write")
                                    {
                                        count++;
                                        outPut.Add("W");
                                        _stack.RemoveAt(_stack.Count - 1);
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
                }

                if (a0 == ";")
                {
                    bool check = true;

                    if (_stack.Count > 0)
                    {
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
                                check = false;
                            }

                        } while (check && _stack.Count > 0);
                    }
                }

                if (a0 == "if")
                {
                    bool check2 = false;
                    for (int j = 0; j < _stack.Count(); j++)
                    {
                        string[] mas = _stack[j].Split();
                        if (mas[0] == "if")
                        {
                            check2 = true;
                            break;
                        }

                        if (mas[0] == "for")
                        {
                            check2 = true;
                            break;
                        }
                    }

                    if (check2 == false)
                    {
                        index += 4;
                        index1 += 4;
                        index3 = index;
                    }
                    else
                    {
                        index += 4;
                        index1 += 4;
                    }

                    if (_stack.Count == 0)
                    {
                        count++;
                        _stack.Add(a0);
                        Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                    }
                    else
                    {
                        bool check = true;

                        do
                        {
                            int indexStack = getIndex(_stack[_stack.Count - 1]);
                            int indexInPut = getIndex(a0);

                            if (indexStack >= indexInPut)
                            {
                                if (_stack[_stack.Count() - 1] == "for")
                                {
                                    count++;
                                    _stack.Add(a0);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                    check = false;
                                }
                                else
                                {
                                    count++;
                                    outPut.Add(_stack[_stack.Count - 1]);
                                    _stack.RemoveAt(_stack.Count - 1);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                }
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
                }

                if (a0 == "{")
                {
                    bool check = true;

                    do
                    {
                        int indexStack = getIndex(_stack[_stack.Count - 1]);
                        int indexInPut = getIndex(a0);

                        if (_stack[_stack.Count - 1] == "if")
                        {
                            count++;
                            outPut.Add("m" + index.ToString());
                            outPut.Add("YPB");

                            Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                            _stack[_stack.Count - 1] += " m" + index;

                            check = false;
                        }
                        else
                        {
                            if (_stack[_stack.Count - 1] == "if m" + index)
                            {
                                count++;
                                outPut.Add("m" + (index + 1).ToString());
                                outPut.Add("BP");
                                outPut.Add("m" + (index).ToString() + ":");

                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                _stack[_stack.Count - 1] += " m" + (index + 1).ToString();

                                check = false;
                            }
                            else
                            {
                                if (_stack[_stack.Count - 1] == "for")
                                {
                                    count++;
                                    outPut.Add("+");
                                    outPut.Add("=");
                                    outPut.Add("m" + (index).ToString());
                                    outPut.Add("BP");
                                    outPut.Add("m" + (index + 2).ToString() + ":");

                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                    check = false;
                                }
                                else
                                {
                                    if (indexStack >= indexInPut)
                                    {
                                        count++;
                                        outPut.Add(_stack[_stack.Count - 1]);
                                        _stack.RemoveAt(_stack.Count - 1);
                                        Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                    }
                                }
                            }
                        }
                    } while (check && _stack.Count > 0);
                }

                if (a0 == "}")
                {
                    string a1;
                    if (i + 1 < List_Lexem.Count() - 1)
                    {
                        a1 = List_Lexem[i + 1].Subcategory;
                    }
                    else
                    {
                        a1 = "}";
                    }


                    if (a1 != "else")
                    {

                        bool check = true;

                        do
                        {
                            int indexStack = getIndex(_stack[_stack.Count - 1]);
                            int indexInPut = getIndex(a0);

                            if (_stack[_stack.Count - 1] == "if m" + index)
                            {


                                count++;
                                outPut.Add("m" + index + ":");

                                _stack.RemoveAt(_stack.Count - 1);
                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                check = false;

                                if (index3 != index)
                                {
                                    index -= 4;
                                }
                                else
                                {
                                    index = index1;
                                    index3 = index;
                                }
                            }
                            else
                            {
                                if (_stack[_stack.Count - 1] == "if m" + index + " m" + (index + 1).ToString())
                                {
                                    count++;
                                    outPut.Add("m" + (index + 1).ToString() + ":");

                                    _stack.RemoveAt(_stack.Count - 1);
                                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                    check = false;

                                    if (index3 != index)
                                    {
                                        index -= 4;
                                    }
                                    else
                                    {
                                        index = index1;
                                        index3 = index;
                                    }
                                }
                                else
                                {
                                    if (_stack[_stack.Count - 1] == "for")
                                    {
                                        count++;
                                        outPut.Add("m" + (index + 3).ToString());
                                        outPut.Add("BP");
                                        outPut.Add("m" + (index + 1).ToString() + ":");

                                        _stack.RemoveAt(_stack.Count - 1);
                                        Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                                        check = false;

                                        if (index3 != index)
                                        {
                                            index -= 4;
                                        }
                                        else
                                        {
                                            index = index1;
                                            index3 = index;
                                        }
                                    }
                                    else
                                    {
                                        if (indexStack >= indexInPut)
                                        {
                                            count++;
                                            outPut.Add(_stack[_stack.Count - 1]);
                                            _stack.RemoveAt(_stack.Count - 1);
                                            Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                                        }
                                    }
                                }
                            }

                        } while (check && _stack.Count > 0);
                    }
                    else
                    {
                        i++;
                    }
                }

                if (a0 == "read")
                {
                    count++;
                    outPut.Add("Enter");
                    _stack.Add(a0);
                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                    i++;
                }

                if (a0 == "write")
                {
                    count++;
                    outPut.Add("Enter");
                    _stack.Add(a0);
                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                    i++;
                }

                if (a0 == "for")
                {
                    bool check2 = false;
                    for (int j = 0; j < _stack.Count(); j++)
                    {
                        string[] mas = _stack[j].Split();
                        if (mas[0] == "for")
                        {
                            check2 = true;
                            break;
                        }

                        if (mas[0] == "if")
                        {
                            check2 = true;
                            break;
                        }
                    }

                    if (check2 == false)
                    {
                        index += 4;
                        index1 += 4;
                        index3 = index;
                    }
                    else
                    {
                        index += 4;
                        index1 += 4;
                    }

                    idn = List_Lexem[i + 1].Subcategory;

                    count++;
                    _stack.Add(a0);
                    Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                }

                if (a0 == "to")
                {
                    bool check = true;

                    do
                    {
                        int indexStack = getIndex(_stack[_stack.Count - 1]);
                        int indexInPut = getIndex(a0);

                        if (_stack[_stack.Count - 1] == "for")
                        {
                            count++;
                            outPut.Add("m" + index + ":");
                            outPut.Add(idn);
                            //_stack.Add(a0);
                            Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));

                            check = false;
                        }
                        else
                        {
                            if (indexStack >= indexInPut)
                            {
                                count++;
                                outPut.Add(_stack[_stack.Count - 1]);
                                _stack.RemoveAt(_stack.Count - 1);
                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                            }
                        }
                    } while (check && _stack.Count > 0);
                }

                if (a0 == "step")
                {
                    bool check = true;

                    do
                    {
                        int indexStack = getIndex(_stack[_stack.Count - 1]);
                        int indexInPut = getIndex(a0);

                        if (_stack[_stack.Count - 1] == "for")
                        {
                            check = false;

                            count++;
                            outPut.Add("<");
                            outPut.Add("m" + (index + 1).ToString());
                            outPut.Add("YPB");
                            outPut.Add("m" + (index + 2).ToString());
                            outPut.Add("BP");
                            outPut.Add("m" + (index + 3).ToString() + ":");
                            outPut.Add(idn);
                            outPut.Add(idn);

                            Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                        }
                        else
                        {
                            if (indexStack >= indexInPut)
                            {
                                count++;
                                outPut.Add(_stack[_stack.Count - 1]);
                                _stack.RemoveAt(_stack.Count - 1);
                                Data.Rows.Add(count, get_outPut(outPut), get_outPut(_stack), get_outPut(List_Lexem, i + 1));
                            }
                        }
                    } while (check && _stack.Count > 0);
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

            for (int i = j; i < example.Count - 1 && i < 10 + j; i++)
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

        public List<List_Mitka> Get_Mitka()
        {
            return Mitka;
        }
    }
}