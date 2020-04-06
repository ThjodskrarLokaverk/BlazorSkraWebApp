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

            //Create the Composite key for the CategoriesAssignments table
            modelBuilder.Entity<CategoriesAssignments>()
                    .HasOne<Categories>(c => c.Categories)
                    .WithMany()
                    .HasForeignKey(c => c.CategoryId);
            
            modelBuilder.Entity<CategoriesAssignments>()
                    .HasOne<FormsInfo>(f => f.FormsInfo)
                    .WithMany()
                    .HasForeignKey(f => f.FormId);

            modelBuilder.Entity<CategoriesAssignments>()
                .HasKey(ca => new { ca.CategoryId, ca.FormId});

            //Create the Composite key for the QuestionsFormAssignments table
            modelBuilder.Entity<QuestionsFormAssignments>()
                    .HasOne<Questions>(q => q.Questions)
                    .WithMany()
                    .HasForeignKey(q => q.QuestionId);

            modelBuilder.Entity<QuestionsFormAssignments>()
                    .HasOne<FormsInfo>(f => f.FormsInfo)
                    .WithMany()
                    .HasForeignKey(f => f.FormId);

            modelBuilder.Entity<QuestionsFormAssignments>()
                .HasKey(qfa => new { qfa.FormId, qfa.QuestionOrderNum });

            //Create the Composite key for the OptionsQuestionAssignmnents table
            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                    .HasOne<Options>(o => o.Options)
                    .WithMany()
                    .HasForeignKey(o => o.OptionId);

            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                    .HasOne<QuestionsFormAssignments>(qfa => qfa.QuestionsFormAssignments)
                    .WithMany()
                    .HasForeignKey(qfa => new { qfa.FormId, qfa.QuestionOrderNum });

            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                .HasKey(oqa => new { oqa.FormId, oqa.QuestionOrderNum, oqa.OptionOrderNum });
        }


        public DbSet<Options> Options { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<FormsInfo> FormsInfo { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<SubmissionsInfo> SubmissionsInfo { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoriesAssignments> CategoriesAssignments { get; set; }
        public DbSet<QuestionsFormAssignments> QuestionsFormAssignments { get; set; }
        public DbSet<OptionsQuestionAssignmnents> OptionsQuestionAssignmnents { get; set; }
        
        

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
