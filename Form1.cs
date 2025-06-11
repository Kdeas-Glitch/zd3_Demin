using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace zd3
{
    public partial class Form1 : Form
    {
        static List<Product> list = new List<Product>();// ������ �������
        static List<string> names = new List<string>();// ������ ���� �������
        static Dictionary<string, AddProd> AddList = new Dictionary<string, AddProd>();// ������� ������� � ��������������� �������

        public Form1() // ����������� �����
        {
            InitializeComponent(); // ������������� ����������� �����
            dataGridView1.ColumnCount = 7; // ��������� ���������� ������� � �������
            dataGridView1.Columns[0].HeaderText = "���"; // ��������� ��� ������ �������
            dataGridView1.Columns[1].HeaderText = "����"; // ��������� ��� ������ �������
            dataGridView1.Columns[2].HeaderText = "�����������"; // ��������� ��� ������� �������
            dataGridView1.Columns[3].HeaderText = "���"; // ��������� ��� ��������� �������
            dataGridView1.Columns[4].HeaderText = "���� ���������"; // ��������� ��� ����� �������
            dataGridView1.Columns[5].HeaderText = "��� �������"; // ��������� ��� ������ �������
            dataGridView1.Columns[6].HeaderText = "���������"; // ��������� ��� ������� �������
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ���_������(object sender, EventArgs e) // ���������� ��� ����������� �������������� ������
        {
            if (checkBox1.Checked == true) // �������� ��������� ��������
            {
                // ����������� �������������� ��������� ����� � �����
                textBox6.Visible = true;
                textBox7.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else // ���� ������� �� �������
            {
                // ������� �������������� ��������� ����� � �����
                textBox6.Visible = false;
                textBox7.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        }

        private void ��������(object sender, EventArgs e)
        {
            try
            {
                bool ch = true;// ���� ��� �������� ������������� ������
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridView1[0, i].Value) == textBox1.Text)// �������� �� ���������� ����� ������
                    {
                        ch = false;// ���� ���������� �������, ���������� ���� � false
                    }
                }
                if (ch)// ���� ����� ������
                {
                    if (checkBox1.Checked == true)// ���� ������� �������
                    {

                        var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text); // �������� ������ � ��������������� �����������
                        if (pr.Name != "") // �������� �� ������������ �������� ������
                        {
                            AddList.Add(pr.Name, pr); // ���������� ������ � �������
                            names.Add(pr.Name); // ���������� ����� ������ � ������ ����
                            dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet, pr.Year, pr.Sup); // ���������� ������ � �������
                        }
                    }
                    else // ���� ������� �� �������
                    {
                        if (textBox5.Text == "") // ���� �������������� ���� �� �������
                        {
                            var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text); // �������� ������ ��� �������������� ������
                            if (pr.Name != "") // �������� �� ������������ �������� ������
                            {
                                list.Add(pr); // ���������� ������ � ����� ������
                                dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet); // ���������� ������ � �������
                            }
                        }
                        else // ���� �������������� ���� �������
                        {
                            var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text); // �������� ������ � ��������������� �������
                            if (pr.Name != "") // �������� �� ������������ �������� ������
                            {
                                list.Add(pr); // ���������� ������ � ����� ������
                                dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet); // ���������� ������ � �������
                            }
                        }
                    }
                }
                else // ���� ����� ��� ����������
                {
                    MessageBox.Show("����� ����� ����"); // ��������� �� ������
                }
            }
            catch
            {
                MessageBox.Show("������� �������� ������"); // ��������� �� ������ ��� �������� �����
            }
        }

        private void ��������_Q(object sender, EventArgs e)
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // ��������� �������� ������� ������
            if (dataGridView1[6, ind].Value != null) // �������� ������� �������� � ����������� ������ 
            {
                var key = Get_Data_Grid_AddProd(); // ��������� ����� �� ��������������� ������ �������
                MessageBox.Show($"{AddList[key].Name} Q={AddList[key].GetQ()}"); // ����� ���������� � ������
            }
            else
            {
                var i = Get_Data_Grid_Prod(); // ��������� ������� ������ �� ��������� ������
                MessageBox.Show($"{list[i].Name} Q={list[i].GetQ()}"); // ����� ���������� � ������
            }
        }

        private int Get_Data_Grid_Prod()
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // ��������� �������� ������� ������
            int i = list.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a.Name == Convert.ToString(dataGridView1[0, ind].Value))?.index ?? -1; // ����� ������� ������ �� �����
            return i; // ������� ���������� �������
        }

        private string Get_Data_Grid_AddProd()
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // ��������� �������� ������� ������
            var key = AddList.Where(kvp => kvp.Key == Convert.ToString(dataGridView1[0, ind].Value)).Select(kvp => kvp.Key).FirstOrDefault(); // ����� ����� ������ � �������������� ������

            return key; // ������� ���������� �����
        }

        private void �������_��_�����(object sender, EventArgs e)
        {
            string text = textBox8.Text; // ��������� ������ �� ���������� ����
            int ind = -1; // ������������� �������
            for (int i = 0; i < dataGridView1.RowCount; i++) // ����� ������ � �������
            {
                if ((string)dataGridView1[0, i].Value == text) // ���� ������� ���������� �� �����
                {
                    ind = i; break; // ���������� ������ � ������� �� �����
                }
            }
            if (ind != -1) // ���� ����� ������
            {
                if (dataGridView1[6, ind].Value != null) // �������� ������� �������� � ����������� ������ 
                {
                    var pr = Product.Delete((string)dataGridView1[0, ind].Value, AddList, names); // �������� ������ �� ��������������� ������
                    AddList.Remove(pr.Name); // �������� �� ������
                }
                else
                {
                    var pr = Product.Delete((string)dataGridView1[0, ind].Value, list); // �������� ������ �� ��������� ������
                    list.Remove(pr); // �������� �� ������
                }

                dataGridView1.Rows.Clear(); // ������� �������
                for (int i = 0; i < list.Count; i++) // ���������� ���������� ������� �� ��������� ������ � �������
                {
                    dataGridView1.Rows.Add(list[i].Name, list[i].Price, list[i].Count, list[i].Type, list[i].DateGet);
                }
                for (int i = 0; i < AddList.Count; i++) // ���������� ���������� ������� �� ��������������� ������ � �������
                {
                    dataGridView1.Rows.Add(AddList[names[i]].Name, AddList[names[i]].Price, AddList[names[i]].Count, AddList[names[i]].Type, AddList[names[i]].DateGet, AddList[names[i]].Year, AddList[names[i]].Sup);
                }
            }
            else
            {
                MessageBox.Show("��� ����������"); // ��������� � ���, ��� ���������� �� �������
            }
        }


        private void �������_��_�������(object sender, EventArgs e)
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // ��������� �������� ������� ������
            
            if (dataGridView1[6, ind].Value != null) // �������� ������� �������� � ����������� ������ 
            {
                string name = (string)dataGridView1[0, ind].Value; // ��������� ����� ������
                var pr = Product.Delete(name, AddList, names); // �������� ������ �� ��������������� ������
                AddList.Remove(pr.Name); // �������� �� ������
            }
            else
            {
                string name = (string)dataGridView1[0, ind].Value; // ��������� ����� ������
                int i = list.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a.Name == name)?.index ?? -1;// ����� ������ �� �����
                var pr = Product.Delete(i, list); // �������� ������ �� ��������� ������ �� �������
                list.Remove(pr); // �������� �� ������
            }

            dataGridView1.Rows.Clear(); // ������� �������
            for (int i = 0; i < list.Count; i++) // ���������� ���������� ������� �� ��������� ������ � �������
            {
                dataGridView1.Rows.Add(list[i].Name, list[i].Price, list[i].Count, list[i].Type, list[i].DateGet);
            }
            for (int i = 0; i < AddList.Count; i++) // ���������� ���������� ������� �� ��������������� ������ � �������
            {
                dataGridView1.Rows.Add(AddList[names[i]].Name, AddList[names[i]].Price, AddList[names[i]].Count, AddList[names[i]].Type, AddList[names[i]].DateGet, AddList[names[i]].Year, AddList[names[i]].Sup);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
