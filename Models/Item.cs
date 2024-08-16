using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Empyreum.Models.Item;

namespace Empyreum.Models
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // ID From XIVAPI
        public int ID { get; set; }

        // ID to be used for Sqlite
        public int ItemServerId {  get; set; }

        public int? CharID { get; set; }

        public Character? Character { get; set; }

        public string Icon { get; set; }

        public Item()
        {
            Name = "?NAME?";
            Description = "?DESCRIPTION?";
            ID = 777;
            Icon = "?ICONPATH?";
        }
    }
}
