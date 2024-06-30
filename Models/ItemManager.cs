using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empyreum.Models
{
    public class ItemManager
    {
        public static ObservableCollection<Item> _itemsDatabase = new ObservableCollection<Item>();

        public static ObservableCollection<Item> GetUsers()
        { 
            return _itemsDatabase; 
        }

        public static void AddUser(Item item)
        {
            _itemsDatabase.Add(item);
        }
    }
}
