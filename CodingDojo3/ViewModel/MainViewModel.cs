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
        private ObservableCollection<Item> itemListWithoutDeleted = new ObservableCollection<Item>();

        private ObservableCollection<Item> filteredList = new ObservableCollection<Item>();
        private ObservableCollection<string> comboBoxList = new ObservableCollection<String>();

            
        private Item selectedItem; 
        private string selectedName;
        private string searchText;

        private RelayCommand deleteBtnClickedCommand;
        private RelayCommand searchBtnClickedCommand;
        private RelayCommand filterBtnClickedCommand;


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
    
        public RelayCommand SearchBtnClickedCommand
        {
           get
           {
               return searchBtnClickedCommand;
           }

           set
           {
               searchBtnClickedCommand = value;
           }
        }

        public RelayCommand FilterBtnClickedCommand
        {
            get
            {
                return filterBtnClickedCommand;
            }

            set
            {
                filterBtnClickedCommand = value;
            }
        }

        public string SelectedName
        {
           get
           {
               return selectedName;
           }

           set
           {
               selectedName = value;
           }
        }

        public string SearchText
        {
            get
            {
                return searchText;
            }

            set
            {
                searchText = value;
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

        public ObservableCollection<string> ComboBoxList
        {
           get
           {
               return comboBoxList;
           }

           set
           {
               comboBoxList = value;
           }
        }

        public ObservableCollection<Item> FilteredList
        {
           get
           {
               return filteredList;
           }

           set
           {
               filteredList = value;
           }
        }

        public ObservableCollection<Item> ItemListWithoutDeleted
        {
            get
            {
                return itemListWithoutDeleted;
            }

            set
            {
                itemListWithoutDeleted = value;
            }
        }

        

        public MainViewModel()
        {
            //Interpretation: Der Filter, der auf dem Namen basiert sein soll, basiert bei mir auf dem Namen der Kategorie bzw. Gruppe, da das meiner Meinung nach mehr Sinn hat.

            LoadAllData();

            CreateComboBoxList();

            DeleteBtnClickedCommand = new RelayCommand(new Action(DeleteItem));

            SearchBtnClickedCommand = new RelayCommand(new Action(Search));

            FilterBtnClickedCommand = new RelayCommand(new Action(Filter));
        }

        private void Search()
        {
            foreach (Item i in itemListWithoutDeleted)
            {
                if (i.Name.Contains(searchText))
                {
                    FilteredList.Add(i);
                }
            }
            itemList.Clear();
            foreach (Item it in FilteredList)
            {
                itemList.Add(it);
            }
            filteredList.Clear();
        }

        private void CreateComboBoxList()
        {
            
            for (int i = 0; i < itemList.Count; i++)
            {
                if (i == 0)
                {
                    comboBoxList.Add("Alle");
                    comboBoxList.Add(itemList[i].Group.Name);
                }
                else if (!itemList[i].Group.Name.Equals(itemList[i - 1].Group.Name))
                {
                    comboBoxList.Add(itemList[i].Group.Name);
                }
            }
        } 

        private void LoadAllData()
        {
            SampleManager manager = new SampleManager();
            stocklist = manager.CurrentStock.OnStock;
            foreach (var i in stocklist)
            {
                itemList.Add(new Item(i));
                itemListWithoutDeleted.Add(new Item(i));
            }
        }

        private void DeleteItem()
        {
            itemListWithoutDeleted.Remove(SelectedItem);
            SelectedItem = null;
            Filter();
        }

        private void Filter()
        {
            itemList.Clear();
            if(selectedName == null || selectedName.Equals("Alle"))
            {
                foreach (Item i in itemListWithoutDeleted)
                {
                    itemList.Add(i);
                }
            }
            else
            {
                foreach (Item i in itemListWithoutDeleted)
                {
                    if (i.Group.Name.Equals(selectedName))
                    {
                        FilteredList.Add(i);
                    }
                }
                itemList.Clear();
                foreach (Item it in FilteredList)
                {
                    itemList.Add(it);
                }
                filteredList.Clear();
            }
        }       
    }
}
