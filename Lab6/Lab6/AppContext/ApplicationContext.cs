using Lab6.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab6.AppContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(u => u.Id);
            modelBuilder.Entity<CartItem>().HasKey(c => c.Id);

            modelBuilder.Entity<CartItem>().HasOne(c => c.Book).WithOne(b => b.CartItem).HasForeignKey<CartItem>(c => c.BookId);


        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); ;
        }
    }
}
