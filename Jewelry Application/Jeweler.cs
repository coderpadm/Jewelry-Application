using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    public static class Jeweler
    {

        #region Variables
        private static JewelerModel db = new JewelerModel();
        #endregion


        /// <summary>
        /// Adds a new piece of jewelry
        /// </summary>
        /// <param name="jewelryDesc">Description of the jewelry</param>
        /// <param name="jewelryMaterial">Material of the jewelry</param>
        /// <param name="jewelryType">Type of the jewelry</param>
        /// <param name="jewelryPrice">Price of the jewelry</param>
        /// <param name="jewelryCategory">Category of the jewelry</param>
        /// <param name="jewelryCode">Code of the jewelry</param>
        /// <returns>Newly created jewelry</returns>
        public static Jewelry AddNewJewelry(string jewelryDesc, string jewelryMaterial,
            string jewelryType, double jewelryPrice, CategoryJewelry jewelryCategory, string jewelryCode)
        {
            //Initializer for jewelry
            var jewelry = new Jewelry(jewelryPrice)
            {
                JewelryDesc = jewelryDesc,
                JewelryMaterial = jewelryMaterial,
                JewelryType = jewelryType,
                JewelryCategory = jewelryCategory,
                JewelryCode=jewelryCode
            };

            db.Jewels.Add(jewelry);
            db.SaveChanges();

            return jewelry;
        }

        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="customerFirstName">Customer's first name</param>
        /// <param name="customerLastName">Customer's last name</param>
        /// <param name="customerGender">Customer's gender</param>
        /// <param name="customerPhoneNumber">Customer's phone number</param>
        /// <param name="customerAddress">Customer's address</param>
        /// <param name="customerEmail">Customer's email address</param>
        /// <returns>Newly added customer</returns>
        public static Customer AddNewCustomer(string customerFirstName, string customerLastName,
            CategoryGender customerGender, string customerPhoneNumber, string customerAddress, string customerEmail)
        {
            //Initializer for customer
            var customer = new Customer(customerFirstName, customerLastName)
            {
                CustomerGender = customerGender,
                CustomerPhoneNumber = customerPhoneNumber,
                CustomerAddress = customerAddress,
                CustomerEmail = customerEmail
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;
        }
        /// <summary>
        ///Searches for a customer
        /// </summary>
        /// <param name="email">Customer's email address</param>
        /// <returns>Customer object associated with that email address</returns>
        public static Customer FindCustomer(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email address cannot be empty");
            }
            return db.Customers.Where(a => a.CustomerEmail == email).FirstOrDefault();
        }

        /// <summary>
        /// Searches for a jewel
        /// </summary>
        /// <param name="jewelCode">Jewelry's code</param>
        /// <returns>Jewelry object associated with that jewel code</returns>
        public static Jewelry FindJewel(string jewelCode)
        {
            if(string.IsNullOrEmpty(jewelCode))
            {
                throw new ArgumentNullException("Jewel code cannot be empty");
            }
            return db.Jewels.Where(j => j.JewelryCode == jewelCode).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="cust">Customer object</param>
        /// <param name="jewList">Jewelry object list</param>
        /// <returns>Newly generated order</returns>
        public static Order CreateNewOrder(Customer cust, List<Jewelry> jewList)
        {
            Order ord = new Order(cust, jewList);

            db.Orders.Add(ord);
            db.SaveChanges();
            return ord;
        }
    }
}

