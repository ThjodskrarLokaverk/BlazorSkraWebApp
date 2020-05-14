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
    public class QuestionsFormAssignmentTest
    {
        private List<QuestionsFormAssignments> seedAssignments;
        private ApplicationDbContext db;
        private QuestionsFormAssignmentService service;

        public QuestionsFormAssignmentTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedAssignments = SeedData.GetSeedingQuestionsFormAssignment();
            service = new QuestionsFormAssignmentService(db);
        }

        /*[Fact]
        public async Task GetQuestionsFormAssignmentAsync_QuestionsFormAssignmentIsReturned()
        {
            // Arrange
            var formId = 1;
            List<QuestionsFormAssignments> expectedAssignment = new List<QuestionsFormAssignments>()
            {
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 1, QuestionId = 1, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 2, QuestionId = 2, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 3, QuestionId = 3, QuestionTypeOrderNum = 1},
            };
            await db.AddRangeAsync(seedAssignments);
            await db.AddRangeAsync(SeedData.GetSeedingQuestions());
            await db.AddRangeAsync(SeedData.GetSeedingFormsInfo());
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get(formId);

            // Assert
            var actualAssignments = Assert.IsAssignableFrom<List<QuestionsFormAssignments>>(result);
            Assert.Equal(
                expectedAssignment.OrderBy(o => o.QuestionOrderNum).Where(o => o.FormId == formId).Select(o => o.QuestionId),
                actualAssignments.OrderBy(o => o.QuestionOrderNum).Select(o => o.QuestionId));
        }*/

        [Fact]
        public async Task AddQuestionsFormAssignmentAsync_QuestionsFormAssignmentAssignmentIsAdded()
        {
            // Arrange
            int formId = 2;
            int qon = 4;
            int questionId = 7;
            var expectedAssignment = new QuestionsFormAssignments() { FormId = 2, QuestionOrderNum = 4, QuestionId = 7, QuestionTypeOrderNum = 0 };

            // Act
            await service.Add(expectedAssignment);

            // Assert
            var actualAssignment = await db.QuestionsFormAssignments.FirstOrDefaultAsync(o => o.FormId == formId && o.QuestionOrderNum == qon && o.QuestionId == questionId);
            Assert.Equal(expectedAssignment, actualAssignment);
        }

        [Fact]
        public async Task DeleteQuestionsFormAssignmentAsync_QuestionsFormAssignmentIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedAssignments);
            await db.SaveChangesAsync();
            int questionId = 2;

            var deletedQuestionsFormAssignment = new QuestionsFormAssignments() { FormId = 1, QuestionOrderNum = 2, QuestionId = questionId, QuestionTypeOrderNum = 0 };

            var expectedQuestionsFormAssignment = seedAssignments.Where(a => a.QuestionId != questionId);

            // Act
            await service.Delete(deletedQuestionsFormAssignment);

            // Assert
            var actualQuestionsFormAssignment = await db.QuestionsFormAssignments.ToListAsync();
            Assert.Equal(
                expectedQuestionsFormAssignment.OrderBy(o => o.QuestionId).Select(o => o.QuestionId),
                actualQuestionsFormAssignment.OrderBy(o => o.QuestionId).Select(o => o.QuestionId));
        }

        [Fact]
        public async Task DeleteAllQuestionsFormAssignmentsAsync_QuestionsFormAssignmentAsyncsAreDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedAssignments);
            await db.SaveChangesAsync();
            int formId = 2;

            List<QuestionsFormAssignments> deletedQuestionsFormAssignments = new List<QuestionsFormAssignments>()
            {
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 1, QuestionId = 4, QuestionTypeOrderNum = 0},
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 2, QuestionId = 5, QuestionTypeOrderNum = 1},
                new QuestionsFormAssignments(){ FormId = formId, QuestionOrderNum = 3, QuestionId = 6, QuestionTypeOrderNum = 0}
            };

            var expectedQuestionsFormAssignments = seedAssignments.Where(q => q.FormId != formId);

            // Act
            await service.DeleteAll(formId);

            // Assert
            var actualQuestionsFormAssignments = await db.QuestionsFormAssignments.ToListAsync();
            Assert.Equal(
                expectedQuestionsFormAssignments.OrderBy(o => o.FormId).Select(o => o.FormId),
                expectedQuestionsFormAssignments.OrderBy(o => o.FormId).Select(o => o.FormId));
        }
    }
}