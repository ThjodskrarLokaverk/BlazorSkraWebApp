using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;
using BlazorSkraApp1.IntegrationTests.Helpers;
using System;

namespace BlazorSkraApp1.IntegrationTests
{
    public class QuestionTypeTest
    {
        private List<QuestionTypes> seedQuestionTypes;
        private ApplicationDbContext db;
        private QuestionTypesService service;
        public QuestionTypeTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedQuestionTypes = SeedData.GetSeedingQuestionTypes();
            service = new QuestionTypesService(db);
        }
        [Fact]
        public async Task GetQuestionTypesAsync_QuestionTypesAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedQuestionTypes);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualQuestionTypes = Assert.IsAssignableFrom<List<QuestionTypes>>(result);
            Assert.Equal(
                seedQuestionTypes.OrderBy(q => q.QuestionTypeId).Select(q => q.QuestionTypeName),
                actualQuestionTypes.OrderBy(q => q.QuestionTypeId).Select(q => q.QuestionTypeName));
        }

        [Fact]
        public async Task GetQuestionTypeAsync_QuestionTypeIsReturned()
        {
            // Arrange
            var recId = 5;
            var expectedQuestionType = new QuestionTypes(){ QuestionTypeId = recId, QuestionTypeName = "Type 5"};
            await db.AddRangeAsync(expectedQuestionType);
            await db.SaveChangesAsync();

            // Act
            await service.Get(recId);

            // Assert
            var actualQuestionType = await db.QuestionTypes.FindAsync(recId);
            Assert.Equal(expectedQuestionType, actualQuestionType);
        }
    }
}