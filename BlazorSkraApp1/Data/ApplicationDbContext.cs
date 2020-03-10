 using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorSkraApp1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Forms>()
                    .HasOne<FormsInfo>(f => f.Form)
                    .WithMany()
                    .HasForeignKey(f => f.FormId);


            modelBuilder.Entity<Forms>()
                .HasKey(f => new { f.QuestionOrderNum, f.OptionOrderNum, f.FormId});
        }

        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<FormsInfo> FormsInfo { get; set; }
        public DbSet<QuestionOptions> QuestionOptions { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Forms> Forms { get; set; }



        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
