using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

                Customer customer;

                switch (option)
                {
                    case "1":
                        
                        CreateJewel();

                        //  Jewelry1.SetDiscount(.1);
                        //  Jewelry1.ApplyDiscount();
                        break;

                    case "2":
                        customer = VerifyCustomer();

                        break;

                    case "3":

                        customer = VerifyCustomer();
                        List<Jewelry> jewOrder = VerifyJewels();

                        Jeweler.CreateNewOrder(customer, jewOrder);



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

        private static List<Jewelry> VerifyJewels()
        {
            Console.Write("How many number of jewels would you like to be included in this order?\n");
            var count = Console.ReadLine();
            int jewelCount;
            List<Jewelry> jewOrder = new List<Jewelry>();
            if (Int32.TryParse(count, out jewelCount))
            {

                jewOrder = PrepareJewelList(jewelCount);
            }
            else
            {
                Console.Write("Enter only a number for jewel count.\n");
            }

            return jewOrder;
        }

        private static Customer VerifyCustomer()
        {
            Customer customer;
            Console.Write("What is the email address of the Customer?\n");
            var emailAddress = Console.ReadLine();

            customer = Jeweler.FindCustomer(emailAddress);
            if (customer == null)
            {

                CreateCustomer(emailAddress);
            }

            return customer;
        }

        private static Jewelry CreateJewel()
        {
            Jewelry jewel;
            string jCode;
            jewel=VerifyJewel( out jCode);
            try
            {
                if (jewel == null)
                {
                    Console.WriteLine("A jewel with that code is not available. A new jewel with that code is being created.\n");
                    Console.Write("What is the description of the jewelry?\n");
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
                    Console.Write("Choose the category of the jewelry:\n" +
                       "a. Female \n" +
                       "b. Male \n" +
                       "c. Children \n"
                       );
                    var catOption = Console.ReadLine();
                    Console.Write("Choose the type of the jewelry:\n" +
                     "a. Chain \n" +
                     "b. Pendant \n" +
                     "c. Earrings \n" +
                     "d. Bracelet \n" +
                     "e. Earstud \n" +
                     "f. Anklet \n" +
                     "g. Ring \n" +
                     "h. Set \n"
                     );
                    var typeOption = Console.ReadLine();

                    Console.Write("What is the price of the jewelry?\n");
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


                    jewel = Jeweler.AddNewJewelry(jewDesc,
                        SetMaterial(matOption), SetType(typeOption), price,
                        SetCategory(catOption), jCode);

                }
            }
            catch (DbEntityValidationException dbe)
            {

                Console.WriteLine("Failed creating the jewel - {0}" , dbe.Message);
            }
            catch (Exception)
            {

                throw;
            }
           
            return jewel;

        }

        private static CategoryJewelry SetCategory(string catOption)
        {
            return (catOption.Equals("a") ? CategoryJewelry.Female :
                                (catOption.Equals("b") ? CategoryJewelry.Male :
                                CategoryJewelry.Children));
        }

        private static string SetMaterial(string matOption)
        {
            return (matOption.Equals("a") ? MaterialJewelry.Crystal :
                                (matOption.Equals("b") ? MaterialJewelry.Terracotta :
                                (matOption.Equals("c") ? MaterialJewelry.Pearl :
                                (matOption.Equals("d") ? MaterialJewelry.Bead :
                                (matOption.Equals("e") ? MaterialJewelry.Crystal :
                                (matOption.Equals("f") ? MaterialJewelry.Gold :
                                MaterialJewelry.Platinum
                                ))))));
        }

        private static string SetType(string typeOption)
        {
            return (typeOption.Equals("a") ? TypeJewelry.Chain :
                                (typeOption.Equals("b") ? TypeJewelry.Pendant :
                                (typeOption.Equals("c") ? TypeJewelry.Earrings :
                                (typeOption.Equals("d") ? TypeJewelry.Bracelet :
                                (typeOption.Equals("e") ? TypeJewelry.Earstud :
                                (typeOption.Equals("f") ? TypeJewelry.Anklet :
                                (typeOption.Equals("g") ? TypeJewelry.Ring:
                                TypeJewelry.Set
                                )))))));
        }

        private static Jewelry VerifyJewel( out string jCode)
        {
            Jewelry jewel;
            Console.Write("What is the code for the jewelry?\n");
            jCode = Console.ReadLine();
            jewel = Jeweler.FindJewel(jCode);
           
            return jewel;
        }

        private static Customer CreateCustomer(string email)
        {
            Customer customer;
            Console.Write("What is the first name of the customer?\n");
            var fName = Console.ReadLine();
            Console.Write("What is the last name of the customer?\n");
            var lName = Console.ReadLine();
            Console.Write("What is the phone number of the customer?\n");
            var phoneNo = Console.ReadLine();
            Console.Write("What is the address of the customer?\n");
            var addrDetails = Console.ReadLine();
            Console.Write("What the Gender of the Customer (M / F)?\n");
            var genderCust = Console.ReadLine();
            customer = Jeweler.AddNewCustomer(fName, lName,
                (genderCust.Equals("M") ? CategoryGender.Male :
            CategoryGender.Female), phoneNo, addrDetails, email);
            return customer;
        }

        static List<Jewelry> PrepareJewelList(int jewelCnt)
        {
            List<Jewelry> jewOrd = new List<Jewelry>();
            if (jewelCnt > 0)
            {
                for (int j = 0; j < jewelCnt; j++)
                {
                 
                    var jwel = CreateJewel();
                    if (jwel != null)
                    {
                        jewOrd.Add(jwel);
                    }

                }
            }
            else
            {
                Console.Write("No jewels were added to this order.\n");
            }
            return jewOrd;
        }

    }
}
