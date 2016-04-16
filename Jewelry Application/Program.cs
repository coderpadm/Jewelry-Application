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
            Console.WriteLine("**********Welcome to Creative Jewellers**********");
            while (true)
            {

            
            Console.WriteLine("1. Add new jewelry");
            Console.WriteLine("2. Add new customer");
            Console.WriteLine("3. Place an order");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Choose an option from above");
    
            var option = Console.ReadLine();
               


                switch (option)
                {
                    case "1":
                        Console.Write("What is the description of the jewelry? ");
                        var jewDesc = Console.ReadLine();
                        Console.Write("Choose the material of the jewelry:\n" +
                            "a. Crystal \n" +
                            "b. Terracotta \n" +
                            "c. Pearl \n" +
                            "d. Bead \n" +
                            "e. Silver \n" +
                            "f. Gold \n" +
                            "g. Platinum \n "
                            );
                        var matOption = Console.ReadLine();

                        var Jewelry1 = Jeweler.AddNewJewelry(jewDesc,
                            (matOption.Equals("a") ? MaterialJewelry.Crystal :
                            (matOption.Equals("b") ? MaterialJewelry.Terracotta :
                            (matOption.Equals("c") ? MaterialJewelry.Pearl :
                            (matOption.Equals("d") ? MaterialJewelry.Bead :
                            (matOption.Equals("e") ? MaterialJewelry.Crystal :
                            (matOption.Equals("f") ? MaterialJewelry.Terracotta :
                            MaterialJewelry.Platinum
                            )))))), TypeJewelry.Set, 100.0, CategoryJewelry.Female);

                        Jewelry1.PrintDetails();
                        Jewelry1.SetDiscount(.1);
                        Jewelry1.ApplyDiscount();
                        break;
                    case "2":
                        Console.Write("What is the first name of the customer? ");
                        var fName = Console.ReadLine();
                        Console.Write("What is the last name of the customer? ");
                        var lName = Console.ReadLine();
                        Console.Write("What is the phone number of the customer? ");
                        var phoneNo = Console.ReadLine();
                        Console.Write("What is the address of the customer? ");
                        var addrDetails = Console.ReadLine();
                        Console.Write("What the Gender of the Customer (M / F) ?");
                        var genderCust = Console.ReadLine();
                        var Customer1 = Jeweler.AddNewCustomer(fName, lName,
                            (genderCust.Equals("M") ? CategoryGender.Male :
                        CategoryGender.Female), phoneNo, addrDetails);
                        Customer1.GetCustomerDetails();
                        break;
                    case "3":
                        Console.Write("Creating a new customer and jewelry before placing an order");

                        var Jewelry2 = Jeweler.AddNewJewelry("Cool bead bracelet", MaterialJewelry.Bead,
                        TypeJewelry.Bracelet, 20.0, CategoryJewelry.Female);
                        Jewelry2.PrintDetails();

                     
                        var Customer2 = Jeweler.AddNewCustomer("Judy", "Stone", CategoryGender.Female, "", "");
                       

                        Jewelry[] jewOrd1 = { Jewelry2 };
                        
                         
                        var Order1 = Jeweler.CreateNewOrder(Customer2, jewOrd1);
                        Order1.GetOrderDetails();
                        Customer2.GetCustomerDetails();

                        break;
                    case "0":
                        return;
                       
                    default:
                        return;
                }

            }



            /*
            var Jewelry1 = Jeweler.AddNewJewelry("Beautiful jewelry set", MaterialJewelry.Terracotta, 
                TypeJewelry.Set, 100.0,CategoryJewelry.Female);
            Jewelry1.PrintDetails();
            Jewelry1.SetDiscount(.1);
            Jewelry1.ApplyDiscount();

            var Jewelry2 = Jeweler.AddNewJewelry("Cool bead bracelet", MaterialJewelry.Bead,
                TypeJewelry.Bracelet, 20.0, CategoryJewelry.Female);
            Jewelry2.PrintDetails();

            var Customer1=Jeweler.AddNewCustomer("John", "Doe", CategoryGender.Male,
                "555-555-5555", "#10, Bellevue way, Bellevue, WA");
            var Customer2 = Jeweler.AddNewCustomer("Judy", "Stone", CategoryGender.Female, "", "");
            Customer1.GetCustomerDetails();
            Customer2.GetCustomerDetails();

            Jewelry[] jewOrd1 = { Jewelry1 };
            Jewelry[] jewOrd2 = { Jewelry1, Jewelry2 };

            var Order1 = Jeweler.CreateNewOrder(Customer1, jewOrd2);
            Order1.GetOrderDetails();
            Customer1.GetCustomerDetails();
     */
        }
    }
}
