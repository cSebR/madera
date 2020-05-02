using Microsoft.EntityFrameworkCore;

namespace madera.API.Models
{
    public class MaderaContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Role> Role { get; set; }

        public MaderaContext(DbContextOptions<MaderaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>().HasOne(p => p.Role).WithMany(b => b.Utilisateurs);
            modelBuilder.Entity<Utilisateur>().HasIndex(p => p.Email).IsUnique(true);
        }
    }
}
