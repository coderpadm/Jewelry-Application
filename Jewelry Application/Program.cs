using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Printing Jewelry Details: \n");

            var Jewelry1 = new Jewelry(100.00);
            Jewelry1.JewelryMaterial = MaterialJewelry.Terracotta;
            Jewelry1.JewelryDesc = "Beautiful jewelry set";
            Jewelry1.JewelryCategory = CategoryJewelry.Female;
            Jewelry1.JewelryType = TypeJewelry.Set;
           
            Jewelry1.PrintDetails();
            Jewelry1.SetDiscount(.1);
            Jewelry1.ApplyDiscount();
          

            var Jewelry2 = new Jewelry(20);
            Jewelry2.JewelryMaterial = MaterialJewelry.Bead;
            Jewelry2.JewelryDesc = "Cool bead bracelet";
            Jewelry2.JewelryCategory = CategoryJewelry.Female;
            Jewelry2.JewelryType = TypeJewelry.Bracelet;
            Jewelry2.PrintDetails();


            var Customer1 = new Customer("John", "Doe");
            Customer1.CustomerGender = CategoryGender.Male;
            Customer1.CustomerPhoneNumber = "555-555-5555";
            Customer1.CustomerAddress = "#10, Bellevue way, Bellevue, WA";
            

            var Customer2 = new Customer("Judy", "Stone");
            Customer2.CustomerGender = CategoryGender.Female;

            
            Jewelry[] jewOrd1 = { Jewelry1 };
            Jewelry[] jewOrd2 = { Jewelry1, Jewelry2 };

            Console.WriteLine("Customer Details prior to order placement:\n");

            Customer1.GetCustomerDetails();
            Customer2.GetCustomerDetails();

            Console.WriteLine("Placing Orders.\n");

            var Order1 = new Order(Customer1,jewOrd1);
            var Order2 = new Order(Customer2,jewOrd2);

            Console.WriteLine("Order Details:\n");

            Order1.GetOrderDetails();
            Order2.GetOrderDetails();

            Console.WriteLine("Customer Details after processing the order:\n");

            Customer1.GetCustomerDetails();
            Customer2.GetCustomerDetails();
               
    

        }
    }
}
