using Empyreum.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls.Primitives;

namespace Empyreum.Data
{
    public class CharacterData
    {
        public static void AddCharToDb(Character chara)
        {
            using (var db = new ItemContext())
            {
                db.Characters.Add(chara);
                db.SaveChanges();
            }
        }

        public static void RemoveCharFromDb(Character chara)
        {
            using (var db = new ItemContext())
            {
                var charToRemove = db.Characters.OrderBy(e =>e.Id).Include(e => e.CharItems).First();
                db.Characters.Remove(charToRemove);
                db.SaveChanges();
            }
        }

        public static void AddItemToChar(Character chara, Item item)
        {
            using (var db = new ItemContext())
            {
                var change = db.Characters.Single(e => e.Id == chara.Id);
                change.CharItems.Add(item);
                db.SaveChanges();
            }
        }

        public static void RemoveItemFromChar(Character chara, Item item)
        {
            using (var db = new ItemContext())
            {
                // COMPLETE: Fix the query in RemoveItemFromChar; should return only one item at a time to remove.
                var change = db.Characters.Include(ch => ch.CharItems).SingleOrDefault(c => c.Id == chara.Id);
                foreach(Item itemCheck in change.CharItems.ToList())
                {
                    if(itemCheck.Name == item.Name)
                    {
                        change.CharItems.Remove(itemCheck);
                    }
                }
                db.SaveChanges();
            }
        }

        public static List<Character> GetCharacters()
        {
            using (var db = new ItemContext())
            {
                return db.Characters.ToList();
            }
        }

        public static List<Item> GetCharacterItems(Character chara)
        {
            using (var db = new ItemContext())
            {
                var itemsToGet = db.Characters.Include(e => e.CharItems).SingleOrDefault(c => c.Id == chara.Id);
                return itemsToGet.CharItems.ToList();
            }
        }
    }
}
