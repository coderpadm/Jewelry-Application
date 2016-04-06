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
    enum CategoryJewelry {
        Female, Male,Children
    }

    /// <summary>
    /// Type of Jewelry material
    /// </summary>
    enum MaterialJewelry
    {
        Crystal,Terracotta,Pearl,Bead,Silver,Gold,Platinum
    }

    /// <summary>
    /// Type or kind of Jewelry 
    /// </summary>
    enum TypeJewelry
    {
        Chain,Pendant,Earrings,Bracelet,Earstud,Anklet,Ring,Set
    }
    #endregion

    /// <summary>
    /// This class is used to store Jewelry details
    /// </summary>
    class Jewelry
    {
        #region Properties
        public int JewelryId { get; private set; }
        public String JewelryDesc{ get; set; }
        public MaterialJewelry JewelryMaterial { get; set; }
        public TypeJewelry JewelryType { get; set; }
        public double JewelryPrice { get; private set; }
        public CategoryJewelry JewelryCategory { get; set; }
        public double JewelryDiscount { get; private set; }
        #endregion


        #region Methods
        
        /// <summary>
        /// To set the id of an item
        /// </summary>
        public double SetId(int Id) {
            this.JewelryId = Id;
            return this.JewelryId;
        }

        /// <summary>
        /// To set the price of an item
        /// </summary>
        public double SetPrice(double Price) {
            this.JewelryPrice = Price;
            return this.JewelryPrice;
        }

        /// <summary>
        /// To set the discount of an item
        /// </summary>
        public double SetDiscount(double Discount) {
            this.JewelryDiscount = Discount;
            return this.JewelryDiscount;
        }

        /// <summary>
        /// To apply discount to an item
        /// </summary>
        public void ApplyDiscount() {

            if(this.JewelryDiscount > 0)
            {
                Console.WriteLine(" Applying {0:p} discount to Jewelry Id: {1:d5} , Jewelry Name: {2} ", this.JewelryDiscount, this.JewelryId, this.JewelryDesc);
                this.JewelryPrice = this.JewelryPrice - (this.JewelryPrice * (this.JewelryDiscount));
                PrintPrice();
            }
           

        }

        /// <summary>
        /// Print a jewelry's details
        /// </summary> 
        public void PrintDetails() {
            Console.WriteLine(" Jewelry Id: {0:d5} \n Jewelry Name: {1} \n Jewelry Material: {2} \n "+
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


        
        #endregion

    }
}
