using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kursova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = 2e5;

            int Tl = 20;
            int Qp = -1000;
            int Tn = 50;
            int Qv = -1500;
            int Hl = 400;
            int Hn = 100;

            var a = 5e-4;
            int k = 50;
            int T0 = 20;
            int N = 50;
            double h = 0.5 / (double) N;

            double beta = 0.25;
            double dt = h * h * beta / a;
            double Tfin = Convert.ToInt32(textBox1.Text);
            double Nt = Math.Round(Tfin / dt);
            dt = Tfin / Nt;

            double[,] mas = new double[N + 1, N + 1];
            double[,] mas1 = new double[N + 1, N + 1];

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    mas[i, j] = T0;
                }
            }

            DataTable DT = new DataTable();
            for (int i = 0; i <= N; i++)
            {
                DT.Columns.Add("");
            }

            for (int i = 0; i <= N; i++)
            {
                DT.Rows.Add();
            }
            
            for (int n = 0; n < Nt; n++)
            {
                for (int i = 1; i <= N - 1; i++)
                {
                    for (int j = 1; j <= N - 1; j++)
                    {
                        mas1[i, j] = (1 - 4 * beta) * mas[i, j] + beta * 
                            (mas[i - 1, j] + mas[i, j - 1] + mas[i + 1, j] + mas[i, j + 1]) + beta * g * h * h / k;
                    }
                }

                //Ліва
                for (int i = 1; i <= N - 1; i++)
                {
                    double Al = mas[i, 1] + 2 * h * Hl * Tl / k - 2 * h * Hl * mas[i, 0] / k;
                    mas1[i, 0] = (1 - 4 * beta) * mas[i, 0] + beta * (Al + mas[i, 1] + mas[i - 1, 0] + mas[i+1, 0])
                        + beta * g * h * h / k;
                }

                //Нижня
                for (int j = 1; j <= N - 1; j++)
                {
                    double Al = mas[1, j] + 2 * h * Hn * Tn / k - 2 * h * Hn * mas[0, j] / k;
                    mas1[0, j] = (1 - 4 * beta) * mas[0, j] + beta * (Al + mas[1, j] + mas[0, j-1] + mas[0, j +1])
                        + beta * g * h * h / k;
                }

                //Права
                for (int i = 1; i <= N - 1; i++)
                {
                    double Al = mas[i, N - 1] + 2 * h * Qp / k;
                    mas1[i, N] = (1 - 4 * beta) * mas[i, N] + beta * (Al + mas[i, N - 1] + mas[i - 1, N] + mas[i + 1, N])
                        + beta * g * h * h / k;
                }

                //Верхня
                for (int j = 1; j <= N - 1; j++)
                {
                    double Al = mas[N - 1, j] + 2 * h * Qv / k;
                    mas1[N, j] = (1 - 4 * beta) * mas[N, j] + beta * (Al + mas[N - 1, j] + mas[N, j-1] + mas[N, j+1])
                        + beta * g * h * h / k;
                }

                mas1[0, 0] = ((double)1 / 2) * (mas[1, 0] + mas[0, 1]);
                mas1[N, 0] = ((double)1 / 2) * (mas[N - 2, 0] + mas[N - 1, 1]);
                mas1[0, N] = ((double)1 / 2) * (mas[1, N - 1] + mas[0, N - 2]);
                mas1[N, N] = ((double)1 / 2) * (mas[N - 2, N - 1] + mas[N - 1, N - 2]);

                string str = null;
                for (int i = 0; i <= N; i++)
                {

                    for (int j = 0; j <= N; j++)
                    {
                        mas[i, j] = mas1[i, j];
                        DT.Rows[i][j] = Math.Round(mas[i, j], 1);
                        
                    }

                    str += "\n";
                }
            }

            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "T = " + Tfin.ToString();
            this.chart1.Series.Add(series1);


            //X
            for (int i = 0; i <= N; i++)
            {
                chart1.Series["T = " + Tfin.ToString()].Points.AddXY((i + 1) / (double)100, mas[N / 2, i]);
            }

            //Y
            //for (int i = 0; i <= N; i++)
            //{
            //    chart1.Series["T = " + Tfin.ToString()].Points.AddXY((i + 1) / (double)100, mas[i, N / 2]);
            //}
            dataGridView1.DataSource = DT;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
