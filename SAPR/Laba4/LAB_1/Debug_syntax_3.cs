using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace LAB_1
{
    class Debug_syntax_3 : Debug_Lexem_0
    {
        DataTable relation = new DataTable();
        DataTable First = new DataTable();
        DataTable Last = new DataTable();
        DataTable Stack = new DataTable();

        List<Rules> List_Rules = new List<Rules>();


        public Debug_syntax_3(string str) : base(str)
        {
            Initial_List_Rules();

            First.Columns.Add(" ");
            Last.Columns.Add(" ");
            for (int i = 1; i < relation.Columns.Count; i++)
            {
                First.Columns.Add(relation.Columns[i].ColumnName);
                First.Rows.Add(relation.Columns[i].ColumnName);

                Last.Columns.Add(relation.Columns[i].ColumnName);
                Last.Rows.Add(relation.Columns[i].ColumnName);
            }

            Initial_relation_state1();
        }

        private void Initial_List_Rules()
        {
            relation.Columns.Add(" ");
            FileStream file = new FileStream("Simple_Forward1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);
            

            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                int index = str.IndexOf(' ');
                string Name_str = str.Substring(0, index);
                str = str.Remove(0, index + 2);

                string[] mas = str.Split(new char[] { '|', '#' }, StringSplitOptions.RemoveEmptyEntries);

                List_Rules.Add(new Rules { Name_Rules1 = Name_str, Values_Rules1 = mas });
            }
            
            reader.Close();

            Initial_size_relation();
        }

        private void Initial_size_relation()
        {
            FileStream file = new FileStream("Simple_Forward1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            string str = reader.ReadToEnd();
            string[] mas = str.Split(new char[] { '|', '#', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < mas.Count(); i++)
            {
                bool ck = true;

                for (int j = 0; j < relation.Columns.Count; j++)
                {
                    if (mas[i] == relation.Columns[j].ColumnName.ToString())
                    {
                        ck = false;
                        break;
                    }
                }

                if (ck)
                {
                    relation.Columns.Add(mas[i]);
                    relation.Rows.Add(mas[i]);
                }
            }

            reader.Close();
        }

        private void Initial_relation_state1()
        {
            for (int i = 0; i < List_Rules.Count; i++)
            {
                for (int j = 0; j < List_Rules[i].Get_size_Values_Rules(); j++)
                {
                    string[] mas = List_Rules[i].Values_Rules1[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int n = 0; n < mas.Count(); n++)
                    {
                        if (n + 1 < mas.Count())
                        {
                            Set_value_relation(mas[n], mas[n + 1], "==", relation);
                        }
                    }
                }
            }
        }


        public void Initial_relation_state2()
        {
            for (int i = 0; i < List_Rules.Count; i++)
            {
                for (int j = 0; j < List_Rules[i].Get_size_Values_Rules(); j++)
                {
                    string str = List_Rules[i].Values_Rules1[j];
                    str = str.Substring(1, str.Length - 1);
                    int index = str.IndexOf(' ');
                    if (index == -1)
                    {
                        index = str.Count();
                    }

                    Set_value_relation(List_Rules[i].Name_Rules1, str.Substring(0, index), "F", First);
                }
            }

            for (int i = 0; i < relation.Columns.Count - 1; i++)
            {
                Initial_relation_state2_2(i, "F", First);
            }
        }

        private void Initial_relation_state2_2(int i, string value, DataTable dt)
        {
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[i][j].ToString() == value)
                {
                    int index = check_value_relation(dt.Columns[j].ColumnName);
                    if (index != -1)
                    {
                        Initial_relation_state2_2(index, value, dt);

                        for (int n = 1; n < dt.Columns.Count; n++)
                        {
                            if (dt.Rows[index][n].ToString() == value)
                            {
                                Set_value_relation(relation.Rows[i][0].ToString(), dt.Columns[n].ColumnName, value, dt);
                            }
                        }
                    }
                }
            }

        }

        public void Initial_relation_state3()
        {
            for (int i = 0; i < List_Rules.Count; i++)
            {
                for (int j = 0; j < List_Rules[i].Get_size_Values_Rules(); j++)
                {
                    string str = List_Rules[i].Values_Rules1[j];

                    int index = str.LastIndexOf(' ');
                    Set_value_relation(List_Rules[i].Name_Rules1, str.Substring(index + 1, str.Count() - index - 1), "L", Last);
                }
            }

            for (int i = 0; i < relation.Columns.Count - 1; i++)
            {
                Initial_relation_state2_2(i, "L", Last);
            }
        }

        public void Initial_relation_state2_3()
        {
            for (int i = 0; i < relation.Rows.Count; i++)
            {
                for (int j = 1; j < relation.Columns.Count; j++)
                {
                    int index = check_value_relation(relation.Columns[j].ColumnName);

                    if (relation.Rows[i][j].ToString() == "==" && index != -1)
                    {
                        for (int n = 1; n < relation.Columns.Count; n++)
                        {
                            if (First.Rows[index][n].ToString() == "F")
                            {
                                Set_value_relation(relation.Rows[i][0].ToString(), relation.Columns[n].ColumnName, "<=", relation);
                            }
                        }
                    }
                }
            }
        }

        public void Initial_relation_state2_4()
        {
            for (int j = 1; j < relation.Columns.Count; j++)
            {
                for (int i = 0; i < relation.Rows.Count; i++)
                {
                    int index = check_value_relation(relation.Rows[i][0].ToString());

                    if (relation.Rows[i][j].ToString() == "==" && index != -1)
                    {
                        for (int n = 1; n < relation.Columns.Count; n++)
                        {
                            if (Last.Rows[index][n].ToString() == "L")
                            {
                                Set_value_relation(relation.Columns[n].ColumnName, relation.Columns[j].ColumnName, "=>", relation);
                            }
                        }
                    }
                }
            }
        }


        private void Set_value_relation(string a, string b, string c, DataTable d)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                if (d.Rows[i][0].ToString() == a)
                {
                    for (int j = 0; j < d.Rows.Count + 1; j++)
                    {
                        if (d.Columns[j].ColumnName.ToString() == b)
                        {
                            d.Rows[i][j] = c;
                            break;
                        }
                    }

                    break;
                }
            }
        }

        public void Last_relation_state()
        {
            Stack.Columns.Add("Крок");
            Stack.Columns.Add("Стек");
            Stack.Columns.Add("Відношення");
            Stack.Columns.Add("Вхідний ланцюжок");

            List<string> _stack = new List<string>();
            int count = 0;


            for (int i = 0; ; )
            {
                string str;

                if (i == List_Lexem.Count())
                {
                    str = "=>";
                }
                else
                {
                    if (_stack.Count() - 1 >= 0)
                    {
                        str = get_value_relation(_stack[_stack.Count() - 1], List_Lexem[i].Subcategory);
                    }
                    else
                    {
                        str = "<=";
                    }
                }

                



                if (str != "=>")
                {
                    _stack.Add(List_Lexem[i].Subcategory);
                    
                    i++;
                }
                else
                {
                    List<string> mas = new List<string>();
                    for (int j = _stack.Count() - 1; j > 0; j--)
                    {
                        string str1 = get_value_relation(_stack[j - 1], _stack[j]);
                        mas.Add(_stack[j]);

                        if (str1 == "<=")
                        {
                            break;
                        }

                        if (j - 1 == 0)
                        {
                            mas.Add(_stack[j - 1]);
                        }
                    }

                    mas.Reverse();

                    bool check = false;
                    for (int n = 0; n < List_Rules.Count(); n++)
                    {
                        for (int k = 0; k < List_Rules[n].Get_size_Values_Rules(); k++)
                        {
                            string[] mas1 = List_Rules[n].Values_Rules1[k].Split();

                            check = true;

                            if (mas1.Count() - 1 == mas.Count())
                            {
                                for (int q = 0; q < mas.Count(); q++)
                                {
                                    if (mas1[q + 1] != mas[q])
                                    {
                                        check = false;
                                    }
                                }
                            }
                            else
                            {
                                check = false;
                            }

                            if (check)
                            {
                                _stack.RemoveRange(_stack.Count - mas.Count(), mas.Count());
                                _stack.Add(List_Rules[n].Name_Rules1);
                                break;
                            }
                        }

                        if(check)
                        {
                            break;
                        }
                    }

                    if (!check)
                    {
                        MessageBox.Show("It is not possible to continue to program the program", "Error");
                        break;
                    }
                    
                }

                if (str == "-1")
                {
                    MessageBox.Show("It is not possible to continue to program the program", "Error");
                    break;
                }

                string a = string.Empty;
                string b = string.Empty;

                for (int j = 0; j < _stack.Count(); j++)
                {
                    a += _stack[j] + " ";
                }

                for (int j = i, n = 0; j < List_Lexem.Count() && n < 10; j++, n++)
                {
                    b += List_Lexem[j].Subcategory + " ";
                }

                if (i == List_Lexem.Count())
                {
                    str = "=>";
                }
                else
                {
                    str = get_value_relation(_stack[_stack.Count() - 1], List_Lexem[i].Subcategory);
                }

                if (b == string.Empty)
                {
                    b = "#";
                }

                count++;
                
                if (_stack[_stack.Count - 1] != "Z")
                {
                    Stack.Rows.Add(count, a, str, b);
                }
                else
                {
                    Stack.Rows.Add(count, a, "", b);
                }

                if (_stack[_stack.Count - 1] == "Z")
                {
                    break;
                }
            }
        }

        private int check_value_relation(string b)
        {
            if (b == string.Empty)
            {
                return -1;
            }

            for (int i = 0; i < List_Rules.Count; i++)
            {
                if (List_Rules[i].Name_Rules1 == b)
                {
                    for (int j = 1; j < relation.Columns.Count; j++)
                    {
                        if (relation.Columns[j].ColumnName == b)
                        {
                            return j - 1;
                        }
                    }
                }
            }
            return -1;
        }


        private string get_value_relation(string a, string b)
        {
            for (int i = 0; i < relation.Rows.Count; i++)
            {
                if (relation.Rows[i][0].ToString() == a)
                {
                    for (int j = 1; j < relation.Rows.Count + 1; j++)
                    {
                        if (relation.Columns[j].ColumnName.ToString() == b)
                        {
                            return relation.Rows[i][j].ToString();
                        }
                    }
                }
            }
            return "-1";
        }


        public DataTable Get_Data()
        {
            return relation;
        }

        public DataTable Get_First()
        {
            return First;
        }

        public DataTable Get_Last()
        {
            return Last;
        }

        public DataTable Get_Stack()
        {
            return Stack;
        }
    }
}
