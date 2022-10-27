using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WebAPI.Models
{
    public partial class UmulyDbContext: DbContext
    {
        public UmulyDbContext()
        {

        }
        public UmulyDbContext(DbContextOptions<UmulyDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=db_GKumuly;MultipleActiveResultSets=true;Trusted_Connection=True;");
            }
        }
        public virtual DbSet<Offer> Offers { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");
            OnModelCreatingPartial(modelBuilder);



     
         
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}