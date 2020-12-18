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
    class Debug_Interpretator : Debug_Poliz
    {
        DataTable Data = new DataTable();
        List<string> _stack = new List<string>();

        List<string> _stackW = new List<string>();

        bool checkError = true;

        public Debug_Interpretator(string str) : base(str)
        {
            for (int i = 0; i < outPut.Count() && checkError; i++)
            {
                if (checkIdConst(outPut[i]) >= 0)
                {
                    _stack.Add(outPut[i]);
                }
                else
                {
                    bool checkMitka = true;
                    int index = -1;

                    for (int j = 0; j < Mitka.Count() && checkMitka; j++)
                    {
                        if (outPut[i] == Mitka[j]._NameMitka)
                        {
                            index = j;
                            checkMitka = false;
                        }
                    }

                    if (checkMitka == false)
                    {
                        if (i + 1 < outPut.Count() - 1)
                        {
                            if (outPut[i + 1] == "YPB")
                            {
                                _stack.Add(outPut[i]);
                            }
                            else
                            {
                                i = Mitka[index]._ValueMitka1;

                                if (i == outPut.Count())
                                {
                                    break;
                                }

                                i--;
                                continue;
                            }
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == "+" || outPut[i] == "-" || outPut[i] == "*" || outPut[i] == "/")
                {
                    if (_stack.Count() - 2 < 0)
                    {
                        error("wrong Poliz", "");
                        checkError = false;
                    }
                    else
                    {
                        int index1 = checkIdConst(_stack[_stack.Count() - 2]);
                        int index2 = checkIdConst(_stack[_stack.Count() - 1]);

                        if (index1 >= 0 && index2 >= 0)
                        {
                            int id1 = getValue(index1, 2);
                            int id2 = getValue(index2, 1);

                            switch (outPut[i])
                            {
                                case "+":
                                    _stack[_stack.Count() - 1] = (id1 + id2).ToString();
                                    break;
                                case "-":
                                    _stack[_stack.Count() - 1] = (id1 - id2).ToString();
                                    break;
                                case "/":
                                    _stack[_stack.Count() - 1] = (id1 / id2).ToString();
                                    break;
                                case "*":
                                    _stack[_stack.Count() - 1] = (id1 * id2).ToString();
                                    break;
                            }

                            _stack.RemoveAt(_stack.Count() - 2);
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == "=")
                {
                    if (_stack.Count() - 2 < 0)
                    {
                        error("wrong Poliz", "");
                        checkError = false;
                    }
                    else
                    {
                        int index1 = checkIdConst(_stack[_stack.Count() - 2]);
                        int index2 = checkIdConst(_stack[_stack.Count() - 1]);

                        if (index1 > 0 && index2 >= 0)
                        {
                            if (index1 - 1 != 0)
                            {
                                int id2 = getValue(index2, 1);

                                List_Id[index1 - 1].Value = (id2).ToString();
                                _stack.RemoveAt(_stack.Count() - 1);
                                _stack.RemoveAt(_stack.Count() - 1);
                            }
                            else
                            {
                                error("The variable '" + List_Id[index1 - 1].Name + "' is not used", "");
                                checkError = false;
                            }
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == "@")
                {
                    if (_stack.Count() - 1 < 0)
                    {
                        error("wrong Poliz", "");
                        checkError = false;
                    }
                    else
                    {
                        int index1 = checkIdConst(_stack[_stack.Count() - 1]);

                        if (index1 >= 0)
                        {
                            int id1 = getValue(index1, 1);

                            _stack[_stack.Count() - 1] = (id1 * (-1)).ToString();
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == ">" || outPut[i] == "<" || outPut[i] == "==" || outPut[i] == "!=")
                {
                    if (_stack.Count() - 2 < 0)
                    {
                        error("wrong Poliz", "");
                        checkError = false;
                    }
                    else
                    {
                        int index1 = checkIdConst(_stack[_stack.Count() - 2]);
                        int index2 = checkIdConst(_stack[_stack.Count() - 1]);

                        if (index1 >= 0 && index2 >= 0)
                        {
                            int id1 = getValue(index1, 2);
                            int id2 = getValue(index2, 1);

                            switch (outPut[i])
                            {
                                case ">":
                                    if (id1 > id2)
                                    {
                                        _stack[_stack.Count() - 1] = (1).ToString();
                                    }
                                    else
                                    {
                                        _stack[_stack.Count() - 1] = (0).ToString();
                                    }
                                    break;

                                case "<":
                                    if (id1 < id2)
                                    {
                                        _stack[_stack.Count() - 1] = (1).ToString();
                                    }
                                    else
                                    {
                                        _stack[_stack.Count() - 1] = (0).ToString();
                                    }
                                    break;

                                case "==":
                                    if (id1 == id2)
                                    {
                                        _stack[_stack.Count() - 1] = (1).ToString();
                                    }
                                    else
                                    {
                                        _stack[_stack.Count() - 1] = (0).ToString();
                                    }
                                    break;

                                case "!=":
                                    if (id1 != id2)
                                    {
                                        _stack[_stack.Count() - 1] = (1).ToString();
                                    }
                                    else
                                    {
                                        _stack[_stack.Count() - 1] = (0).ToString();
                                    }
                                    break;
                            }

                            _stack.RemoveAt(_stack.Count() - 2);
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == "YPB")
                {
                    if (_stack.Count() - 2 < 0)
                    {
                        error("wrong Poliz", "");
                        checkError = false;
                    }
                    else
                    {
                        int index1 = checkIdConst(_stack[_stack.Count() - 2]);
                        int index2 = checkIdConst(_stack[_stack.Count() - 1]);

                        int index = -1;
                        bool checkMitka = true;

                        if (index1 == 0 && index2 == -1)
                        {
                            for (int j = 0; j < Mitka.Count() && checkMitka; j++)
                            {
                                if (outPut[i - 1] == Mitka[j]._NameMitka)
                                {
                                    index = j;
                                    checkMitka = false;
                                }
                            }

                            if (checkMitka == false)
                            {
                                int id1 = getValue(index1, 2);

                                if (id1 == 0)
                                {
                                    i = Mitka[index]._ValueMitka1;
                                    i--;

                                    _stack.RemoveAt(_stack.Count() - 1);
                                    _stack.RemoveAt(_stack.Count() - 1);

                                    continue;
                                }
                                else
                                {
                                    _stack.RemoveAt(_stack.Count() - 1);
                                    _stack.RemoveAt(_stack.Count() - 1);
                                }
                            }
                            else
                            {
                                error("wrong Poliz", "");
                                checkError = false;
                            }
                        }
                        else
                        {
                            error("wrong Poliz", "");
                            checkError = false;
                        }
                    }
                }

                if (outPut[i] == "W")
                {
                    for (int j = _stack.Count() - 1; j >= 0; j--)
                    {
                        int index1 = checkIdConst(_stack[j]);

                        if (index1 > 0)
                        {
                            int id1 = getValue(index1, 0);

                            _stackW.Add( _stack[j] + " := " + id1 + "\n");
                        }
                        else
                        {
                            if (index1 == 0)
                            {
                                _stackW.Add(Convert.ToInt32(_stack[j]) + "\n");
                            }
                        }

                        _stack.RemoveAt(j);
                    }
                }

                if (outPut[i] == "R")
                {
                    Input newInput = new Input();
                    newInput.ShowDialog();
                    string[] masID = newInput.str.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    newInput.Close();

                    if (masID.Count() == _stack.Count())
                    {
                        int index = masID.Count() - 1;
                        for (int j = _stack.Count() - 1; j >= 0; j--)
                        {
                            int index1 = checkIdConst(_stack[j]);

                            if (index1 - 1 == 0)
                            {
                                error("The variable '" + List_Id[index1 - 1].Name + "' is not used", "");
                                checkError = false;
                            }
                            else
                            {
                                if (index1 > 0)
                                {
                                    if (verify_const(masID[index]) == false)
                                    {
                                        error("Wrong input: " + newInput.str, "");
                                        checkError = false;
                                    }
                                    else
                                    {
                                        List_Id[index1 - 1].Value = masID[index];
                                    }
                                }
                            }

                            _stack.RemoveAt(j);
                            index--;
                        }
                    }
                    else
                    {
                        error("Wrong input: " + newInput.str, "");
                        checkError = false;
                    }
                }
            }

            if (checkError)
            {
                string a0 = string.Empty;
                for (int i = 0; i < _stack.Count(); i++)
                {
                    a0 += _stack[i] + " ";
                }
                MessageBox.Show("Інтерпретатор!");
            }
        }

        private int checkIdConst(string value)
        {
            if (verify_const(value))
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < List_Id.Count(); i++)
                {
                    if (value == List_Id[i].Name)
                    {
                        return i + 1;
                    }
                }
            }

            return -1;
        }

        private int getValue(int index, int id)
        {
            if (index == 0)
            {
                return Convert.ToInt32(_stack[_stack.Count() - id]);
            }
            else
            {
                if (List_Id[index - 1].Value == null)
                {
                    error("Undetectable variable '" + List_Id[index - 1].Name + "'", "");
                    checkError = false;
                    return 0;
                }
                else
                {
                    if (List_Id[index - 1].Value == "NULL")
                    {
                        error("The variable '" + List_Id[index - 1].Name + "' is not used", "");
                        checkError = false;
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(List_Id[index - 1].Value);
                    }
                }
            }
        }

        public string GetW()
        {
            string str = string.Empty;

            for (int i = 0; i < _stackW.Count(); i++)
            {
                str += _stackW[i];
            }

            return str;
        }
    }
}
