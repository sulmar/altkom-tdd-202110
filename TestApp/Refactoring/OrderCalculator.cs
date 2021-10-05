using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestApp.Refactoring
{
    #region Models

    public class Order
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }

        // public decimal TotalAmount => Details.Sum(p => p.LineTotal);
        public decimal TotalAmount { get; set; }

        public ICollection<OrderDetail> Details = new Collection<OrderDetail>();

        public void AddDetail(Product product, int quantity = 1)
        {
            OrderDetail detail = new OrderDetail(product, quantity);

            this.Details.Add(detail);
        }

        public Order(DateTime orderDate, Customer customer)
        {
            OrderDate = orderDate;
            Customer = customer;
        }
    }

    public class Product
    {
        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class OrderDetail
    {
        public OrderDetail(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;

            UnitPrice = product.UnitPrice;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }

    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (firstName.EndsWith("a"))
            {
                Gender = Gender.Female;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

    #endregion

    // Promocja Happy Hours - 10% upustu w godzinach od 8:00 do 15:00
    public class OrderCalculator
    {
        private TimeSpan beginHour;
        private TimeSpan endHour;
        private decimal percentage;

        public OrderCalculator(TimeSpan beginHour, TimeSpan endHour, decimal percentage)
        {
            this.beginHour = beginHour;
            this.endHour = endHour;
            this.percentage = percentage;
            
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            if (order.OrderDate.TimeOfDay >= beginHour && order.OrderDate.TimeOfDay < endHour)
            {
                return order.TotalAmount * percentage;
            }
            else
            {
                return 0;
            }
        }
    }

    // Promocja 20% upustu dla kobiet

    // Powyżej powyżej 100 PLN - upust 10 zł, 200 PLN upust 20 PLN

    // Promocja weekendowa - wysyłka gratis
    


}
