using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;
using BlazorSkraApp1.UnitTests.Helpers;
using System;

namespace BlazorSkraApp1.UnitTests
{
    public class QuestionsTest
    {
        private List<Questions> seedQuestions;
        private ApplicationDbContext db;
        private QuestionsService service;
        public QuestionsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedQuestions = SeedData.GetSeedingQuestions();
            service = new QuestionsService(db);
        }
        [Fact]
        public async Task GetQuestionsAsync_QuestionsAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedQuestions);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualQuestions = Assert.IsAssignableFrom<List<Questions>>(result);
            Assert.Equal(
                seedQuestions.OrderBy(q => q.QuestionId).Select(q => q.QuestionName),
                actualQuestions.OrderBy(q => q.QuestionId).Select(q => q.QuestionName));
        }

        [Fact]
        public async Task GetQuestionAsync_QuestionIsReturned()
        {
            // Arrange
            var recId = 1;
            var expectedQuestion = new Questions(){ QuestionId = recId, QuestionName = "Question 1", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 4, QuestionTypeName = "Type 4"}};
            await db.AddRangeAsync(expectedQuestion);
            await db.SaveChangesAsync();

            // Act
            await service.GetQuestion(recId);

            // Assert
            var actualQuestion = await db.Questions.FindAsync(recId);
            Assert.Equal(expectedQuestion, actualQuestion);
        }

        [Fact]
        public async Task AddQuestionAsync_QuestionIsAdded()
        {
            // Arrange
            var recId = 3;
            var expectedQuestion = new Questions(){ QuestionId = recId, QuestionName = "Question 3", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 6, QuestionTypeName = "Type 6"}};

            // Act
            await service.Add(expectedQuestion);

            // Assert
            var actualQuestion = await db.Questions.FindAsync(recId);
            Assert.Equal(expectedQuestion, actualQuestion);

        }
        [Fact]
        public async Task UpdateQuestionAsync_QuestionIsUpdated()
        {
            // Arrange
            var recId = 2;
            var expectedQuestion = new Questions(){ QuestionId = 2, QuestionName = "Question 2", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 5, QuestionTypeName = "Type 5"}};
            await db.AddRangeAsync(expectedQuestion);
            await db.SaveChangesAsync();

            // Act
            expectedQuestion.QuestionName = "Updated question name";
            await service.Update(expectedQuestion);

            // Assert
            var actualQuestion = await db.Questions.FindAsync(recId);
            Assert.Equal(expectedQuestion, actualQuestion);
        }
        [Fact]
        public async Task DeleteQuestionAsync_QuestionIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedQuestions);
            await db.SaveChangesAsync();
            var recId = 2;
            var deletedQuestion = new Questions(){ QuestionId = recId, QuestionName = "Question 2", QuestionTypes = new QuestionTypes(){ QuestionTypeId = 5, QuestionTypeName = "Type 5"}};
            var expectedQuestions = seedQuestions.Where(q => q.QuestionId != recId).ToList();

            // Act
            await service.Delete(deletedQuestion);

            // Assert
            var actualQuestions = await db.Questions.ToListAsync();
            Assert.Equal(
                expectedQuestions.OrderBy(q => q.QuestionId).Select(q => q.QuestionName),
                actualQuestions.OrderBy(q => q.QuestionId).Select(q => q.QuestionName));
        }
    }
}