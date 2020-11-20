using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMerAPI.Models
{
    public class Pedido
    {
        int ordenno;
        string orderdate;
        string name;
        string adress;
        string phone;
        string employe;
        string productCode;
        string productName;
        int quanty;
        double price;
        double total;

        public int Ordenno { get => ordenno; set => ordenno = value; }
        public string Orderdate { get => orderdate; set => orderdate = value; }
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Employe { get => employe; set => employe = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quanty { get => quanty; set => quanty = value; }
        public double Price { get => price; set => price = value; }
        public double Total { get => total; set => total = value; }
    }
}
