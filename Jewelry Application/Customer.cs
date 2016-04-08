using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{

    #region enum

    /// <summary>
    /// Gender
    /// </summary>
    enum CategoryGender
    {
        Female, Male
    }
    #endregion

    /// <summary>
    /// This is a Customer class.
    /// </summary>
    class Customer
    {
        #region Variables
        private static int lastCustomerId = 0;
        #endregion

        #region Properties
        public int CustomerId { get; private set; }
        public String CustomerFirstName { get; set; }
        public String CustomerLastName { get; set; }
        public Order[] CustomerOrder { get; private set; }
        public int[] CustomerOrderIds { get; private set; }
        public String CustomerAddress { get; set; }
        public String CustomerPhoneNumber { get; set; }
        public CategoryGender CustomerGender { get; set; }
        public DateTime CustomerSince { get; private set; }
        
        #endregion

        #region Constructor
        public Customer(String firstName, String lastName) {
            this.CustomerId = ++lastCustomerId;
            this.CustomerSince = DateTime.Today;
            this.CustomerFirstName = firstName;
            this.CustomerLastName = lastName;

        }

        #endregion

        #region Methods
        public void GetCustomerDetails() {
        /// <summary>
        /// Print a Customer's details
        /// </summary> 
        /// 

    

        Console.WriteLine(" Customer Id: {0} \n First Name: {1} \n Last Name: {2} \n " +
                "OrderIds: {3} \n Address: {4} \n PhoneNumber: {5} \n Gender: {6} \n Customer Since: {7:d} \n",
                this.CustomerId, this.CustomerFirstName,this.CustomerLastName,(this.CustomerOrderIds==null)?"Not available":String.Join(",",this.CustomerOrderIds),
                this.CustomerAddress, this.CustomerPhoneNumber,this.CustomerGender,this.CustomerSince.Date
                );

        
        }

        /// <summary>
        /// To set order information in the Customer object
        /// </summary>
        /// <param name="someOrd"></param>
        public void ProcessOrder(Order someOrd)
        {
            
            Order[] arrOriCustOrders = this.CustomerOrder;
            Order[] arrAddCustOrders;
            int len;
            
            if (arrOriCustOrders != null) {
                len = arrOriCustOrders.Length;
                arrAddCustOrders = new Order[len + 1];



                System.Array.Copy(arrOriCustOrders, 0, arrAddCustOrders, 0, len);
                arrAddCustOrders[len] = someOrd;
                    }
            else
            {
                len = 0;
                arrAddCustOrders = new Order[len + 1];
                arrAddCustOrders[len] = someOrd;
            }
            this.CustomerOrder = arrAddCustOrders;
            SetOrderIds(arrAddCustOrders);
           
        }

        /// <summary>
        /// To set the order ids for a Customer
        /// </summary>
        /// <param name="orArr"></param>
        private void SetOrderIds(Order[] orArr)
        {

            int len = orArr.Length;
            if (len > 0)
            {
                int[] orIdArr = new int[len];
                for (int i = 0; i < len; i++)
                {
                    orIdArr[i] = orArr[i].OrderId;
                   

                }
                this.CustomerOrderIds = orIdArr;
            }

            
        }
        #endregion 
    }
}
