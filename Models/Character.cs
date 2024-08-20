using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empyreum.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Race { get; set; }

        public string Clan { get; set; }

        public CharGender Gender { get; set; }

        public CharBirthday Birthday { get; set; }

        public CharDeity Deity { get; set; }

        public CharJob Job { get; set; }

        public string PhysicalDCName { get; set; }

        public string LogicalDCName { get; set; }

        public ICollection<Item> CharItems { get; set; } = new List<Item>();
    }
}
