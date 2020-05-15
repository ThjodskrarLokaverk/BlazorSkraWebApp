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

            //Create the Composite key for the Submissions table
            modelBuilder.Entity<Submissions>()
                .HasOne(si => si.SubmissionInfo)
                .WithMany()
                .HasForeignKey(si => si.SubmissionId);

            modelBuilder.Entity<Submissions>()
                .HasKey(s => new { s.SubmissionId, s.QuestionOrderNum, s.AnswerOrderNum });

            //Create the Composite key for the FormsCategoryAssignments table
            modelBuilder.Entity<FormsCategoryAssignments>()
                    .HasOne(c => c.Categories)
                    .WithMany()
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<FormsCategoryAssignments>()
                    .HasOne(f => f.FormsInfo)
                    .WithMany()
                    .HasForeignKey(f => f.FormId);

            modelBuilder.Entity<FormsCategoryAssignments>()
                .HasKey(ca => new { ca.FormId });

            //Create the Composite key for the QuestionsFormAssignments table
            modelBuilder.Entity<QuestionsFormAssignments>()
                    .HasOne(q => q.Questions)
                    .WithMany()
                    .HasForeignKey(q => q.QuestionId);

            modelBuilder.Entity<QuestionsFormAssignments>()
                    .HasOne(f => f.FormsInfo)
                    .WithMany()
                    .HasForeignKey(f => f.FormId);

            modelBuilder.Entity<QuestionsFormAssignments>()
                .HasKey(qfa => new { qfa.FormId, qfa.QuestionOrderNum });

            //Create the Composite key for the OptionsQuestionAssignmnents table
            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                    .HasOne(o => o.Options)
                    .WithMany()
                    .HasForeignKey(o => o.OptionId);

            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                    .HasOne(qfa => qfa.QuestionsFormAssignments)
                    .WithMany()
                    .HasForeignKey(qfa => new { qfa.FormId, qfa.QuestionOrderNum });

            modelBuilder.Entity<OptionsQuestionAssignmnents>()
                .HasKey(oqa => new { oqa.FormId, oqa.QuestionOrderNum, oqa.OptionOrderNum });

            //Seed the database with data on the questiontypes used in the application
            modelBuilder.Entity<QuestionTypes>().HasData(
                new QuestionTypes
                {
                    QuestionTypeId = 1,
                    QuestionTypeName = "Stuttur texti",
                    QuestionType = "ShortText"
                },
                new QuestionTypes
                {
                    QuestionTypeId = 3,
                    QuestionTypeName = "Langur texti",
                    QuestionType = "LongText"
                },
                new QuestionTypes
                {
                    QuestionTypeId = 4,
                    QuestionTypeName = "Einval",
                    QuestionType = "Radio"
                },
                new QuestionTypes
                {
                    QuestionTypeId = 5,
                    QuestionTypeName = "Fjölval",
                    QuestionType = "Checkbox"
                },
                new QuestionTypes
                {
                    QuestionTypeId = 6,
                    QuestionTypeName = "Dagsetning",
                    QuestionType = "Date"
                });
        }


        public DbSet<Options> Options { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<FormsInfo> FormsInfo { get; set; }
        public DbSet<SubmissionsInfo> SubmissionsInfo { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<FormsCategoryAssignments> FormsCategoryAssignments { get; set; }
        public DbSet<QuestionsFormAssignments> QuestionsFormAssignments { get; set; }
        public DbSet<OptionsQuestionAssignmnents> OptionsQuestionAssignmnents { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
