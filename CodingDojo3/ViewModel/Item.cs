using CodingDojo4DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    public class Item
    {
        private StockEntry entry;

        public Item()
        {
           
        }

        public Item(StockEntry stEntry)
        {
            entry = stEntry;
        }


        public string Name
        {
            get
            {
                return entry.SoftwarePackage.Name;
            }

            set
            {
                entry.SoftwarePackage.Name = value;
            }
        }

        public Group Group
        {
            get
            {
                return entry.SoftwarePackage.Category;
            }

            set
            {
                entry.SoftwarePackage.Category = value;
            }
        }

        public double SalesPrice
        {
            get
            {
                return entry.SoftwarePackage.SalesPrice;
            }

            set
            {
                entry.SoftwarePackage.SalesPrice = value;
            }
        }

        public double PurchasePrice
        {
            get
            {
                return entry.SoftwarePackage.PurchasePrice;
            }

            set
            {
                entry.SoftwarePackage.PurchasePrice = value;
            }
        }

        public int OnStock
        {
            get
            {
                return entry.Amount;
            }

            set
            {
                entry.Amount = value;
            }
        }

        public override string ToString()
        {
            //return Name;
            return Group.Name;
        }


    }
}
