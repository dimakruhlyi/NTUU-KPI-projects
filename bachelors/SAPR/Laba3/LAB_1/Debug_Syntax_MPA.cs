using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB_1
{
    class Debug_Syntax_MPA : Debug_Lexem
    {
        List<Table_transitions> table_MPA = new List<Table_transitions>();
        List<int> Stack = new List<int>();
        List<string> erro = new List<string>();
        int state = 1;

        public Debug_Syntax_MPA(string str) : base(str)
        {
            Initial_table_MPA();

            //int next_state = 1;
            //for (int i = 0; i < List_Lexem.Count(); i++)
            //{
            //    if (List_Lexem[i].Subcategory == table_MPA[next_state].Mitka1)
            //    {
            //    }
            //}
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

                    if (erro.Count >= 1)
                    {
                        erro.RemoveAt(erro.Count - 1);
                    }

                    error1 = false;
                    break;
                }
                count++;

            } while (table_MPA.Count > count && table_MPA[count].Current_state1 == next_state);

            if (Stack.Count() != 0 && next_state == Stack[Stack.Count() - 1])
            {
                //Stack.RemoveAt(Stack.Count - 1);
            }

            if (count >= table_MPA.Count())
            {
                count = table_MPA.Count() - 1;
            }
            
            if (error1)
            {
                if (Stack.Count() != 0 && erro.Count() < 1)
                {
                    next_state = Stack[Stack.Count - 1];
                    Stack.RemoveAt(Stack.Count - 1);
                    erro.Add(table_MPA[count].Subroutine1);
                }
                else
                {
                    if (erro.Count() != 0)
                    {
                        error(erro[0], List_Lexem[i].Line.ToString());
                    }
                    else
                    {
                        error(table_MPA[count - 1].Subroutine1, List_Lexem[i].Line.ToString());
                    }
                }
            }

            state = count;
            return next_state;
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


//63 { 51 64 required character
//{
//64 } 51  required character }
//65 else 63 51 error