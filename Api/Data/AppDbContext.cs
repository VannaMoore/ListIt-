using Microsoft.EntityFrameworkCore;
using Api.Models;
using ListEntity = Api.Models.List; // To avoid confusion with the List class in C#


namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ListEntity> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ListItemTag> ListItemTags { get; set; }
        public DbSet<ListUser> ListUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for ListUser
            modelBuilder.Entity<ListUser>()
                .HasKey(lu => new { lu.ListId, lu.UserId }); // This line is fine

            modelBuilder.Entity<ListUser>()
                .HasOne(lu => lu.List)
                .WithMany(l => l.SharedUsers)
                .HasForeignKey(lu => lu.ListId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ListUser>()
                .HasOne(lu => lu.User)
                .WithMany(u => u.SharedLists)
                .HasForeignKey(lu => lu.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ListEntity>()
                .HasOne(l => l.Owner)
                .WithMany(u => u.OwnedLists)
                .HasForeignKey(l => l.OwnerId);

            modelBuilder.Entity<ListItem>()
                .HasOne(li => li.List)
                .WithMany()
                .HasForeignKey(li => li.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListItem>()
                .HasOne(li => li.ParentItem)
                .WithMany(pi => pi.SubItems)
                .HasForeignKey(li => li.ParentItemId)
                .OnDelete(DeleteBehavior.Restrict);

            //Composite key for ListItemTag
            modelBuilder.Entity<ListItemTag>()
                .HasKey(lit => new { lit.ListItemId, lit.TagId });

            modelBuilder.Entity<ListItemTag>()
                .HasOne(lit => lit.ListItem)
                .WithMany(li => li.ListItemTags)
                .HasForeignKey(lit => lit.ListItemId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ListItemTag>()
                .HasOne(lit => lit.Tag)
                .WithMany(t => t.ListItemTags)
                .HasForeignKey(lit => lit.TagId)
                .OnDelete(DeleteBehavior.Restrict); 



        }
    }
}
