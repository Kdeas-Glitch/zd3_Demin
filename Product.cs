using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd3_Demin
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public string DateGet { get; set; }


        private double Q;

        public Product(string name,double price,int count,string type,string dateget)
        {
            Name = name;
            Price = price;
            Count = count;
            Q = price / count;
            Type = type;
            DateGet = dateget;
        }

        public double GetQ()
        {
            bool end = new List<double> { Price }.Any(x => x > 0 && x < 1000);
            if (end)
            {
                Q = Price / Count;
                return Q;
            }
            else
            {
                MessageBox.Show("Неверное данное цены");
                return 0;
            }
        }


    }
}
