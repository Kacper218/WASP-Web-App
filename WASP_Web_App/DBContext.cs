using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WASP_Web_App;
using WASP_Web_App.Entities;


namespace WASP_Web_App
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Auth> Auth { get; set; }
        public DbSet<GroupKeys> GroupKeys { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Keys> Keys { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<SpecialPermissions> SpecialPermissions { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
            .HasOne(e => e.Auth)
            .WithOne(e => e.Users)
            .HasForeignKey<Auth>(e => e.User_ID);

            modelBuilder.Entity<Users>()
            .HasMany(e => e.Permissions)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<Users>()
            .HasMany(e => e.SpecialPermissions)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<Users>()
            .HasMany(e => e.Rent)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.User_ID);



            modelBuilder.Entity<Keys>()
            .HasMany(e => e.GroupKeys)
            .WithOne(e => e.Keys)
            .HasForeignKey(e => e.Key_ID);

            modelBuilder.Entity<Keys>()
            .HasMany(e => e.SpecialPermissions)
            .WithOne(e => e.Keys)
            .HasForeignKey(e => e.Key_ID);

            modelBuilder.Entity<Keys>()
            .HasMany(e => e.Rent)
            .WithOne(e => e.Keys)
            .HasForeignKey(e => e.Key_ID);



            modelBuilder.Entity<Groups>()
            .HasMany(e => e.GroupKeys)
            .WithOne(e => e.Groups)
            .HasForeignKey(e => e.Group_ID);

            modelBuilder.Entity<Groups>()
            .HasMany(e => e.Permissions)
            .WithOne(e => e.Groups)
            .HasForeignKey(e => e.Group_ID);




            modelBuilder.Entity<Auth>()
            .HasOne(e => e.Users)
            .WithOne(e => e.Auth)
            .HasForeignKey<Auth>(e => e.User_ID);



            modelBuilder.Entity<GroupKeys>()
            .HasOne(e => e.Groups)
            .WithMany(e => e.GroupKeys)
            .HasForeignKey(e => e.Group_ID);

            modelBuilder.Entity<GroupKeys>()
            .HasOne(e => e.Keys)
            .WithMany(e => e.GroupKeys)
            .HasForeignKey(e => e.Key_ID);



            modelBuilder.Entity<Permissions>()
           .HasOne(e => e.Users)
           .WithMany(e => e.Permissions)
           .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<Permissions>()
           .HasOne(e => e.Groups)
           .WithMany(e => e.Permissions)
           .HasForeignKey(e => e.Group_ID);



            modelBuilder.Entity<Rent>()
           .HasOne(e => e.Users)
           .WithMany(e => e.Rent)
           .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<Rent>()
           .HasOne(e => e.Keys)
           .WithMany(e => e.Rent)
           .HasForeignKey(e => e.Key_ID);


            modelBuilder.Entity<SpecialPermissions>()
            .HasOne(e => e.Users)
            .WithMany(e => e.SpecialPermissions)
            .HasForeignKey(e => e.User_ID);
            
            modelBuilder.Entity<SpecialPermissions>()
           .HasOne(e => e.Keys)
           .WithMany(e => e.SpecialPermissions)
           .HasForeignKey(e => e.Key_ID);

        }
    }
}
