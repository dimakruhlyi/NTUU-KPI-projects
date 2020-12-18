using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;


namespace Coursework
{
    class Debug_Lexem : ListGram
    {
        protected List<Lexems> List_Lexem = new List<Lexems>();
        protected List<Const> List_Const = new List<Const>();
        protected List<ID> List_Id = new List<ID>();
        protected DataTable error_message = new DataTable();

        bool check_type = false;
        protected bool check_error = false;

        string type = string.Empty;

        public Debug_Lexem(string str)
        {
            int count = 1;
            string word = "";
            int i = 0;
            error_message.Columns.Add("Line");
            error_message.Columns.Add("Detalis");

            str += " ";
            string tmp_str = "\n\t =!,:;+-*/{}()<>";
            while (i < str.Length)
            {
                int index = tmp_str.IndexOf(str[i]);
                switch (index)
                {
                    case 0:
                        if (word.Length != 0)
                        {
                            find_index_lexem(word, count);
                        }
                        count++;
                        word = "";
                        break;

                    case 1:
                    case 2:
                        if (word.Length != 0)
                        {
                            find_index_lexem(word, count);
                        }
                        word = "";
                        break;

                    case 3:
                        if (word.Length != 0)
                        {
                            find_index_lexem(word, count);
                        }

                        if (equals(str, ref i))
                        {
                            find_index_lexem("==", count);
                        }
                        else
                        {
                            find_index_lexem("=", count);
                        }
                        word = "";
                        break;

                    case 4:
                        if (word.Length != 0)
                        {
                            find_index_lexem(word, count);
                        }

                        if (equals(str, ref i))
                        {
                            find_index_lexem("!=", count);
                        }
                        else
                        {
                            error("Invalid character: '!'", count.ToString());
                        }
                        word = "";
                        break;

                    case -1:

                        word += str[i];


                        break;

                    default:
                        if (word.Length != 0)
                        {
                            find_index_lexem(word, count);
                        }
                        find_index_lexem(tmp_str[index].ToString(), count);
                        word = "";
                        break;
                }
                i++;
            }


        }

        private void check_typeed_type(string str)
        {
            switch (str)
            {
                case "int":
                    type = "int";
                    check_type = true;
                    break;

                case "float":
                    type = "float";
                    check_type = true;
                    break;

                case "program":
                    type = "program";
                    check_type = true;
                    break;

                case "const":
                    type = "const";
                    check_type = true;
                    break;

                case ";":
                case "{":
                    type = string.Empty;
                    check_type = false;
                    break;

                case ",":
                    check_type = true;
                    break;

                case "=":
                    check_type = false;
                    break;
            }
        }

        public void find_index_lexem(string str, int count)
        {
            int index = Find_Lexem(str);
            if (index != 0)
            {
                List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = index, Key = "" });
                check_typeed_type(str);
            }
            else
            {
                if (verify_const(str))
                {
                    int index_const = IndexOf_name(List_Const, str);

                    if (index_const == -1)
                    {
                        List_Const.Add(new Const() { Index_const = List_Const.Count + 1, Name = str });
                        index_const = List_Const.Count;
                    }

                    List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = Find_Lexem("Con"), Key = index_const.ToString() });
                }
                else
                {
                    if (verify_id(str))
                    {
                        int index_id;
                        int index_;

                        if (type == "const")
                        {
                            index_id = IndexOf_name(List_Const, str);
                            index_ = IndexOf_name(List_Id, str);
                        }
                        else
                        {
                            index_id = IndexOf_name(List_Id, str);
                            index_ = IndexOf_name(List_Const, str);
                        }

                        if (index_id == -1 && index_ == -1)
                        {
                            if (type == string.Empty)
                            {
                                error("Необ'явлений ідентифікатор", count.ToString());
                                check_type = false;
                            }

                            if (type != string.Empty && !check_type)
                            {
                                error("Необ'явлений ідентифікатор", count.ToString());
                                check_type = false;
                            }

                            if (check_type)
                            {
                                if (type == "const")
                                {
                                    List_Const.Add(new Const() { Index_const = List_Const.Count + 1, Name = str });
                                    index_id = List_Const.Count;
                                }
                                else
                                {
                                    if (type == "program")
                                    {
                                        if (List_Id.Count == 0)
                                        {
                                            List_Id.Add(new ID() { Index_id = List_Id.Count + 1, Name = str, Type = type, Value = "NULL" });
                                            index_id = List_Id.Count;
                                        }
                                        else
                                        {
                                            error("Недоступне ключове слово program", count.ToString());
                                        }
                                    }
                                    else
                                    {
                                        List_Id.Add(new ID() { Index_id = List_Id.Count + 1, Name = str, Type = type });
                                        index_id = List_Id.Count;
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (type != string.Empty && check_type)
                            {
                                error("Переопреділений ідентифікатор: " + str, count.ToString());
                            }
                        }

                        if (type != "const")
                        {
                            if (index_id != -1)
                            {
                                List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = Find_Lexem("Idn"), Key = index_id.ToString() });
                            }
                            else
                            {
                                List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = Find_Lexem("Con"), Key = index_.ToString() });
                            }
                        }
                        else
                        {
                            if (index_id != -1)
                            {
                                List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = Find_Lexem("Con"), Key = index_id.ToString() });
                            }
                            else
                            {
                                List_Lexem.Add(new Lexems() { Line = count, Subcategory = str, Index = Find_Lexem("Idn"), Key = index_.ToString() });
                            }
                        }
                    }
                    else
                    {
                        error("Invalid character: '" + str + "'", count.ToString());
                    }
                }
            }
        }


        public bool equals(string str, ref int i)
        {
            if (str[i + 1] == '=')
            {
                i++;
                return true;
            }
            return false;
        }

        public bool verify_const(string str)
        {
            Regex myRegex = new Regex("^[0-9]+$|^[0-9]+[.]?[0-9]+$|^-[0-9]+$|^-[0-9]+[.]?[0-9]+$", RegexOptions.Singleline);

            if (myRegex.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public bool verify_id(string str)
        {
            Regex myRegex = new Regex("^[A-Za-z][A-Za-z0-9_]*$|^[_]+[A-Za-z0-9_]+$");

            if (myRegex.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public List<Lexems> table_lexem()
        {
            return List_Lexem;
        }

        public List<Const> table_const()
        {
            return List_Const;
        }

        public List<ID> table_id()
        {
            return List_Id;
        }

        public int IndexOf_name(List<Const> exemple, string str)
        {
            for (int i = 0; i < exemple.Count; i++)
            {
                if (exemple[i].Name == str)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public int IndexOf_name(List<ID> exemple, string str)
        {
            for (int i = 0; i < exemple.Count; i++)
            {
                if (exemple[i].Name == str)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public void error(string str, string count)
        {
            error_message.Rows.Add(count, str);
            check_error = true;
        }

        public DataTable Get_error_message()
        {

            for (int i = 0; i < error_message.Rows.Count - 1; i++)
            {
                for (int j = i + 1; j < error_message.Rows.Count;)
                {
                    if (error_message.Rows[i][0].ToString() == error_message.Rows[j][0].ToString() && error_message.Rows[i][1].ToString() == error_message.Rows[j][1].ToString())
                    {
                        error_message.Rows.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return error_message;
        }

        public int Get_count_Lexem()
        {
            return List_Lexem.Count();
        }

        public bool get_check_error()
        {
            return check_error;
        }

        public string get_lexem(int i)
        {
            return List_Lexem[i].Subcategory;
        }
    }
}