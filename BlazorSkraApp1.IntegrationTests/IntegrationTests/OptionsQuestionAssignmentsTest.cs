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
        /*
        [Fact]
        public async Task GetOptionAssignmentAsync_OptionAssignmentIsReturned()
        {
            // Arrange
            var recId = 3;
            List<OptionsQuestionAssignmnents> expectedAssignment = new List<OptionsQuestionAssignmnents>()
            {
                new OptionsQuestionAssignmnents()
                { 
                    OptionOrderNum = 3, 
                    FormId = recId, 
                    QuestionOrderNum = 1, 
                    OptionId = 4, 
                    Options = new Options(){OptionId = 4, OptionName = "Jaja"},
                    QuestionsFormAssignments = new QuestionsFormAssignments(){FormId = 3, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0}
                }

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
                expectedAssignment.OrderBy(o => o.QuestionOrderNum).Select(o => o.Options.OptionName),
                actualAssignments.OrderBy(o => o.QuestionOrderNum).Select(o => o.Options.OptionName));
        }
        */
    }

}

/*
        Task<List<OptionsQuestionAssignmnents>> Get();
        Task<List<OptionsQuestionAssignmnents>> Get(int formId);
        Task<OptionsQuestionAssignmnents> Add(OptionsQuestionAssignmnents option);
        Task<OptionsQuestionAssignmnents> Delete(OptionsQuestionAssignmnents option);
*/