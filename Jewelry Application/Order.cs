using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    class Order
    {

        #region Variables
        private static int lastOrderId = 0;
        #endregion

        #region Properties
        public int OrderId { get; private set; }
        public int[] OrderJewelryIds { get; private set; }
        public Jewelry[] OrderJewelryDetails { get; set; }
        public DateTime OrderBoughtDateTime { get; private set; }
       
        public double OrderTotal { get; set; }
        public int OrderDiscount { get; set; }
        public Customer OrderCustomer { get; set; }
        public int OrderCustomerId { get; private set; }

        #endregion

        #region Constructor
        public Order(Customer cust, Jewelry[] jewelryOrderedArr) {
            this.OrderId = ++lastOrderId;
            this.OrderBoughtDateTime = DateTime.Now;
            this.OrderCustomer = cust;
            
            this.OrderJewelryDetails = jewelryOrderedArr;
            SetCustomerId();
            SetJewelryIds(this.OrderJewelryDetails);
            
            cust.ProcessOrder(this);
        }
        #endregion

        #region Methods

        /// <summary>
        /// To set the Customer's id
        /// </summary>
        private void SetCustomerId() {
           
            this.OrderCustomerId = this.OrderCustomer.CustomerId;
           
        }
        /// <summary>
        /// Print an order's details
        /// </summary>
        public void GetOrderDetails() {
            Console.WriteLine(" Order Id: {0} \n Jewelry Ids: {1} \n CustomerId: {2} \n " +
                "Order Bought Date and Time: {3} \n Order Discount: {4:p} \n Order Total: {5:c} \n",
               this.OrderId, (this.OrderJewelryIds==null)?"Not available":string.Join(", ", this.OrderJewelryIds), this.OrderCustomerId,
               this.OrderBoughtDateTime,this.OrderDiscount,this.OrderTotal);
            
        }

        /// <summary>
        /// To set the Jewelry ids
        /// </summary>
        /// <param name="jewArr"></param>
        private void SetJewelryIds(Jewelry[] jewArr)
        {
           
            int len = jewArr.Length;
            double total = 0.0;
            if ( len> 0)
            {
                int[] jewIdArr = new int[len];
                for(int i=0; i< len;i++)
                {
                    jewIdArr[i] = jewArr[i].JewelryId;
                    total += jewArr[i].GetPrice();

                }
                this.OrderJewelryIds = jewIdArr;
                this.OrderTotal = total;
                
            }

            
        }

        
        #endregion
    }
}
