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

        public int ID { get; set; }

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
