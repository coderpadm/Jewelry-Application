using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    public class Order
    {

        #region Variables
        private static int lastOrderId = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Order id of an order
        /// </summary>
        [Key]
        public int OrderId { get; private set; }
        public List<Jewelry> OrderJewelryDetails { get; set; }
        public DateTime OrderBoughtDateTime { get; private set; }
        public double OrderTotal { get; set; }
        public int OrderDiscount { get; set; }
        public Customer OrderCustomer { get; set; }
       
        #endregion

        #region Constructor
        public Order(Customer cust, List<Jewelry> jewelryList) {
            this.OrderId = ++lastOrderId;
            this.OrderBoughtDateTime = DateTime.Now;
            this.OrderCustomer = cust;
            this.OrderJewelryDetails = jewelryList;
            this.OrderTotal = setOrderTotal(jewelryList);
           
        }
        #endregion

        #region Methods
        /// <summary>
        /// To compute the total of an order
        /// </summary>
        /// <param name="jewList">List of Jewelry items</param>
        /// <returns>Specifies the order's total</returns>
        private double setOrderTotal(List<Jewelry> jewList) {
            double total = 0.0;
            if (jewList.Count > 0)
            {
                foreach (var jewel in jewList)
                {
                    total += jewel.GetPrice();
                }
            }
            return total;

        }
        
        #endregion
    }
}
