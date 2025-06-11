using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zd3
{
    public class AddProd : Product
    {
        private int year;//год выпуска товара

        public int Year { get { return year; } set {year = value; } }//год выпуска
        public string Sup { get; set; }//имя поставщика товара

        private double Qp;//Качество товара
        public AddProd(string name, double price, int count, string type, string dateget, int year, string sup) : base(name, price, count, type, dateget)//Добавление данных при создании класса
        {
            Name = name;//имя товара
            Price = price;// Цена товара
            Count = count;// Количество товара
            Type = type;// Тип товара
            DateGet = dateget;// Дата получения
            Year = year;// Год получения
            Sup = sup;// Поставщик
            Qp = Price / Count + 0.5 * (2025 - Year);//Качество товара
        }

        public double GetQ()//Постчитать и вернуть качество товара
        {
            bool end = new List<double> { Count }.Any(x => x > 0 && x < 1000);//Проверка данных что бы не делилось на 0
            if (end)
            {
                Qp = Price / Count + 0.5 * (2025 - Year);//Подсчёт качества товара
                return Qp;//Возвращение качества товара
            }
            else
            {
                MessageBox.Show("Неверное данное Количества");
                return 0;//возвращение при ошибке
            }
        }
    }
}
