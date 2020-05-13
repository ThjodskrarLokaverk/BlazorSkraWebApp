using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using System;

namespace BlazorSkraApp1.IntegrationTests.Helpers
{
    public class SeedData
    {
        public static List<Categories> GetSeedingCategories()
        {
            return new List<Categories>()
            {
                new Categories(){ CategoryId = 1, CategoryName = "Category 1"},
                new Categories(){ CategoryId = 2, CategoryName = "Category 2"},
                new Categories(){ CategoryId = 3, CategoryName = "Category 3"}
            };
        }
        public static List<FormsInfo> GetSeedingFormsInfo()
        {
            return new List<FormsInfo>()
            {
                new FormsInfo(){ FormId = 1, FormName = "Form 1", DestinationEmail = "test1@test.com", IsAnonymous = false},
                new FormsInfo(){ FormId = 2, FormName = "Form 2", DestinationEmail = "test2@test.com", IsAnonymous = true},
                new FormsInfo(){ FormId = 3, FormName = "Form 3", DestinationEmail = "test3@test.com", IsAnonymous = false}
            };
        }
        public static List<CategoriesAssignments> GetSeedingCategoriesAssignments()
        {
            return new List<CategoriesAssignments>()
            {
                new CategoriesAssignments(){ CategoryId = 1, FormId = 1},
                new CategoriesAssignments(){ CategoryId = 2, FormId = 2},
                new CategoriesAssignments(){ CategoryId = 3, FormId = 3}
            };
        }
        public static List<QuestionTypes> GetSeedingQuestionTypes()
        {
            return new List<QuestionTypes>()
            {
                new QuestionTypes(){ QuestionTypeId = 1, QuestionTypeName = "Type 1"},
                new QuestionTypes(){ QuestionTypeId = 2, QuestionTypeName = "Type 2"},
                new QuestionTypes(){ QuestionTypeId = 3, QuestionTypeName = "Type 3"}
            };
        }
        public static List<Questions> GetSeedingQuestions()
        {
            return new List<Questions>()
            {
                new Questions(){ QuestionId = 1, QuestionName = "Question 1"},
                new Questions(){ QuestionId = 2, QuestionName = "Question 2"},
                new Questions(){ QuestionId = 3, QuestionName = "Question 3"},
                new Questions(){ QuestionId = 4, QuestionName = "Question 4"},
                new Questions(){ QuestionId = 5, QuestionName = "Question 5"},
                new Questions(){ QuestionId = 6, QuestionName = "Question 6"}
            };
        }
        public static List<Options> GetSeedingOptions()
        {
            return new List<Options>()
            {
                new Options(){ OptionId = 1, OptionName = "Yes"},
                new Options(){ OptionId = 2, OptionName = "No"},
                new Options(){ OptionId = 3, OptionName = "Maybe"}
            };
        }
        public static List<OptionsQuestionAssignmnents> GetSeedingOptionsQuestionAssignments()
        {
            return new List<OptionsQuestionAssignmnents>()
            {
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 1, FormId = 1, QuestionOrderNum = 1, OptionId = 1},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 2, FormId = 1, QuestionOrderNum = 1, OptionId = 2},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 3, FormId = 1, QuestionOrderNum = 1, OptionId = 3}
            };
        }
        public static List<QuestionsFormAssignments> GetSeedingQuestionsFormAssignment()
        {
            return new List<QuestionsFormAssignments>()
            {
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 2, QuestionId = 2, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 3, QuestionId = 3, QuestionTypeOrderNum = 1},
                new QuestionsFormAssignments(){ FormId = 2, QuestionOrderNum = 1, QuestionId = 4, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = 2, QuestionOrderNum = 2, QuestionId = 5, QuestionTypeOrderNum = 1},
                new QuestionsFormAssignments(){ FormId = 2, QuestionOrderNum = 3, QuestionId = 6, QuestionTypeOrderNum = 0}
            };
        }
        public static List<SubmissionsInfo> GetSeedingSubmissionsInfo()
        {
            return new List<SubmissionsInfo>()
            {
                new SubmissionsInfo(){ SubmissionId = 1, UserId = "test01@test.com"},
                new SubmissionsInfo(){ SubmissionId = 2, UserId = "test02@test.com"}
            };
        }
        public static List<Submissions> GetSeedingSubmissions()
        {
            return new List<Submissions>()
            {
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 1, Answer = "Yes", QuestionsQuestionId = 1},
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 2, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 2", QuestionsQuestionId = 2},
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 3, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 3", QuestionsQuestionId = 3},
                new Submissions(){ SubmissionId = 2, QuestionOrderNum = 1, AnswerOrderNum = 0, FormId = 2, Answer = "Answer 1", QuestionsQuestionId = 4},
                new Submissions(){ SubmissionId = 2, QuestionOrderNum = 2, AnswerOrderNum = 0, FormId = 2, Answer = "Answer 2", QuestionsQuestionId = 5},
                new Submissions(){ SubmissionId = 2, QuestionOrderNum = 3, AnswerOrderNum = 0, FormId = 2, Answer = "Answer 3", QuestionsQuestionId = 6}
            };
        }
    }
}