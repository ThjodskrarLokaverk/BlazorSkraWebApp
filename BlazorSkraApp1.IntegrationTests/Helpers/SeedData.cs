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
        public static List<Questions> GetSeedingQuestions()
        {
            return new List<Questions>()
            {
                new Questions(){ QuestionId = 1, QuestionName = "Question 1", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 4, QuestionTypeName = "Type 4"}},
                new Questions(){ QuestionId = 2, QuestionName = "Question 2", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 5, QuestionTypeName = "Type 5"}},
                new Questions(){ QuestionId = 3, QuestionName = "Question 3", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 6, QuestionTypeName = "Type 6"}}
            };
        }
        public static List<FormsInfo> GetSeedingFormsInfo()
        {
            return new List<FormsInfo>()
            {
                new FormsInfo(){ FormId = 1, FormName = "Form 1", DestinationEmail = "test1@test.com"},
                new FormsInfo(){ FormId = 2, FormName = "Form 2", DestinationEmail = "test2@test.com"},
                new FormsInfo(){ FormId = 3, FormName = "Form 3", DestinationEmail = "test3@test.com"}
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
        public static List<OptionsQuestionAssignmnents> GetSeedingOptionsQuestionAssignments()
        {
            return new List<OptionsQuestionAssignmnents>()
            {
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 1, FormId = 1, QuestionOrderNum = 1, OptionId = 1},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 2, FormId = 1, QuestionOrderNum = 1, OptionId = 2},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 3, FormId = 1, QuestionOrderNum = 1, OptionId = 3},
                new OptionsQuestionAssignmnents()
                { 
                    OptionOrderNum = 3, 
                    FormId = 3, 
                    QuestionOrderNum = 1, 
                    OptionId = 4, 
                    Options = new Options(){OptionId = 4, OptionName = "Jaja"},
                    QuestionsFormAssignments = new QuestionsFormAssignments(){FormId = 3, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0}
                },
                new OptionsQuestionAssignmnents()
                { 
                    OptionOrderNum = 3, 
                    FormId = 4, 
                    QuestionOrderNum = 1, 
                    OptionId = 4, 
                    Options = new Options(){OptionId = 4, OptionName = "Jaja"},
                    QuestionsFormAssignments = new QuestionsFormAssignments(){FormId = 4, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0}
                }

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
        public static List<QuestionsFormAssignments> GetSeedingQuestionsFormAssignment()
        {
            return new List<QuestionsFormAssignments>()
            {
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 2, QuestionId = 2, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = 1, QuestionOrderNum = 3, QuestionId = 3, QuestionTypeOrderNum = 0}
            };
        }
        public static List<QuestionTypes> GetSeedingQuestionTypes()
        {
            return new List<QuestionTypes>()
            {
                new QuestionTypes(){ QuestionTypeId = 4, QuestionTypeName = "Type 4"},
                new QuestionTypes(){ QuestionTypeId = 5, QuestionTypeName = "Type 5"},
                new QuestionTypes(){ QuestionTypeId = 6, QuestionTypeName = "Type 6"}
            };
        }
        public static List<SubmissionsInfo> GetSeedingSubmissionsInfo()
        {
            return new List<SubmissionsInfo>()
            {
                new SubmissionsInfo(){ SubmissionId = 4, UserId = "test1@test.com"},
                new SubmissionsInfo(){ SubmissionId = 5, UserId = "test2@test.com"},
                new SubmissionsInfo(){ SubmissionId = 6, UserId = "test3@test.com"}
            };
        }
        public static List<Submissions> GetSeedingSubmissions()
        {
            return new List<Submissions>()
            {
                new Submissions()
                {
                    SubmissionId = 1, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 5, Answer = "Yes", QuestionsQuestionId = 1,
                    Submission = new SubmissionsInfo{SubmissionId = 1, UserId = "test1@test.com"},
                    Form = new FormsInfo{FormId = 5, FormName = "Form 5", DestinationEmail = "dest@test.com"}
                },
                new Submissions()
                {
                    SubmissionId = 1, QuestionOrderNum = 2, AnswerOrderNum = 2, FormId = 5, Answer = "No", QuestionsQuestionId = 2,
                    Submission = new SubmissionsInfo{SubmissionId = 1, UserId = "test1@test.com"},
                    Form = new FormsInfo{FormId = 5, FormName = "Form 5", DestinationEmail = "dest@test.com"}
                }
                //new Submissions(){ SubmissionId = 2, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 5, Answer = "Yes", QuestionsQuestionId = 1},
                //new Submissions(){ SubmissionId = 2, QuestionOrderNum = 1, AnswerOrderNum = 2, FormId = 5, Answer = "No", QuestionsQuestionId = 1},
                //new Submissions(){ SubmissionId = 2, QuestionOrderNum = 1, AnswerOrderNum = 3, FormId = 5, Answer = "Maybe", QuestionsQuestionId = 1}
            };
        }
    }
}