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


                Console.WriteLine("1. Add a new jewel");
                Console.WriteLine("2. Add a new customer");
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
                        Console.Write("What is the code for the jewelry?");
                        var jCode = Console.ReadLine();
                        Console.Write("What is the price of the jewelry?");
                        var sprice = Console.ReadLine();
                        double price = 0.0;
                        try
                        {
                            price = Convert.ToDouble(sprice);
                        }
                        catch (FormatException)
                        {
                            Console.Write("Unable to convert {0} to a numeric value", sprice);

                        }


                        var Jewelry1 = Jeweler.AddNewJewelry(jewDesc,
                            (matOption.Equals("a") ? MaterialJewelry.Crystal :
                            (matOption.Equals("b") ? MaterialJewelry.Terracotta :
                            (matOption.Equals("c") ? MaterialJewelry.Pearl :
                            (matOption.Equals("d") ? MaterialJewelry.Bead :
                            (matOption.Equals("e") ? MaterialJewelry.Crystal :
                            (matOption.Equals("f") ? MaterialJewelry.Gold :
                            MaterialJewelry.Platinum
                            )))))), TypeJewelry.Set, price, CategoryJewelry.Female, jCode);

                        //  Jewelry1.SetDiscount(.1);
                        //  Jewelry1.ApplyDiscount();
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
                        Console.Write("What is the email address of the Customer?");
                        var email = Console.ReadLine();
                        Jeweler.AddNewCustomer(fName, lName,
                            (genderCust.Equals("M") ? CategoryGender.Male :
                        CategoryGender.Female), phoneNo, addrDetails, email);

                        break;

                    case "3":

                        Console.Write("What is the email address of the Customer?");
                        var emailAddress = Console.ReadLine();

                        var customer = Jeweler.FindCustomer(emailAddress);

                        Console.Write("How many number of jewels would you like to be included in this order?");
                        var count = Console.ReadLine();
                        int jewelCount;
                        List<Jewelry> jewOrder = new List<Jewelry>();
                        if (Int32.TryParse(count, out jewelCount))
                        {

                            jewOrder = prepareJewelList(jewelCount);
                        }
                        else
                        {
                            Console.Write("How many jewels do you want order?");
                        }
                        if (customer != null)
                        {
                            Jeweler.CreateNewOrder(customer, jewOrder);
                        }

                        break;

                    case "4":
                        //     PrintJewelry();
                        break;

                    case "5":
                        //     PrintCustomers();
                        break;

                    case "6":
                        //     PrintOrders();
                        break;


                    case "0":
                        Console.WriteLine("Good bye!");
                        return;

                    default:
                        return;
                }

            } while (option != "0");

        }

        static List<Jewelry> prepareJewelList(int jewelCnt)
        {
            List<Jewelry> jewOrd = new List<Jewelry>();
            for (int j = 0; j < jewelCnt; j++)
            {
                Console.Write("What is the code for the jewel?");
                var jCd = Console.ReadLine();
                var jwel = Jeweler.FindJewel(jCd);
                if (jwel != null)
                {
                    jewOrd.Add(jwel);
                }
            }
            return jewOrd;
        }

    }
}
