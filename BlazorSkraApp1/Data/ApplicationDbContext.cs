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

            //Create the Composite key for the Forms table
            modelBuilder.Entity<Forms>()
                    .HasOne<FormsInfo>(fi => fi.Form)
                    .WithMany()
                    .HasForeignKey(fi => fi.FormId);


            modelBuilder.Entity<Forms>()
                .HasKey(f => new { f.QuestionOrderNum, f.OptionOrderNum, f.FormId});

            //Create the Composite key for the Submissions table
            modelBuilder.Entity<Submissions>()
                .HasOne<SubmissionsInfo>(si => si.Submission)
                .WithMany()
                .HasForeignKey(si => si.SubmissionId);

            modelBuilder.Entity<Submissions>()
                .HasOne<FormsInfo>(fi => fi.Form)
                .WithMany()
                .HasForeignKey(fi => fi.FormId);

            modelBuilder.Entity<Submissions>()
                .HasKey(s => new { s.SubmissionId, s.FormId, s.QuestionOrderNum, s.AnswerOrderNum });
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
