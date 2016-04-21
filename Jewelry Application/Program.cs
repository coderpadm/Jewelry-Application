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
            string option;
            do
            {


                Console.WriteLine("1. Add new jewelry");
                Console.WriteLine("2. Add new customer");
                Console.WriteLine("3. Place an order");
                Console.WriteLine("4. Print jewelry information");
                Console.WriteLine("5. Print customer information");
                Console.WriteLine("6. Print orders");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose an option from above");

                option = Console.ReadLine();



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
                            "g. Platinum \n"
                            );
                        var matOption = Console.ReadLine();

                        var Jewelry1 = Jeweler.AddNewJewelry(jewDesc,
                            (matOption.Equals("a") ? MaterialJewelry.Crystal :
                            (matOption.Equals("b") ? MaterialJewelry.Terracotta :
                            (matOption.Equals("c") ? MaterialJewelry.Pearl :
                            (matOption.Equals("d") ? MaterialJewelry.Bead :
                            (matOption.Equals("e") ? MaterialJewelry.Crystal :
                            (matOption.Equals("f") ? MaterialJewelry.Gold :
                            MaterialJewelry.Platinum
                            )))))), TypeJewelry.Set, 100.0, CategoryJewelry.Female);

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
                        break;

                    case "3":
                        Console.Write("Creating a new customer and jewelry before placing an order \n");

                        var Jewelry2 = Jeweler.AddNewJewelry("Cool bead bracelet", MaterialJewelry.Bead,
                        TypeJewelry.Bracelet, 20.0, CategoryJewelry.Female);

                        var Customer2 = Jeweler.AddNewCustomer("Judy", "Stone", CategoryGender.Female, "", "");


                        List<Jewelry> jewOrd1 = new List<Jewelry>();
                        jewOrd1.Add(Jewelry2);


                        var Order1 = Jeweler.CreateNewOrder(Customer2, jewOrd1);


                        break;

                    case "4":
                        PrintJewelry();
                        break;

                    case "5":
                        PrintCustomers();
                        break;

                    case "6":
                        PrintOrders();
                        break;


                    case "0":
                        Console.WriteLine("Good bye!");
                        return;

                    default:
                        return;
                }

            } while (option != "0");

        }

        static void PrintJewelry()
        {
            if (Jeweler.jewelList.Count == 0)
            {
                Console.WriteLine("No jewelry information is available.");
            }
            else
            {
                foreach (var jewel in Jeweler.jewelList)
                {
                    Console.WriteLine(" Jewelry Id: {0} \n Jewelry Name: {1} \n Jewelry Material: {2} \n " +
                   "JewelryType: {3} \n JewelryPrice: {4:c} \n Jewelry Category: {5} \n Jewelry Discount: {6:p} \n",
                   jewel.JewelryId, jewel.JewelryDesc, jewel.JewelryMaterial,
                   jewel.JewelryType, jewel.JewelryPrice, jewel.JewelryCategory, jewel.JewelryDiscount
                   );

                }
            }
           
        }

        static void PrintCustomers()
        {
            if (Jeweler.custList.Count == 0)
            {
                Console.WriteLine("No customer information is available. ");
            }
            else
            {
                foreach (var cust in Jeweler.custList)
                {
                    Console.WriteLine(" Customer Id: {0} \n First Name: {1} \n Last Name: {2} \n " +
                    "Address: {3} \n PhoneNumber: {4} \n Gender: {5} \n Customer Since: {6:d} \n",
                    cust.CustomerId, cust.CustomerFirstName, cust.CustomerLastName,
                    cust.CustomerAddress, cust.CustomerPhoneNumber, cust.CustomerGender, cust.CustomerSince.Date
                    );

                }
            }
           
        }

        static void PrintOrders()
        {

            if (Jeweler.ordList.Count == 0)
            {
                Console.WriteLine("No orders were received. ");
            }
            else
            {
                foreach (var ord in Jeweler.ordList)
                 {
                    Console.WriteLine(" Order Id: {0} \n Customer Id: {1} \n " +
                    "Order Bought Date and Time: {2} \n Order Discount: {3:p} \n Order Total: {4:c} \n",
                    ord.OrderId, ord.OrderCustomer.CustomerId,
                    ord.OrderBoughtDateTime, ord.OrderDiscount, ord.OrderTotal);
                }
            }
        }
    }
}
