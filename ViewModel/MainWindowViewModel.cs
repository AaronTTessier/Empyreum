using Empyreum.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel; 


namespace Empyreum.ViewModel
{
    internal class MainWindowViewModel
    {
        public ObservableCollection<Item> OwnedItems { get; set; }

        public ObservableCollection<Item> SearchedItems { get; set; }

        public ObservableCollection<Item> OwnedCharItems { get; set; }

        public ObservableCollection<Character> characters { get; set; }

        public List<Item> BufferItemList { get; set; }

        public Item SelectedItem { get; set; }

        public Item SelectedOwnedItem { get; set; }

        public Character SelectedChar { get; set; }

        public MainWindowViewModel()
        {
            
        }


    }
}
