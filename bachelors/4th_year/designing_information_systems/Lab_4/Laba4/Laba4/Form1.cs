using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        Task q;
        string filter1 = "";
        string filter2 = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void departmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.departmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.laba4Database2DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'laba4Database2DataSet.Worker' table. You can move, or remove it, as needed.
            this.workerTableAdapter.Fill(this.laba4Database2DataSet.Worker);
            // TODO: This line of code loads data into the 'laba4Database2DataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.laba4Database2DataSet.Position);
            // TODO: This line of code loads data into the 'laba4Database2DataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.laba4Database2DataSet.Department);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            workerBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            workerBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            workerBindingSource.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            workerBindingSource.MoveLast();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            workerDataGridView.Sort(workerDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            workerDataGridView.Sort(workerDataGridView.Columns[0], ListSortDirection.Descending);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            workerBindingSource.AddNew();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            workerBindingSource.RemoveAt(workerBindingSource.Position);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.workerBindingSource.EndEdit();
                this.tableAdapterManager2.UpdateAll(this.laba4Database2DataSet);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string q = e.KeyChar.ToString();
        //    string w = Keys.Enter.ToString();

        //    if (e.KeyChar == 13)
        //    {
        //        if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) - 1 > 0 && Convert.ToInt32(textBox1.Text) - 1 < workerBindingSource.Count)
        //        {
        //            workerBindingSource.Position = Convert.ToInt32(textBox1.Text) - 1;
        //        }
        //        else
        //        {
        //            workerBindingSource.MoveFirst();
        //            textBox1.Text = "1";
        //        }
        //    }
        //}
        /*-------------------------------------------------------------------------------------------------------------*/
        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string q = e.KeyChar.ToString();
        //    string w = Keys.Enter.ToString();

        //    if (e.KeyChar == 13)
        //    {
        //        if (textBox2.Text != "" && Convert.ToInt32(textBox2.Text) - 1 > 0 && Convert.ToInt32(textBox2.Text) - 1 < positionBindingSource.Count)
        //        {
        //            positionBindingSource.Position = Convert.ToInt32(textBox2.Text) - 1;
        //        }
        //        else
        //        {
        //            positionBindingSource.MoveFirst();
        //            textBox2.Text = "1";
        //        }
        //    }
        //}
        private void button10_Click(object sender, EventArgs e)
        {
            try
            { 
                this.Validate();
                this.positionBindingSource.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.laba4Database2DataSet);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButtons.OK);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            positionBindingSource.RemoveAt(positionBindingSource.Position);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            positionBindingSource.AddNew();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            positionDataGridView.Sort(positionDataGridView.Columns[0], ListSortDirection.Descending);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            positionDataGridView.Sort(positionDataGridView.Columns[0], ListSortDirection.Ascending);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            positionBindingSource.MoveFirst();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            positionBindingSource.MovePrevious();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            positionBindingSource.MoveNext();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            positionBindingSource.MoveLast();
        }
        /*-------------------------------------------------------------------------------------------------------------*/
        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                workerBindingSource.Filter = null;
                filter2 = "";
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                workerBindingSource.Filter = null;
                filter1 = "";
            }
        }
        private void positionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox2.Checked)
            {
                string numberDepartmens = "";
                if (e.RowIndex >= 0 && (int)positionDataGridView.Rows[e.RowIndex].Cells[0].Value > 0)
                {
                    numberDepartmens = positionDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                }

                filter2 = "Position = " + numberDepartmens;

                if (filter1 != "")
                {
                    workerBindingSource.Filter = filter2 + " and " + filter1;
                }
                else
                {
                    workerBindingSource.Filter = filter2;
                }
            }
        }

        private void departmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked)
            {
                string numberDepartmens = "";
                if (e.RowIndex >= 0 && (int)departmentDataGridView.Rows[e.RowIndex].Cells[0].Value > 0)
                {
                    numberDepartmens = departmentDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                }

                filter1 = "department = " + numberDepartmens;

                if (filter2 != "")
                {
                    workerBindingSource.Filter = filter2 + " and " + filter1;
                }
                else
                {
                    workerBindingSource.Filter = filter1;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) - 1 > 0 && Convert.ToInt32(textBox1.Text) - 1 < workerBindingSource.Count)
            {
                
                workerBindingSource.Position = Convert.ToInt32(textBox1.Text) - 1;
            }
            else
            {
                workerBindingSource.MoveFirst();
                textBox1.Text = "1";
            }
        }
    }
}
