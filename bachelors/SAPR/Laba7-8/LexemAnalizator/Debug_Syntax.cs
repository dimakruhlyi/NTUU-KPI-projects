using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
    class Debug_Syntax : Debug_Lexem
    {
        List<Table_transitions> table_MPA = new List<Table_transitions>();
        List<int> Stack = new List<int>();
        int state_last = 1;
        int index_last = 0;

        int present_token = 0;
        List<int> Stack3 = new List<int>();
        int Count_stack = 0;
        int next_state = 1;

        string erro = string.Empty;

        public Debug_Syntax(string str) : base(str)
        {
            if (get_check_error() == false)
            {
                MessageBox.Show("Успішне аналізування лексем!");


                Initial_table_MPA();

                if (List_Lexem.Count() > 1)
                {
                    if (List_Lexem[0].Subcategory != "program")
                    {
                        error("Not enough 'program'", List_Lexem[0].Line.ToString());
                    }
                    else
                    {
                        Start_Syntax();
                    }
                }
            }
        }

        private void Start_Syntax()
        {
            bool check = true;
            int count = 0;

            for (int i = 0; i < List_Lexem.Count(); i++)
            {
                if (List_Lexem[i].Subcategory == "{")
                {
                    count++;
                }

                if (List_Lexem[i].Subcategory == "}")
                {
                    count--;
                }
            }

            if (count > 0)
            {
                error("Not enough '}'", List_Lexem[List_Lexem.Count() - 1].Line.ToString());
                count++;
                check = false;
            }


            while (check)
            {
                if (get_check_error())
                {
                    check = false;
                }

                if (present_token < Get_count_Lexem())
                {
                    next_state = next_step(next_state, present_token);

                    if (next_state == 0 && Count_stack == 0 && present_token + 1 == Get_count_Lexem())
                    {
                        check = false;
                    }
                }

                if (error_message.Rows.Count == 0 && Count_stack <= Get_count() && present_token < Get_count_Lexem() - 1)
                {
                    present_token++;
                }

                Stack3 = Get_Stack();
                Count_stack = Get_count();

                if (Count_stack == 0 && present_token == Get_count_Lexem() - 1 && count == 1)
                {
                    if (next_state != 0)
                    {
                        error("Not enough '}'", List_Lexem[List_Lexem.Count() - 1].Line.ToString());
                        check = false;
                    }
                }

                if (present_token == Get_count_Lexem() - 1 && Count_stack == 0)
                {
                    count++;
                }
            }
        }

        public int next_step(int next_state, int i)
        {
            int count = 0;
            for (int j = 0; j < table_MPA.Count(); j++)
            {
                if (table_MPA[j].Current_state1 == next_state)
                {
                    count = j;
                    break;
                }
            }
           
            bool error1 = true;

            do
            {
                if (return_lexem_Subcategory(i) == table_MPA[count].Mitka1)
                {
                    next_state = table_MPA[count].Next_state1;
                    if (table_MPA[count].Stack1 != string.Empty)
                    {
                        Stack.Add(Convert.ToInt32(table_MPA[count].Stack1));
                    }

                    erro = string.Empty;
                    error1 = false;
                    break;
                }
                count++;

            } while (table_MPA.Count > count && table_MPA[count].Current_state1 == next_state);


            if (count >= table_MPA.Count())
            {
                count = table_MPA.Count() - 1;
            }
            int w = count;
            if (error1)
            {
                if (Stack.Count() != 0)
                {
                    next_state = Stack[Stack.Count - 1];
                    Stack.RemoveAt(Stack.Count - 1);

                    erro = table_MPA[state_last].Subroutine1.ToString();
                }
                else
                {
                    if (erro == string.Empty)
                    {
                        error(table_MPA[state_last].Subroutine1, List_Lexem[index_last].Line.ToString());
                    }
                    else
                    {
                        error(erro, List_Lexem[index_last].Line.ToString());
                    }
                }
            }

            index_last = i;
            state_last = w;
            return next_state;
        }

        public string getValue()
        {
            return table_MPA[state_last].Subroutine1.ToString();
        }

        public string getValue1()
        {
            return erro;
        }

        public void setError()
        {
            error("Not enough '}'", List_Lexem[List_Lexem.Count() - 1].Line.ToString());
        }



        public void restart()
        {
            state_last = 1;
            index_last = 0;
            Stack = new List<int>();
        }

        private void Initial_table_MPA()
        {
            FileStream file = new FileStream("MPA.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                string[] mas = str.Split();

                if (mas.Count() >= 5)
                {
                    for (int i = 5; i < mas.Count(); i++)
                    {
                        mas[4] += " " + mas[i];
                    }
                }

                table_MPA.Add(new Table_transitions() { Current_state1 = Convert.ToInt32(mas[0]), Mitka1 = mas[1], Next_state1 = Convert.ToInt32(mas[2]), Stack1 = mas[3], Subroutine1 = mas[4] });
            }

            reader.Close();
        }

        public List<Table_transitions> Get_MPA()
        {
            return table_MPA;
        }

        private string return_lexem_Subcategory(int i)
        {
            string value = List_Lexem[i].Subcategory;
            if (List_Lexem[i].Index == Find_Lexem("Idn"))
            {
                value = "Idn";
            }

            if (List_Lexem[i].Index == Find_Lexem("Con"))
            {
                value = "Con";
            }
            return value;
        }

        public List<int> Get_Stack()
        {
            return Stack;
        }

        public int Get_count()
        {
            return Stack.Count();
        }
    }
}