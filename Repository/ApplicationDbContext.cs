using Microsoft.EntityFrameworkCore;
using MyFriend.Models;

namespace MyFriend.Repository
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        ) : DbContext(options)
    {
        public DbSet<FriendModel> Friends { get; set; }
        public DbSet<ImageModel> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageModel>()
                .HasOne(i => i.Friend)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.FriendId);
        }
    }
}
