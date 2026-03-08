using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15_Exercises.OrderClass
{
    internal class Order
    {
        private int _orderId;
        private string Status;
        private bool discount = false;
        public int OrderId
        {
            get { return _orderId; }
        }

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set { if (!string.IsNullOrWhiteSpace(value))
                    _customerName = value;
            }
        }

        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get
            {
                if (_totalAmount < 0)
                {
                    return 0;
                }
                else
                    return _totalAmount;
            }
        }


        public Order()
        {
            Status = "NEW";
        }
        public Order(int _orderId, string _customerName)
        {
            this._orderId=_orderId;
            CustomerName = _customerName;
            Status = "NEW";
        }

        public void AddItem(decimal price)
        {
            if (price > 0)
            {
                _totalAmount += price;
            }
            
        }


        public void ApplyDiscount(decimal percentage)
        {
            if (discount == false && percentage>=1  && percentage<=30 )
            {
                _totalAmount = _totalAmount - (_totalAmount * ((percentage) / 100));
                discount = true;
            } 
        }


        public void GetOrderSummary()
        {
            Console.WriteLine($"Order Id:     {OrderId}");
            Console.WriteLine($"Customer:     {CustomerName}");
            Console.WriteLine($"Total Amount: {TotalAmount}");
            Console.WriteLine($"Status:       {Status}");
        }
    }
    internal class Ordername
    {
        static void Main(string[] args)
        {
            Order o1 = new Order(111, "");
            o1.AddItem(500);
            o1.AddItem(300);
            o1.ApplyDiscount(11);
            o1.GetOrderSummary();


            Order o2 = new Order(102, "Raj");
            o2.AddItem(-500);
            o2.AddItem(300);
            o2.ApplyDiscount(11);
            o2.GetOrderSummary();

            Order o3 = new Order(91, "Rajat");
            o3.AddItem(500);
            o3.AddItem(300);
            o3.ApplyDiscount(21);
            o3.ApplyDiscount(21);
            o3.GetOrderSummary();

            Order o4 = new Order(121, "Rahul");
            o4.AddItem(500);
            o4.AddItem(300);
            o4.ApplyDiscount(11);
            o4.GetOrderSummary();
        }
    }
}
