using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    public static class Jeweler
    {
        /// <summary>
        /// Adds a new piece of jewelry
        /// </summary>
        /// <param name="jewelryDesc">Description of the jewelry</param>
        /// <param name="jewelryMaterial">Material of the jewelry</param>
        /// <param name="jewelryType">Type of the jewelry</param>
        /// <param name="jewelryPrice">Price of the jewelry</param>
        /// <param name="jewelryCategory">Category of the jewelry</param>
        /// <returns>Newly created jewelry</returns>
        public static Jewelry AddNewJewelry(string jewelryDesc, string jewelryMaterial,
            string jewelryType, double jewelryPrice, CategoryJewelry jewelryCategory)
        {
            //Initializer for jewelry
            var jewelry = new Jewelry(jewelryPrice)
            {
                JewelryDesc = jewelryDesc,
                JewelryMaterial = jewelryMaterial,
                JewelryType = jewelryType,
                JewelryCategory = jewelryCategory            
            };
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
        /// <returns>Newly added customer</returns>
        public static Customer AddNewCustomer(string customerFirstName, string customerLastName,
            CategoryGender customerGender, string customerPhoneNumber, string customerAddress)
        {
            //Initializer for customer
            var customer = new Customer(customerFirstName, customerLastName)
                           {
                                CustomerGender=customerGender,
                                CustomerPhoneNumber=customerPhoneNumber,
                                CustomerAddress=customerAddress
                           };
            return customer;
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="cust">Customer object</param>
        /// <param name="jewArr">Jewelry object array</param>
        /// <returns>Newly generated order</returns>
        public static Order CreateNewOrder(Customer cust, Jewelry[] jewArr)
        {
            Order ord =new Order(cust, jewArr);
            return ord;
        }
   }
}

