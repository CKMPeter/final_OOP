using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace finalProject_OOP
{
    class Customer
    {
        Order Orders;
       
        string name { get; set; }
        int id { get; set; }
        bool state {  get; set; }

        public Customer()
        {

        }

        public Customer(string name, int id, Order orders) { 
            this.name = name;
            this.id = id;
            if (orders != null)
            {
                this.state = true;
                this.Orders = orders;
            }
            else
            {
                this.state = false;
                this.Orders = null; 
            }
        }

        public void OutputCustomer()
        {
            Console.WriteLine($"Name: {this.name}\n" +
                    $"ID: {this.id}");
            if (this.state != true)
                Console.WriteLine("State: Haven't Borrow...");
            else Console.WriteLine("State: Is Borrowing...");
            Console.WriteLine();
        }

        public void PrintOrderInfo()
        {
            if (this.Orders != null)
            {
                Orders.Print();
            }
            else Console.WriteLine("You haven't borrowd any books yet!");
        }

        public void ReturntOrders(string path) 
        {
            if (Orders != null)
            {
                Orders.ReturnOrder(path);
                Orders = null;
                state = false;
            }

        }
        public void BorrowBook(Order orders)
        {
            if (Orders == null) {
                Orders = orders;
                state = true;
            }
        }

        public bool StateReturn()
        {
            return state;
        }

        public string Name { get { return name; } set { name = value; } }
        public int ID { get { return id; } set { id = value; } }

        public bool State { get { return state; } set { state = value; } }
        public void HistoryToFile(string path, string action)
        {
            Orders.fHistory(path, name, action);
        }

        public string CusData()
        {
            string tmp = $"{this.id},{this.name},{this.state},";
            return tmp;
        }

        public string CusDataToCsv()
        {
            string tmp = $"{this.id},{this.name},{this.state},";
            if(this.state == true)
            {
                string Rlist = this.Orders.OrderCsv();
                tmp += Rlist;
            }
            return tmp;
        }
    }
}
