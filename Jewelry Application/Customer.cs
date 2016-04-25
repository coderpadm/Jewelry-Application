using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{

    #region enum

    /// <summary>
    /// Gender
    /// </summary>
    public enum CategoryGender
    {
        Female, Male
    }
    #endregion

    /// <summary>
    /// This is a Customer class.
    /// </summary>
    public class Customer
    {
        #region Variables
        private static int lastCustomerId = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Customer id of a customer
        /// </summary>
        [Key]
        public int CustomerId { get; private set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public CategoryGender CustomerGender { get; set; }
        public DateTime CustomerSince { get; private set; }
        
        #endregion

        #region Constructor
        public Customer(string firstName, string lastName) {
            this.CustomerId = ++lastCustomerId;
            this.CustomerSince = DateTime.Today;
            this.CustomerFirstName = firstName;
            this.CustomerLastName = lastName;

        }

        #endregion

      
    }
}
