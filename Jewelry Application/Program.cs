using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var FirstJewelry = new Jewelry();
            FirstJewelry.SetId(00001);
            FirstJewelry.JewelryMaterial = MaterialJewelry.Terracotta;
            FirstJewelry.JewelryDesc = "Beautiful jewelry set";
            FirstJewelry.JewelryCategory = CategoryJewelry.Female;
            FirstJewelry.JewelryType = TypeJewelry.Set;
           
            FirstJewelry.SetPrice(100.00);
            FirstJewelry.PrintDetails();
            FirstJewelry.SetDiscount(.1);
            FirstJewelry.ApplyDiscount();
           

            var SecondJewelry = new Jewelry();
            SecondJewelry.SetId(00002);
            SecondJewelry.JewelryMaterial = MaterialJewelry.Bead;
            SecondJewelry.JewelryDesc = "Cool bead bracelet";
            SecondJewelry.JewelryCategory = CategoryJewelry.Female;
            SecondJewelry.JewelryType = TypeJewelry.Bracelet;

            SecondJewelry.SetPrice(20.00);
            SecondJewelry.PrintDetails();
            



        }
    }
}
