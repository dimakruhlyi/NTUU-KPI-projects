using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1
{
    class Debug_Syntax_1 : Debug_Lexem_0
    {
        string value_for_delimiter = string.Empty;
        int count_bracket = 0;


        public Debug_Syntax_1(string str) : base(str)
        {
            if (check_error)
            {
                return;
            }

            if (List_Lexem.Count == 0)
            {
                return;
            }
            int i = 0;

            if (return_lexem_Subcategory(i) == "program")
            {
                next_index(ref i);

                if (return_lexem_Subcategory(i) == "Idn")
                {
                    next_index(ref i);
                    if (return_lexem_Subcategory(i) == "{")
                    {
                        next_index(ref i);

                        if (List_Lexem.Count - 1 != i)
                        {
                            ListOp(ref i);

                            if (count_bracket < 0)
                            {
                                error("Неправельний порядок дужок", "");
                                next_index(ref i);

                                if (List_Lexem.Count - 1 != i)
                                {
                                    ListOp(ref i);
                                }
                            }
                            else
                            {
                                if (count_bracket != 0)
                                {
                                    error("Кількість дужок: {} неспівпадає", "");

                                    if (List_Lexem.Count - 1 != i)
                                    {
                                        ListOp(ref i);
                                    }
                                }
                            }
                        }

                        if (return_lexem_Subcategory(i) != "}")
                        {
                            error("Невірно завершено програму: ", List_Lexem[List_Lexem.Count - 1].Line.ToString());
                        }
                    }
                    else
                    {
                        error("Очікується початок програми", List_Lexem[i].Line.ToString());
                    }
                }
                else
                {
                    error("Очікується назва програми", List_Lexem[i].Line.ToString());
                }
            }
            else
            {
                error("Пропущено ключове слово program", List_Lexem[i].Line.ToString());
            }
        }


        public bool ListOp(ref int i)
        {
            while (return_lexem_Subcategory(i) != "}")
            {
                switch (return_lexem_Subcategory(i))
                {
                    case "read":
                        Op_Read_Write(ref i, false);
                        break;

                    case "write":
                        Op_Read_Write(ref i, true);
                        break;

                    case "int":
                    case "float":
                        Op_initial_type(ref i);
                        break;

                    case "const":
                        Op_initial_type_const(ref i);
                        break;

                    case "Idn":
                        Op_Idn(ref i);
                        break;

                    case "for":
                        Op_Loop(ref i);
                        break;

                    case "if":
                        Op_If(ref i);
                        break;

                    default:
                        error("Невірний оператор", List_Lexem[i].Line.ToString());
                        break;
                }

                if (i == List_Lexem.Count - 1)
                {
                    break;
                }
                next_index(ref i);
            } 

            
            if (List_Lexem.Count - 1 != i)
            {
                count_bracket--;
            }

            
            return true;
        }

        private bool ListId(ref int i, bool checked_const)
        {
            if (return_lexem_Subcategory(i) == "Idn" || (return_lexem_Subcategory(i) == "Con" && checked_const))
            {
                next_index(ref i);
                while (List_Lexem[i].Subcategory == ",")
                {
                    next_index(ref i);

                    if (return_lexem_Subcategory(i) == "Idn" || (return_lexem_Subcategory(i) == "Con" && checked_const))
                    {
                        next_index(ref i);
                    }
                    else
                    {
                        error("Після коми потрібний ідентифікатор або константа", List_Lexem[i].Line.ToString());
                        return false;
                    }
                }
            }
            else
            {
                if (checked_const)
                {
                    error("Потрібний ідентифікатор або константа", List_Lexem[i].Line.ToString());
                }
                else
                {
                    error("Потрібний ідентифікатор", List_Lexem[i].Line.ToString());
                }

                return false;
            }

            return true;
        }

        
        private void expression_initial_state(ref int i, ref int count_bracket)
        {
            next_index(ref i);

            switch (return_lexem_Subcategory(i))
            {
                case "+":
                case "-":
                    expression_first_state(ref i, ref count_bracket);
                    
                    break;

                case "(":
                    count_bracket++;
                    expression_initial_state(ref i, ref count_bracket);
                    

                    break;

                case "Idn":
                case "Con":
                    expression_second_state(ref i, ref count_bracket);
                    
                    break;

                default:
                    error("Потрібний ідентифікатор після =", List_Lexem[i].Line.ToString());
                    return;
            }

            return;
        }

        private void expression_first_state(ref int i, ref int count_bracket)
        {
            next_index(ref i);

            switch (return_lexem_Subcategory(i))
            {
                case "Idn":
                case "Con":
                    expression_second_state(ref i, ref count_bracket);
                    
                    break;

                case "(":
                    count_bracket++;
                    expression_initial_state(ref i, ref count_bracket);
                    
                    break;

                default:
                    error("Потрібний ідентифікатор або константа", List_Lexem[i].Line.ToString());
                    return;
            }

            return;
        }

        private void expression_second_state(ref int i, ref int count_bracket)
        {
            next_index(ref i);

            switch (return_lexem_Subcategory(i))
            {
                case "*":
                case "/":
                case "^":
                case "=":
                    expression_initial_state(ref i, ref count_bracket);
                    break;

                case "+":
                case "-":
                    expression_first_state(ref i, ref count_bracket);

                    break;

                case ")":
                    if (count_bracket < 0)
                    {
                        error("В даному контексті недоступно )", List_Lexem[i].Line.ToString());
                        return;
                    }

                    count_bracket--;
                    expression_second_state(ref i, ref count_bracket);
                    break;

                case ";":
                    if (count_bracket != 0)
                    {
                        error("Невірна кількість дужок ()", List_Lexem[i].ToString());
                        return;
                    }
                    break;

                case ",":
                case "step":
                case "to":
                case "{":
                case "==":
                case "!=":
                case ">":
                case "<":
                    if (value_for_delimiter == string.Empty)
                    {
                        error("Потрібний ;", List_Lexem[i].Line.ToString());
                    }
                    else
                    {
                        if (count_bracket != 0)
                        {
                            error("Невірна кількість дужок ()", List_Lexem[i].ToString());
                            return;
                        }
                        return;
                    }
                    break;

                default:
                    error("Потрібний ;", List_Lexem[i].Line.ToString());
                    return;
            }

            return;
        }


        private void Op_initial_type(ref int i)
        {
            do
            {
                next_index(ref i);

                if (return_lexem_Subcategory(i) != "Idn")
                {

                    error("Потрібний ідентифікатор", List_Lexem[i].Line.ToString());
                    return;

                }

                next_index(ref i);


                if (return_lexem_Subcategory(i) == "=")
                {
                    int count = 0;
                    value_for_delimiter = ",";
                    expression_initial_state(ref i, ref count);

                    //if (!expression_initial_state(ref i, ref count))
                    //{
                    //    return;
                    //}
                    value_for_delimiter = string.Empty;
                }

                if (return_lexem_Subcategory(i) == ";")
                {
                    return;
                }

                //if (return_lexem_Subcategory(i) == ",")
                //{
                //    Op_initial_type(ref i);
                //}
                //else
                //{
                //    error("Невірний оператор", List_Lexem[i].Line.ToString());
                //}

            } while (return_lexem_Subcategory(i) == ",");

            error("Невірний оператор", List_Lexem[i].Line.ToString());
            return;
        }

        private void Op_initial_type_const(ref int i)
        {
            next_index(ref i);
            
            if (return_lexem_Subcategory(i) != "Con")
            {
                next_index(ref i);
                error("Потрібний ідентифікатор", List_Lexem[i].Line.ToString());
                return;

            }
            next_index(ref i);


            if (return_lexem_Subcategory(i) == "=")
            {
                int count = 0;
                value_for_delimiter = ",";
                expression_initial_state(ref i, ref count);
                value_for_delimiter = string.Empty;
            }
            else
            {
                error("Потрібно ініціалізувати змінну", List_Lexem[i].Line.ToString());
            }

            if (return_lexem_Subcategory(i) == ";")
            {
                return;
            }

            if (return_lexem_Subcategory(i) == ",")
            {
                Op_initial_type_const(ref i);
            }
            else
            {
                error("Потрібний", List_Lexem[i].Line.ToString());
            }

        }

        private void Op_Read_Write(ref int i, bool checked_const)
        {
            next_index(ref i);

            if (List_Lexem[i].Subcategory == "(")
            {
                next_index(ref i);

                if (ListId(ref i, checked_const))
                {
                    

                    if (List_Lexem[i].Subcategory == ")")
                    {
                        next_index(ref i);

                        if (List_Lexem[i].Subcategory != ";")
                        {
                            error("Потрібний символ в кінці оператора: ;", List_Lexem[i].Line.ToString());
                        }
                    }
                    else
                    {
                        error("Потрібна закриваюча дужка: )", List_Lexem[i].Line.ToString());
                    }
                }
                else
                {
                    error("Неправельний списк ідентифікаторів", "");
                }
            }
            else
            {
                error("Потрібна відкриваюча дужка: (", "");
            }
        }

        private void Op_Idn(ref int i)
        {
            next_index(ref i);

            if (return_lexem_Subcategory(i) == "=")
            {
                int a = 0;
                expression_initial_state(ref i, ref a);
            }
            else
            {
                error("В якості оператора недоступний даний запис", List_Lexem[i].Line.ToString());
            }
        }

        private void Op_Loop(ref int i)
        {
            value_for_delimiter = "to";
            next_index(ref i);

            if (return_lexem_Subcategory(i) == "Idn")
            {
                Op_Idn(ref i);

                if (return_lexem_Subcategory(i) == "to")
                {
                    int count = 0;
                    value_for_delimiter = "step";
                    expression_initial_state(ref i, ref count);

                    if (return_lexem_Subcategory(i) == "step")
                    {
                        count = 0;
                        value_for_delimiter = "{";
                        expression_initial_state(ref i, ref count);
                        value_for_delimiter = string.Empty;


                        if (return_lexem_Subcategory(i) == "{")
                        {
                            count_bracket++;
                            next_index(ref i);
                            ListOp(ref i);
                        }
                        else
                        {
                            error("Має бути '{'", List_Lexem[i].Line.ToString());
                        }
                    }
                    else
                    {
                        error("Має бути ключове слово 'step'", List_Lexem[i].Line.ToString());
                    }
                }
                else
                {
                    error("Має бути ключове слово 'to'", List_Lexem[i].Line.ToString());
                }
            }
            else
            {
                error("Потрібний ідентифікатор", List_Lexem[i].Line.ToString());
            }
        }

        private void Op_If(ref int i)
        {
            int count = 0;
            value_for_delimiter = ">";
            expression_initial_state(ref i, ref count);

            value_for_delimiter = "{";
            expression_initial_state(ref i, ref count);

            if (return_lexem_Subcategory(i) == "{")
            {
                next_index(ref i);
                count_bracket++;
                ListOp(ref i);

                if (i + 1 < List_Lexem.Count && return_lexem_Subcategory(i + 1) == "else")
                {
                    next_index(ref i);
                }

                if (return_lexem_Subcategory(i) == "else")
                {
                    next_index(ref i);
                    if (return_lexem_Subcategory(i) == "{")
                    {
                        next_index(ref i);
                        count_bracket++;
                        ListOp(ref i);
                    }
                    else
                    {
                        error("Невірний запис", "");
                    }
                }
            }
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

        private int next_index(ref int i)
        {
            if (i < List_Lexem.Count - 1)
            {
                i++;
            }

            return i;
        }
    }
}