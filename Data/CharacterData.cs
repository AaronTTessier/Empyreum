using Empyreum.Models;
using Microsoft.EntityFrameworkCore;

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
                var change = db.Items.Single(e => e.CharID == chara.Id);
                change.CharID = null;
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
    }
}
