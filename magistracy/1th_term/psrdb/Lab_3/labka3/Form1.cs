using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labka3.ComServer
{
    public partial class Form1 : Form
    {
        Object ComSrv;
        Type type;
        string constr;
        MethodInfo mi;

        public Form1()
        {
            InitializeComponent();
            constr = @"Provider=SQLOLEDB;Data Source=CHARON;Integrated Security=SSPI;Initial Catalog=Laba3Data";
            type = Type.GetTypeFromProgID("ComServer.DBComServer");
            if (type != null)
            {
                ComSrv = Activator.CreateInstance(type);
                if (ComSrv != null)
                {
                    mi = type.GetMethod("GetTables");
                    List<string> ls = (List<string>)mi.Invoke(ComSrv, new object[] { constr, "Laba3Data" });
                    foreach (string s in ls)
                        comboBox1.Items.Add(s);
                    MessageBox.Show("ComServer is created");
                }
                else
                    MessageBox.Show("ComServer is not created");
            }
            else
            {
                MessageBox.Show("ComServer type is not found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c;
            if (radioButton1.Checked == true)
            {
                mi = type.GetMethod("Hypo");
                c = (double)mi.Invoke(ComSrv, new object[] { a, b });
                label1.Text = c.ToString();                
            }
            else
            {
                mi = type.GetMethod("Sum");
                c = (double)mi.Invoke(ComSrv, new object[] { a, b });
                label1.Text = c.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mi = type.GetMethod("GetTable");
            DataTable dt = (DataTable)mi.Invoke(ComSrv, new object[] { constr, comboBox1.Text });
            dataGridView1.DataSource = dt;
        }
    }
}
