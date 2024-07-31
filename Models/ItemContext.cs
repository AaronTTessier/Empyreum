using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empyreum.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public string liteConn = @"Item.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {liteConn}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
