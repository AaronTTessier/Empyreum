using Microsoft.EntityFrameworkCore;

namespace Empyreum.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Character> Characters { get; set; }

        public string liteConn = @"Item.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {liteConn}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasMany(e => e.CharItems)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharID)
                .IsRequired(false);
            modelBuilder.Entity<Item>()
                .HasKey(e => e.ItemServerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
