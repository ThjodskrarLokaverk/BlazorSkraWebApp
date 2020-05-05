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
    public class OptionsQuestionAssignmentsTest
    {
        private List<OptionsQuestionAssignmnents> seedAssignments;
        private ApplicationDbContext db;
        private OptionsQuestionAssignmnentsService service;

        public OptionsQuestionAssignmentsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedAssignments = SeedData.GetSeedingOptionsQuestionAssignments();
            service = new OptionsQuestionAssignmnentsService(db);
        }
        
        [Fact]
        public async Task GetOptionAssignmentsAsync_OptionAssignmentsAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedAssignments);
            await db.AddRangeAsync(SeedData.GetSeedingOptions());
            await db.AddRangeAsync(SeedData.GetSeedingQuestionsFormAssignment());
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<OptionsQuestionAssignmnents>>(result);
            Assert.Equal(
                seedAssignments.OrderBy(o => o.QuestionOrderNum),
                actualAssignments.OrderBy(o => o.QuestionOrderNum));
        }
        
        [Fact]
        public async Task GetOptionAssignmentAsync_OptionAssignmentIsReturned()
        {
            // Arrange
            var recId = 3;
            List<OptionsQuestionAssignmnents> expectedAssignment = new List<OptionsQuestionAssignmnents>()
            {
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 1, FormId = 1, QuestionOrderNum = 1, OptionId = 1},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 2, FormId = 1, QuestionOrderNum = 1, OptionId = 2},
                new OptionsQuestionAssignmnents(){ OptionOrderNum = 3, FormId = 1, QuestionOrderNum = 1, OptionId = 3}
            };
            await db.AddRangeAsync(seedAssignments);
            await db.AddRangeAsync(SeedData.GetSeedingOptions());
            await db.AddRangeAsync(SeedData.GetSeedingQuestionsFormAssignment());
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get(recId);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<OptionsQuestionAssignmnents>>(result);
            Assert.Equal(
                expectedAssignment.OrderBy(o => o.QuestionOrderNum).Where(o => o.FormId == recId).Select(o => o.Options.OptionId),
                actualAssignments.OrderBy(o => o.QuestionOrderNum).Select(o => o.Options.OptionId));
        }
        [Fact]
        public async Task AddOptionAssignmentAsync_OptionAssignmentIsAdded()
        {
            // Arrange
            var oon = 1;
            var formid = 2;
            var qon = 1;

            var expectedAssignment = new OptionsQuestionAssignmnents(){ OptionOrderNum = oon, FormId = formid, QuestionOrderNum = qon, OptionId = 4};

            // Act
            await service.Add(expectedAssignment);

            // Assert
            var actualAssignment = await db.OptionsQuestionAssignmnents.FirstOrDefaultAsync(o => o.OptionOrderNum == oon && o.FormId == formid && o.QuestionOrderNum == qon);
            Assert.Equal(expectedAssignment, actualAssignment);
        }
        /*[Fact]
        public async Task DeleteOptionsQuestionAssignmnentAsync_OptionsQuestionAssignmnentIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedAssignments);
            await db.SaveChangesAsync();
            var oon = 3;
            var formid = 1;
            var qon = 1;
            var deletedOptionsQuestionAssignmnent = new OptionsQuestionAssignmnents(){ OptionOrderNum = oon, FormId = formid, QuestionOrderNum = qon, OptionId = 3};
            var expectedOptionsQuestionAssignmnent = seedAssignments.Where(o => o.OptionOrderNum != oon && o.FormId == formid && o.QuestionOrderNum == qon).ToList();

            // Act
            await service.Delete(deletedOptionsQuestionAssignmnent);
        
            // Assert
            var actualOptionsQuestionAssignmnent = await db.OptionsQuestionAssignmnents.ToListAsync();
            Assert.Equal(
                expectedOptionsQuestionAssignmnent.OrderBy(o => o.QuestionOrderNum).Select(o => o.QuestionOrderNum),
            actualOptionsQuestionAssignmnent.OrderBy(o => o.QuestionOrderNum).Select(o => o.QuestionOrderNum));
        }*/
    }
}