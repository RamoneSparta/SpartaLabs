namespace Lab32_Gym_Website_MVC_Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Lab32_Gym_Website_MVC_Core.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.SqlServer;


    public partial class GymModel : DbContext
    {
        public GymModel(DbContextOptions<GymModel> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkoutLog> WorkoutLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.ExerciseName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
