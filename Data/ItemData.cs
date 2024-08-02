﻿using Empyreum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empyreum.Data
{
    public class ItemData
    {
        public static void AddItemToDb(Item item)
        {
            using (var db = new ItemContext())
            {
                db.Add(item);
                db.SaveChanges();
            }
        }

        public static void RemoveItemFromDb(Item item)
        {
            using (var db = new ItemContext())
            {
                db.Remove(item);
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
