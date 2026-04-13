using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieAp.Domain.Entities;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieApi.Persistence.Context
{
    public class MovieContext:  IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MSI\\SQLEXPRESS;initial Catalog=MovieApiDb;integrated Security=true; TrustServerCertificate=true"
                );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //iliskinin sebebi cunnku bende user Identity icinde ve review domain icinde 
            //yani domain poerstince gormemeli 

            base.OnModelCreating(builder);

            //builder.Entity<Review>()
            //.HasOne<AppUser>()
            //.WithMany()
            //// Navigation yok!
            //.HasForeignKey(r => r.UserId)
            //.OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Review>()
             .HasOne<AppUser>()
             .WithMany()
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            //if we want to delete a season we would to delete Episodes and his Reviws

            // Season silinince → içindeki Episode'lar da silinsin
            builder.Entity<Season>()
                .HasMany(s => s.Episodes)
                .WithOne(e => e.Season)
                .HasForeignKey(e => e.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);  // ← burası

            // Episode silinince → içindeki Review'lar da silinsin
            builder.Entity<Episode>()
                .HasMany(e => e.Reviews)
                .WithOne(r => r.Episode)
                .HasForeignKey(r => r.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);  // ← burası

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Series> Serieses { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Season> seasons { get; set; }
        public DbSet<SeriesCast> SeriesCasts { get; set; }
        public DbSet<UserWatch> UserWatchs { get; set; }
        public DbSet<Purchase> purchases { get; set; }

    }
}
