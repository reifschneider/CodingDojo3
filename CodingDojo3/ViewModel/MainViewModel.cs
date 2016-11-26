using CodingDojo4DataLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CodingDojo3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private List<StockEntry> stocklist;

        private ObservableCollection<Item> itemList = new ObservableCollection<Item>();
        //private ObservableCollection<Item> reducedItemList = new ObservableCollection<Item>();

        private Item selectedItem;

        private RelayCommand deleteBtnClickedCommand;
       

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

        public Item SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                selectedItem = value;
            }
        }

        public RelayCommand DeleteBtnClickedCommand
        {
            get
            {
                return deleteBtnClickedCommand;
            }

            set
            {
                deleteBtnClickedCommand = value;
            }
        }


        /*
        public ObservableCollection<Item> ReducedItemList
        {
            get
            {
                return reducedItemList;
            }

            set
            {
                reducedItemList = value;
            }
        }
        */

        public MainViewModel()
        {
            SampleManager manager = new SampleManager();
            stocklist = manager.CurrentStock.OnStock;


            DeleteBtnClickedCommand = new RelayCommand(new Action(DeleteItem));

            foreach (var i in stocklist)
            {
                itemList.Add(new Item(i));
            }
        }

        private void DeleteItem()
        {
            itemList.Remove(selectedItem);
            selectedItem = null;
        }
    }
}
