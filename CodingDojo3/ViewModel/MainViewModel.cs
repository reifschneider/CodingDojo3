using CodingDojo4DataLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    class MainViewModel
    {

        private List<StockEntry> stocklist;

        private ObservableCollection<Item> itemList = new ObservableCollection<Item>();

        public ObservableCollection<Item> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }

        public MainViewModel()
        {
            SampleManager manager = new SampleManager();
            stocklist = manager.CurrentStock.OnStock;

            foreach(var i in manager.CurrentStock.OnStock)
            {
                itemList.Add(new Item(i));
            }
            
        }

    }
}
