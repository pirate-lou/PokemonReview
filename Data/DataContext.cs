using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        // base - show all of the data 
        // u just pushing data upping to your db context
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        // DbSet<> - u'll see when u're doing the db context    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOnwer> PokemonOnwers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this's going to tell entity framework: "hey, we need to link these two ids together"
            // otherwise entity framework's not going to know that u want to link these two ids together 
            // and the relationships not going to actually exist 
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOnwer>()
                .HasKey(po => new { po.PokemonId, po.OwnerId});
            modelBuilder.Entity<PokemonOnwer>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOnwers)
                .HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokemonOnwer>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
