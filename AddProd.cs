using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd3_Demin
{
    class AddProd : Product
    {
        int Year { get; set; }
        string Sup { get; set; }

        public double Qp { get; set; }
        public AddProd(string name,double price,int count,string type,string dateget, int year,string sup) : base(name, price, count, type, dateget)
        {
            Name = name;
            Price = price;
            Count = count;
            Type = type;
            DateGet = dateget;
            Year = year;
            Sup = sup;
            Qp = Price / Count + 0.5 * (2025 - Year);
        }

        public double GetQ()
        {
            bool end = new List<double> { Price }.Any(x => x > 0 && x < 1000);
            if (end)
            {
                Qp = Price / Count + 0.5 * (2025 - Year);
                return Qp;
            }
            else
            {
                MessageBox.Show("Неверное данное цены");
                return 0;
            }
        }
    }
}
