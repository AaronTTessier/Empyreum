using System.Collections.ObjectModel;

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
