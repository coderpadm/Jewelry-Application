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
                Console.WriteLine("Applying {0:p} discount to Jewelry Id: {1} , Jewelry Name: {2} ", this.JewelryDiscount, this.JewelryId, this.JewelryDesc);
                this.JewelryPrice = this.JewelryPrice - (this.JewelryPrice * (this.JewelryDiscount));
               
                PrintPrice();
            }
           

        }

        /// <summary>
        /// Print a jewelry's details
        /// </summary> 
        public void PrintDetails() {
            Console.WriteLine(" Jewelry Id: {0} \n Jewelry Name: {1} \n Jewelry Material: {2} \n "+
                "JewelryType: {3} \n JewelryPrice: {4:c} \n Jewelry Category: {5} \n Jewelry Discount: {6:p} \n", 
                this.JewelryId, this.JewelryDesc, this.JewelryMaterial,
                this.JewelryType, this.JewelryPrice, this.JewelryCategory, this.JewelryDiscount
                );

        }
        /// <summary>
        /// To print the price of an item
        /// </summary>
        public void PrintPrice()
        {
            Console.WriteLine(" Jewelry Price: {0:c}  \n",  this.JewelryPrice);
        }

        public double GetPrice() {
            return this.JewelryPrice;

        }


        
        #endregion

    }
}
