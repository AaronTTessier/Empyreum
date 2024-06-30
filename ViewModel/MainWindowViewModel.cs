using Empyreum.Models;
using System.Collections.ObjectModel;


namespace Empyreum.ViewModel
{
    internal class MainWindowViewModel 
    {
        public ObservableCollection<Item> OwnedItems { get; set; }

        public ObservableCollection<Item> SearchedItems { get; set; }

        public Item SelectedItem { get; set; }

        public MainWindowViewModel()
        {

        }

        
    }
}
