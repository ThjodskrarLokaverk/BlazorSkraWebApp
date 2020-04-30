using System.Collections.Generic;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Tests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Categories.AddRange(GetSeedingCategories());
            db.Questions.AddRange(GetSeedingQuestions());
            db.Options.AddRange(GetSeedingOptions());
            db.FormsInfo.AddRange(GetSeedingForms());
            db.Submissions.AddRange(GetSeedingSubmissions());

            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Categories.RemoveRange(db.Categories);
            db.Questions.RemoveRange(db.Questions);
            db.Options.RemoveRange(db.Options);
            db.FormsInfo.RemoveRange(db.FormsInfo);
            db.Submissions.RemoveRange(db.Submissions);

            InitializeDbForTests(db);
        }

        public static List<Categories> GetSeedingCategories()
        {
            return new List<Categories>()
            {
                new Categories(){ CategoryName = "TEST: Category 1"},
                new Categories(){ CategoryName = "TEST: Category 1"},
                new Categories(){ CategoryName = "TEST: Category 1"},
            };
        }
        public static List<Questions> GetSeedingQuestions()
        {
            return new List<Questions>()
            {
                new Questions(){ QuestionName = "TEST: Question 1"},
                new Questions(){ QuestionName = "TEST: Question 1"},
                new Questions(){ QuestionName = "TEST: Question 1"},
            };
        }
        public static List<Options> GetSeedingOptions()
        {
            return new List<Options>()
            {
                new Options(){ OptionName = "TEST: Option 1"},
                new Options(){ OptionName = "TEST: Option 1"},
                new Options(){ OptionName = "TEST: Option 1"},
            };
        }
        public static List<FormsInfo> GetSeedingForms()
        {
            return new List<FormsInfo>()
            {
                new FormsInfo(){ FormName = "TEST: Form 1", DestinationEmail = "TEST: test1@test.com"},
                new FormsInfo(){ FormName = "TEST: Form 2", DestinationEmail = "TEST: test2@test.com"},
                new FormsInfo(){ FormName = "TEST: Form 2", DestinationEmail = "TEST: test3@test.com"},
            };
        }
        public static List<Submissions> GetSeedingSubmissions()
        {
            return new List<Submissions>()
            {
                new Submissions(){ Answer = "TEST: Answer 1" },
                new Submissions(){ Answer = "TEST: Answer 2" },
                new Submissions(){ Answer = "TEST: Answer 3" },
            };
        }
    }
}