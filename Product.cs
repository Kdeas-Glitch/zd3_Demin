using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace zd3
{
    public class Product
    {
        private string name;// Имя товара
        private double price;// Цена товара
        private int count;// Количество товара
        private string type;// Тип товара
        private string dateGet;// Дата получения товара

        public string Name { get { return name; } set { name = value; } }// Свойство для имени товара
        public double Price { get { return price; } set { price = value; } }// Свойство для цены товара
        public int Count { get { return count; } set { count = value; } }// Свойство для количества товара
        public string Type { get { return type; } set { type = value; } }// Свойство для типа товара
        public string DateGet { get { return dateGet; } set { dateGet = value; } }// Свойство для даты получения товара


        private double Q;// Соотношение цена/количество

        public Product(string name, double price, int count, string type, string dateget)
        {
            this.name = name;// Инициализация имени товара
            this.price = price;// Инициализация цены товара
            this.count = count;// Инициализация количества товара
            this.type = type;// Инициализация типа товара
            this.dateGet = dateget;// Инициализация даты получения товара
        }

        public double GetQ()//Получить Качество товара
        {
            bool end = new List<double> { price }.Any(x => x > 0 && x < 1000);// Проверка на допустимое значение цены
            if (end)
            {
                Q = Price / Count;// Вычисление нового соотношения
                return Q;// Возврат значения соотношения
            }
            else
            {
                MessageBox.Show("Неверное данное цены");// Сообщение об ошибке
                return 0;// Возврат нулевого значения при ошибке
            }
        }

        public static Product Add(string name, double price, int count, string type, string dateget)//Добавить товар
        {
            bool isValid = name != "" && name.All(c => Char.IsLetter(c) || Char.IsDigit(c)) && price > 0 && count > 0 && type != "" && type.All(c => Char.IsLetter(c) || Char.IsDigit(c)) && dateget != "" && dateget.All(c => Char.IsDigit(c) || c == '.');//Проверка на правильность ввода

            if (isValid)
            {
                Product pr = new Product(name, price, count, type, dateget);// Создание нового товара
                return pr;// Возврат созданного товара
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
                return new Product("", 0, 0, "", "");// Возврат пустого товара
            }
        }

        public static Product Add(string name, double price, int count, string type)//Добавить товар когда товар не доставлен
        {
            bool isValid = name != "" && name.All(c => Char.IsLetter(c) || Char.IsDigit(c)) && price > 0 && count > 0 && type != "" && type.All(c => Char.IsLetter(c) || Char.IsDigit(c)); // Проверка на правильность ввода
            if (isValid)
            {
                Product pr = new Product(name, price, count, type, "Не Получено"); // Создание нового товара с предполагаемой датой получения
                return pr; // Возврат созданного товара
            }
            else
            {
                MessageBox.Show("Введены неверные данные"); // Сообщение об ошибке
                return new Product("", 0, 0, "", ""); // Возврат пустого товара
            }
        }

        public static AddProd Add(string name, double price, int count, string type, string dateget, int year, string sup)//Добавить товар с дополнительными данными
        {
            bool isValid = name != "" && name.All(c => Char.IsLetter(c) || Char.IsDigit(c)) && price > 0 && count > 0 && type != "" && type.All(c => Char.IsLetter(c) || Char.IsDigit(c)) && dateget != "" && dateget.All(c => Char.IsDigit(c) || c == '.') && year > 2020 && sup != "" && sup.All(c => Char.IsLetter(c) || Char.IsDigit(c)); // Проверка на правильность ввода
            if (isValid)
            {
                AddProd pr = new AddProd(name, price, count, type, dateget, year, sup); // Создание нового товара с дополнительными данными
                return pr; // Возврат созданного товара
            }
            else
            {
                MessageBox.Show("Введены неверные данные"); // Сообщение об ошибке
                return new AddProd("", 0, 0, "", "", 0, ""); // Возврат пустого товара
            }
        }

        public static Product Delete(string name, List<Product> list)//Удалить товар по имени
        {
            int i = list.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a.Name == name)?.index ?? -1;// Поиск товара по имени
            return list[i];// Возврат найденного товара
        }

        public static AddProd Delete(string name, Dictionary<string, AddProd> AddList, List<string> names)//Удалить товар по имени в дополнительных данных
        {
            int i = names.Select((a, index) => new { a, index }).FirstOrDefault(x => x.a == name)?.index ?? -1; // Поиск товара по имени в списке
            return AddList[names[i]]; // Возврат найденного товара
        }

        public static Product Delete(int ind, List<Product> list)//Удалить товар по индексу
        {
            var itemAtIndex = list.ElementAtOrDefault(ind); // Получение товара по индексу
            int i = itemAtIndex != null ? list.IndexOf(itemAtIndex) : -1; // Получение индекса товара
            return list[i]; // Возврат товара по индексу
        }

    }
}
