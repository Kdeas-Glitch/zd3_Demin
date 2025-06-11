using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace zd3
{
    public partial class Form1 : Form
    {
        static List<Product> list = new List<Product>();// Список товаров
        static List<string> names = new List<string>();// Список имен товаров
        static Dictionary<string, AddProd> AddList = new Dictionary<string, AddProd>();// Словарь товаров с дополнительными данными

        public Form1() // Конструктор формы
        {
            InitializeComponent(); // Инициализация компонентов формы
            dataGridView1.ColumnCount = 7; // Установка количества колонок в таблице
            dataGridView1.Columns[0].HeaderText = "Имя"; // Заголовок для первой колонки
            dataGridView1.Columns[1].HeaderText = "Цена"; // Заголовок для второй колонки
            dataGridView1.Columns[2].HeaderText = "Колличество"; // Заголовок для третьей колонки
            dataGridView1.Columns[3].HeaderText = "Тип"; // Заголовок для четвертой колонки
            dataGridView1.Columns[4].HeaderText = "Дата Получения"; // Заголовок для пятой колонки
            dataGridView1.Columns[5].HeaderText = "Год выпуска"; // Заголовок для шестой колонки
            dataGridView1.Columns[6].HeaderText = "Поставщик"; // Заголовок для седьмой колонки
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Доп_Данные(object sender, EventArgs e) // Обработчик для отображения дополнительных данных
        {
            if (checkBox1.Checked == true) // Проверка состояния чекбокса
            {
                // Отображение дополнительных текстовых полей и меток
                textBox6.Visible = true;
                textBox7.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else // Если чекбокс не отмечен
            {
                // Скрытие дополнительных текстовых полей и меток
                textBox6.Visible = false;
                textBox7.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        }

        private void Добавить(object sender, EventArgs e)
        {
            try
            {
                bool ch = true;// Флаг для проверки существования товара
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridView1[0, i].Value) == textBox1.Text)// Проверка на совпадение имени товара
                    {
                        ch = false;// Если совпадение найдено, установить флаг в false
                    }
                }
                if (ch)// Если товар найден
                {
                    if (checkBox1.Checked == true)// Если отмечен чекбокс
                    {

                        var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text); // Создание товара с дополнительными параметрами
                        if (pr.Name != "") // Проверка на корректность создания товара
                        {
                            AddList.Add(pr.Name, pr); // Добавление товара в словарь
                            names.Add(pr.Name); // Добавление имени товара в список имен
                            dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet, pr.Year, pr.Sup); // Добавление товара в таблицу
                        }
                    }
                    else // Если чекбокс не отмечен
                    {
                        if (textBox5.Text == "") // Если дополнительная дата не указана
                        {
                            var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text); // Создание товара без дополнительных данных
                            if (pr.Name != "") // Проверка на корректность создания товара
                            {
                                list.Add(pr); // Добавление товара в общий список
                                dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet); // Добавление товара в таблицу
                            }
                        }
                        else // Если дополнительная дата указана
                        {
                            var pr = Product.Add(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text); // Создание товара с дополнительными данными
                            if (pr.Name != "") // Проверка на корректность создания товара
                            {
                                list.Add(pr); // Добавление товара в общий список
                                dataGridView1.Rows.Add(pr.Name, pr.Price, pr.Count, pr.Type, pr.DateGet); // Добавление товара в таблицу
                            }
                        }
                    }
                }
                else // Если товар уже существует
                {
                    MessageBox.Show("Такой товар есть"); // Сообщение об ошибке
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные"); // Сообщение об ошибке при неверном вводе
            }
        }

        private void Получить_Q(object sender, EventArgs e)
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // Получение текущего индекса строки
            if (dataGridView1[6, ind].Value != null) // Проверка наличия значения в определённой ячейке 
            {
                var key = Get_Data_Grid_AddProd(); // Получение ключа из дополнительного списка товаров
                MessageBox.Show($"{AddList[key].Name} Q={AddList[key].GetQ()}"); // Вывод информации о товаре
            }
            else
            {
                var i = Get_Data_Grid_Prod(); // Получение индекса товара из основного списка
                MessageBox.Show($"{list[i].Name} Q={list[i].GetQ()}"); // Вывод информации о товаре
            }
        }

        private int Get_Data_Grid_Prod()
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // Получение текущего индекса строки
            int i = list.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a.Name == Convert.ToString(dataGridView1[0, ind].Value))?.index ?? -1; // Поиск индекса товара по имени
            return i; // Возврат найденного индекса
        }

        private string Get_Data_Grid_AddProd()
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // Получение текущего индекса строки
            var key = AddList.Where(kvp => kvp.Key == Convert.ToString(dataGridView1[0, ind].Value)).Select(kvp => kvp.Key).FirstOrDefault(); // Поиск ключа товара в дополнительном списке

            return key; // Возврат найденного ключа
        }

        private void Удалить_по_имени(object sender, EventArgs e)
        {
            string text = textBox8.Text; // Получение текста из текстового поля
            int ind = -1; // Инициализация индекса
            for (int i = 0; i < dataGridView1.RowCount; i++) // Поиск товара в таблице
            {
                if ((string)dataGridView1[0, i].Value == text) // Если найдено совпадение по имени
                {
                    ind = i; break; // Запоминаем индекс и выходим из цикла
                }
            }
            if (ind != -1) // Если товар найден
            {
                if (dataGridView1[6, ind].Value != null) // Проверка наличия значения в определённой ячейке 
                {
                    var pr = Product.Delete((string)dataGridView1[0, ind].Value, AddList, names); // Удаление товара из дополнительного списка
                    AddList.Remove(pr.Name); // Удаление из списка
                }
                else
                {
                    var pr = Product.Delete((string)dataGridView1[0, ind].Value, list); // Удаление товара из основного списка
                    list.Remove(pr); // Удаление из списка
                }

                dataGridView1.Rows.Clear(); // Очистка таблицы
                for (int i = 0; i < list.Count; i++) // Добавление оставшихся товаров из основного списка в таблицу
                {
                    dataGridView1.Rows.Add(list[i].Name, list[i].Price, list[i].Count, list[i].Type, list[i].DateGet);
                }
                for (int i = 0; i < AddList.Count; i++) // Добавление оставшихся товаров из дополнительного списка в таблицу
                {
                    dataGridView1.Rows.Add(AddList[names[i]].Name, AddList[names[i]].Price, AddList[names[i]].Count, AddList[names[i]].Type, AddList[names[i]].DateGet, AddList[names[i]].Year, AddList[names[i]].Sup);
                }
            }
            else
            {
                MessageBox.Show("Нет Совпадений"); // Сообщение о том, что совпадений не найдено
            }
        }


        private void Улалить_по_индексу(object sender, EventArgs e)
        {
            int ind = dataGridView1.CurrentCell.RowIndex; // Получение текущего индекса строки
            
            if (dataGridView1[6, ind].Value != null) // Проверка наличия значения в определённой ячейке 
            {
                string name = (string)dataGridView1[0, ind].Value; // Получение имени товара
                var pr = Product.Delete(name, AddList, names); // Удаление товара из дополнительного списка
                AddList.Remove(pr.Name); // Удаление из списка
            }
            else
            {
                string name = (string)dataGridView1[0, ind].Value; // Получение имени товара
                int i = list.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a.Name == name)?.index ?? -1;// Поиск товара по имени
                var pr = Product.Delete(i, list); // Удаление товара из основного списка по индексу
                list.Remove(pr); // Удаление из списка
            }

            dataGridView1.Rows.Clear(); // Очистка таблицы
            for (int i = 0; i < list.Count; i++) // Добавление оставшихся товаров из основного списка в таблицу
            {
                dataGridView1.Rows.Add(list[i].Name, list[i].Price, list[i].Count, list[i].Type, list[i].DateGet);
            }
            for (int i = 0; i < AddList.Count; i++) // Добавление оставшихся товаров из дополнительного списка в таблицу
            {
                dataGridView1.Rows.Add(AddList[names[i]].Name, AddList[names[i]].Price, AddList[names[i]].Count, AddList[names[i]].Type, AddList[names[i]].DateGet, AddList[names[i]].Year, AddList[names[i]].Sup);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
