using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd3_Demin
{
    public partial class Form1 : Form
    {
        List<Product> list = new List<Product>();
        Dictionary<string, AddProd> AddList = new Dictionary<string, AddProd>();
        public Form1()
        {
            

            InitializeComponent();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Цена";
            dataGridView1.Columns[2].HeaderText = "Колличество";
            dataGridView1.Columns[3].HeaderText = "Тип";
            dataGridView1.Columns[4].HeaderText = "Дата Получения";
            dataGridView1.Columns[5].HeaderText = "Год выпуска";
            dataGridView1.Columns[6].HeaderText = "Поставщик";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox7.Visible = true;
                textBox6.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                textBox7.Visible = false;
                textBox6.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }

        }
    }
}
