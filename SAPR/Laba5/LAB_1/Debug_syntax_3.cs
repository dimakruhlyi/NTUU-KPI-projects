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
    class Debug_syntax_3 : Debug_Lexem_0
    {
        DataTable fieldRelationship = new DataTable(); // Field relation
        DataTable First = new DataTable(); // Field of first lexem
        DataTable Last = new DataTable(); // Field of last lexem
        DataTable Stack = new DataTable(); // Stack for syntax analyzer

        List<Rules> List_Rules = new List<Rules>();


        List<string> rq = new List<string>();



        //Constructor of class
        public Debug_syntax_3(string str) : base(str)
        {
            Initial_List_Rules();

            First.Columns.Add(" ");
            Last.Columns.Add(" ");

            for (int i = 1; i < fieldRelationship.Columns.Count; i++)
            {
                First.Columns.Add(fieldRelationship.Columns[i].ColumnName);
                First.Rows.Add(fieldRelationship.Columns[i].ColumnName);

                Last.Columns.Add(fieldRelationship.Columns[i].ColumnName);
                Last.Rows.Add(fieldRelationship.Columns[i].ColumnName);
            }

            stanEquals();
        }
               
        //Initial rules
        private void Initial_List_Rules()
        {
            fieldRelationship.Columns.Add(" ");
            FileStream file = new FileStream("Simple_Forward1.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string readOneRule = reader.ReadLine();
                int index = readOneRule.IndexOf(' ');
                string Name_str = readOneRule.Substring(0, index);
                readOneRule = readOneRule.Remove(0, index + 2);

                string[] valueRule = readOneRule.Split(new char[] { '|', '&' }, StringSplitOptions.RemoveEmptyEntries);

                List_Rules.Add(new Rules { Name_Rules1 = Name_str, Values_Rules1 = valueRule });


                for (int i = 0; i < valueRule.Count(); i++)
                {
                    string[] splitRule = readOneRule.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int q = 0; q < splitRule.Count(); q++)
                    {
                        bool checkAvailability = true;
                        for (int j = 0; j < fieldRelationship.Columns.Count && checkAvailability; j++)
                        {
                            if (fieldRelationship.Columns[j].ColumnName == splitRule[q])
                            {
                                checkAvailability = false;
                            }
                        }

                        if (checkAvailability)
                        {
                            fieldRelationship.Columns.Add(splitRule[q]);
                            fieldRelationship.Rows.Add(splitRule[q]);
                        }
                    }
                }
            }

            for (int i = 0; i < List_Rules.Count; i++)
            {
                bool checkAvailability = true;
                for (int j = 0; j < fieldRelationship.Columns.Count && checkAvailability; j++)
                {
                    if (fieldRelationship.Columns[j].ColumnName == List_Rules[i].Name_Rules1)
                    {
                        checkAvailability = false;
                    }
                }

                if (checkAvailability)
                {
                    fieldRelationship.Columns.Add(List_Rules[i].Name_Rules1);
                    fieldRelationship.Rows.Add(List_Rules[i].Name_Rules1);
                }
            }
            
            reader.Close();
        }

        //First stan. Initial relation "==" 
        public void stanEquals()
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
                            setValueFields(mas[n], mas[n + 1], "==", fieldRelationship);
                        }
                    }

                    //if (mas.Count() == 1 && List_Rules[i].Get_size_Values_Rules() == 1)
                    //{
                    //    setValueFields(List_Rules[i].Name_Rules1, mas[0], "==", fieldRelationship);
                    //}

                    //if (mas.Count() == 1 && mas[0].Count() == 1)
                    //{
                    //    setValueFields(List_Rules[i].Name_Rules1, mas[0], "==", fieldRelationship);
                    //}

                    //if (mas.Count() == 1 && mas[0].Count() > 1)
                    //{
                    //    setValueFields(mas[0], List_Rules[i].Name_Rules1, "==", fieldRelationship);
                    //}
                }
            }
        }

        public void stanFind_F()
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

                    setValueFields(List_Rules[i].Name_Rules1, str.Substring(0, index), "F", First);
                }
            }

            for (int i = 0; i < fieldRelationship.Columns.Count - 1; i++)
            {
                rq.Add(First.Rows[i][0].ToString());

                stan_L_F(i, "F", First);
                
                rq.Clear();
            }
        }

        public void stanFind_L()
        {
            for (int i = 0; i < List_Rules.Count; i++)
            {
                for (int j = 0; j < List_Rules[i].Get_size_Values_Rules(); j++)
                {
                    string str = List_Rules[i].Values_Rules1[j];

                    int index = str.LastIndexOf(' ');
                    setValueFields(List_Rules[i].Name_Rules1, str.Substring(index + 1, str.Count() - index - 1), "L", Last);

                    if (index == -1)
                    {
                        index = str.Count();
                    }

                    setValueFields(List_Rules[i].Name_Rules1, str.Substring(0, index), "F", Last);
                }
            }

            for (int i = 0; i < fieldRelationship.Columns.Count - 1; i++)
            {
                rq.Add(Last.Rows[i][0].ToString());

                stan_L_F(i, "L", Last);

                rq.Clear();
            }
        }

        private void stan_L_F(int i, string value, DataTable dt)
        {
            for (int j = 1; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[i][j].ToString() == value)
                {
                    int index = check_value_relation(dt.Columns[j].ColumnName);

                    bool check = true;
                    for (int q = 0; q < rq.Count() && check; q++)
                    {
                        if (dt.Columns[j].ColumnName == rq[q])
                        {
                            check = false;
                        }
                    }

                    if (check && dt.Columns[j].ColumnName == dt.Columns[j].ColumnName.ToUpper())
                    {
                        rq.Add(dt.Columns[j].ColumnName);
                    }

                    if (index != -1 && check)
                    {
                        stan_L_F(index, value, dt);

                        for (int n = 1; n < dt.Columns.Count; n++)
                        {
                            if (dt.Rows[index][n].ToString() == value)
                            {
                                setValueFields(fieldRelationship.Rows[i][0].ToString(), dt.Columns[n].ColumnName, value, dt);
                            }
                        }
                    }
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
                    for (int j = 1; j < fieldRelationship.Columns.Count; j++)
                    {
                        if (fieldRelationship.Columns[j].ColumnName == b)
                        {
                            return j - 1;
                        }
                    }
                }
            }
            return -1;
        }

        //Insert values "==", "<=", "=>" ​​in the fields 
        private void setValueFields(string first, string last, string value, DataTable nameField)
        {
            for (int i = 0; i < nameField.Rows.Count; i++)
            {
                if (nameField.Rows[i][0].ToString() == first)
                {
                    for (int j = 0; j < nameField.Rows.Count + 1; j++)
                    {
                        if (nameField.Columns[j].ColumnName.ToString() == last)
                        {
                            nameField.Rows[i][j] = value;
                            break;
                        }
                    }

                    break;
                }
            }
        }

        public void stan()
        {
            for (int i = 0; i < fieldRelationship.Rows.Count; i++)
            {
                for (int j = 1; j < fieldRelationship.Columns.Count; j++)
                {
                    int index = check_value_relation(fieldRelationship.Columns[j].ColumnName);
                    int index1 = check_value_relation(fieldRelationship.Columns[i + 1].ColumnName);

                    if (fieldRelationship.Rows[i][j].ToString() == "==" && index != -1 && index1 == -1) //  && index != -1
                    {
                        //rq.Add(fieldRelationship.Columns[j].ColumnName);

                        bool check = true;
                        for (int q = 0; q < rq.Count() && check; q++)
                        {
                            if (fieldRelationship.Columns[j].ColumnName == rq[q])
                            {
                                check = false;
                            }
                        }

                        if (check)
                        {
                            rq.Add(fieldRelationship.Columns[j].ColumnName);
                            stan2(index);
                        }

                        for (int q = 0; q < rq.Count; q++)
                        {
                            for (int w = 0; w < fieldRelationship.Rows.Count; w++)
                            {
                                if (rq[q] == fieldRelationship.Rows[w][0].ToString())
                                {
                                    for (int e = 0; e < fieldRelationship.Columns.Count; e++)
                                    {
                                        if (First.Rows[w][e].ToString() == "F")
                                        {
                                            if (fieldRelationship.Rows[i][e].ToString() == "") //----
                                            {
                                                fieldRelationship.Rows[i][e] = "<=";
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        rq.Clear();
                    }
                }
            }
        }

        public void stan1()
        {
            for (int i = 0; i < fieldRelationship.Rows.Count; i++)
            {
                for (int j = 1; j < fieldRelationship.Columns.Count; j++)
                {
                    int index = check_value_relation(fieldRelationship.Columns[j].ColumnName);
                    int index1 = check_value_relation(fieldRelationship.Columns[i + 1].ColumnName);

                    if (fieldRelationship.Rows[i][j].ToString() == "==" && index == -1 && index1 != -1) //  && index == -1
                    {
                        bool check = true;
                        for (int q = 0; q < rq.Count() && check; q++)
                        {
                            if (fieldRelationship.Columns[i + 1].ColumnName == rq[q])
                            {
                                index = q;
                                check = false;
                            }
                        }

                        if (check)
                        {
                            rq.Add(fieldRelationship.Columns[i + 1].ColumnName);
                        }

                        for (int q = 0; q < rq.Count; q++)
                        {
                            for (int w = 0; w < fieldRelationship.Rows.Count; w++)
                            {
                                if (rq[q] == fieldRelationship.Rows[w][0].ToString())
                                {
                                    for (int e = 0; e < fieldRelationship.Columns.Count; e++)
                                    {
                                        if (Last.Rows[w][e].ToString() == "L")
                                        {
                                            if (fieldRelationship.Rows[e - 1][j].ToString() == "") //----
                                            {
                                                fieldRelationship.Rows[e - 1][j] = "=>";
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        rq.Clear();
                    }
                }
            }

            for (int i = 0; i < fieldRelationship.Rows.Count; i++)
            {
                if (fieldRelationship.Rows[i][0].ToString() == "}")
                {
                    //fieldRelationship.Rows[i][i + 1] = "=>";
                    break;
                }
            }
        }

        private void stan2(int i)
        {
            for (int n = 1; n < fieldRelationship.Columns.Count - 1; n++)
            {
                bool check = true;
                for (int q = 0; q < rq.Count() && check; q++)
                {
                    if (fieldRelationship.Columns[n].ColumnName == rq[q])
                    {
                        check = false;
                    }
                }

                if (fieldRelationship.Rows[i][n - 1].ToString() == "==" && fieldRelationship.Columns[n + 1].ColumnName == fieldRelationship.Columns[n + 1].ColumnName.ToUpper() && check)
                {
                    rq.Add(fieldRelationship.Columns[n].ColumnName);
                    stan2(n);
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


            for (int i = 0; ;)
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
                        string a0 = List_Lexem[i].Subcategory;
                        bool checkID = true;
                        for (int q = 0; q < fieldRelationship.Rows.Count && checkID; q++)
                        {
                            if (a0 == fieldRelationship.Rows[q][0].ToString())
                            {
                                checkID = false;
                            }
                        }

                        if (checkID)
                        {
                            if (verify_const(a0))
                            {
                                a0 = "con";
                            }
                            else
                            {
                                a0 = "id";
                            }
                        }

                        str = get_value_relation(_stack[_stack.Count() - 1], a0);
                    }
                    else
                    {
                        str = "<=";
                    }
                }

                if (str != "=>")
                {
                    string a0 = List_Lexem[i].Subcategory;
                    bool checkID = true;
                    for (int q = 0; q < fieldRelationship.Rows.Count && checkID; q++)
                    {
                        if (a0 == fieldRelationship.Rows[q][0].ToString())
                        {
                            checkID = false;
                        }
                    }

                    if (checkID)
                    {
                        if (verify_const(a0))
                        {
                            a0 = "con";
                        }
                        else
                        {
                            a0 = "id";
                        }
                    }
                    _stack.Add(a0);

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

                    if (_stack.Count() - 1 == 0)
                    {
                        mas.Add(_stack[0]);
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

                        if (check)
                        {
                            break;
                        }
                    }

                    if (!check)
                    {
                        MessageBox.Show("ERROR!!!! Program failed!!!", "You have some mistakes!");
                        break;
                    }

                }

                if (str == "-1")
                {
                    MessageBox.Show("ERROR!!!! Program failed!!!", "You have some mistakes!");
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
                    string a0 = List_Lexem[j].Subcategory;
                    bool checkID = true;
                    for (int q = 0; q < fieldRelationship.Rows.Count && checkID; q++)
                    {
                        if (a0 == fieldRelationship.Rows[q][0].ToString())
                        {
                            checkID = false;
                        }
                    }

                    if (checkID)
                    {
                        if (verify_const(a0))
                        {
                            a0 = "con";
                        }
                        else
                        {
                            a0 = "id";
                        }
                    }

                    b += a0 + " ";
                }

                if (i == List_Lexem.Count())
                {
                    str = "=>";
                }
                else
                {
                    string a0 = List_Lexem[i].Subcategory;
                    bool checkID = true;
                    for (int q = 0; q < fieldRelationship.Rows.Count && checkID; q++)
                    {
                        if (a0 == fieldRelationship.Rows[q][0].ToString())
                        {
                            checkID = false;
                        }
                    }

                    if (checkID)
                    {
                        a0 = "id";
                    }

                    str = get_value_relation(_stack[_stack.Count() - 1], a0);
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

        private string get_value_relation(string a, string b)
        {
            for (int i = 0; i < fieldRelationship.Rows.Count; i++)
            {
                if (fieldRelationship.Rows[i][0].ToString() == a)
                {
                    for (int j = 1; j < fieldRelationship.Rows.Count + 1; j++)
                    {
                        if (fieldRelationship.Columns[j].ColumnName.ToString() == b)
                        {
                            return fieldRelationship.Rows[i][j].ToString();
                        }
                    }
                }
            }
            return "-1";
        }

        public DataTable Get_Data()
        {
            return fieldRelationship;
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

