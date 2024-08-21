using Empyreum.Models;

namespace Empyreum.Data
{
    public class ItemData
    {
        public static void AddItemToDb(Item item)
        {
            using (var db = new ItemContext())
            {
                db.Items.Add(item);
                db.SaveChanges();
            }
        }

        public static void RemoveItemFromDb(Item item)
        {
            using (var db = new ItemContext())
            {
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }

        public static List<Item> GetItems()
        {
            using (var db = new ItemContext())
            {
                return db.Items.ToList();
            }
        }

    }
}
