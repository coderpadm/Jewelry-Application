using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    #region enum

    /// <summary>
    /// Jewelry categorization
    /// </summary>
    public enum CategoryJewelry {
        Female, Male,Children
    }
    
    #endregion

    /// <summary>
    /// This class is used to store Jewelry details
    /// </summary>
    public class Jewelry
    {
        #region Variables
        private static int lastJewelryId=0;
        #endregion


        #region Properties
        public int JewelryId { get; private set; }
        public string JewelryDesc{ get; set; }
        public string JewelryMaterial { get; set; }
        public string JewelryType { get; set; }
        public double JewelryPrice { get; private set; }
        public CategoryJewelry JewelryCategory { get; set; }
        public double JewelryDiscount { get; private set; }
        #endregion

        #region Constructor
        public Jewelry(double price) {

            JewelryId = ++lastJewelryId;
            this.JewelryPrice = price;
        }

        public Jewelry(int price,int discount)
        {

            JewelryId = ++lastJewelryId;
            this.JewelryPrice = price;
            this.JewelryDiscount = discount;
        }
        #endregion 

        #region Methods
        

        /// <summary>
        /// To set the discount of an item
        /// </summary>
        public void SetDiscount(double Discount) {
            this.JewelryDiscount = Discount;
          
        }
       
        /// <summary>
        /// To apply discount to an item
        /// </summary>
        public void ApplyDiscount() {

            if(this.JewelryDiscount > 0)
            {
               this.JewelryPrice = this.JewelryPrice - (this.JewelryPrice * (this.JewelryDiscount));
               
              
            }

        }

        /// <summary>
        /// To find a jewel's price
        /// </summary>
        public double GetPrice() {
            return this.JewelryPrice;

        }


        
        #endregion

    }
}
