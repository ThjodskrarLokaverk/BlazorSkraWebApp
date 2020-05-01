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
    public class SubmissionsTest
    {
        private List<Submissions> seedSubmissions;
        private ApplicationDbContext db;
        private SubmissionsService service;
        public SubmissionsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedSubmissions = SeedData.GetSeedingSubmissions();
            service = new SubmissionsService(db);
        }
        [Fact]
        public async Task GetSubmissionsAsync_SubmissionsAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedSubmissions);
            await db.AddRangeAsync(SeedData.GetSeedingSubmissionsInfo());
            await db.AddRangeAsync(SeedData.GetSeedingFormsInfo());
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualSubmissions = Assert.IsAssignableFrom<List<Submissions>>(result);
            Assert.Equal(
                seedSubmissions.OrderBy(c => c.SubmissionId).Select(c => c.SubmissionId),
                actualSubmissions.OrderBy(c => c.SubmissionId).Select(c => c.SubmissionId));
        }
        
        [Fact]
        public async Task GetSubmissionAsync_SubmissionIsReturned()
        {
            // Arrange
            var subId = 1;
            var expectedSubmission = new List<Submissions>()
            {
                new Submissions(){ SubmissionId = subId, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 1, Answer = "Yes", QuestionsQuestionId = 1},
                new Submissions(){ SubmissionId = subId, QuestionOrderNum = 2, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 2", QuestionsQuestionId = 2},
                new Submissions(){ SubmissionId = subId, QuestionOrderNum = 3, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 3", QuestionsQuestionId = 3}
            };
            await db.AddRangeAsync(seedSubmissions);
            await db.AddRangeAsync(SeedData.GetSeedingSubmissionsInfo());
            await db.AddRangeAsync(SeedData.GetSeedingFormsInfo());
            await db.SaveChangesAsync();

            // Act
            var result = await service.Get(subId);

            // Assert
            var actualSubmission = Assert.IsAssignableFrom<List<Submissions>>(result);
            Assert.Equal(
                expectedSubmission.OrderBy(s => s.SubmissionId).Where(s => s.SubmissionId == subId).Select(s => s.SubmissionId),
                actualSubmission.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId));
        }
        
        [Fact]
        public async Task AddSubmissionAsync_SubmissionIsAdded()
        {
            // Arrange
            var qon = 1;
            var aon = 1;
            var formid = 2;
            var subId = 3;

            var expectedSubmission = new Submissions(){ SubmissionId = subId, QuestionOrderNum = qon, AnswerOrderNum = aon, FormId = formid, Answer = "Maybe", QuestionsQuestionId = 4};

            // Act
            await service.Add(expectedSubmission);

            // Assert
            var actualSubmission = await db.Submissions.FirstOrDefaultAsync(s => s.SubmissionId == subId && s.AnswerOrderNum == aon && s.FormId == formid && s.QuestionOrderNum == qon);
            Assert.Equal(expectedSubmission, actualSubmission);
        }
        [Fact]
        public async Task DeleteSubmissionAsync_SubmissionIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedSubmissions);
            await db.SaveChangesAsync();
            var recId = 1;
            List<Submissions> deletedSubmission = new List<Submissions>() {
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 1, Answer = "Yes", QuestionsQuestionId = 1},
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 2, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 2", QuestionsQuestionId = 2},
                new Submissions(){ SubmissionId = 1, QuestionOrderNum = 3, AnswerOrderNum = 0, FormId = 1, Answer = "Answer 3", QuestionsQuestionId = 3}
            };
            var expectedSubmission = seedSubmissions.Where(s => s.SubmissionId != recId).ToList();

            // Act
            foreach(var d in deletedSubmission)
            {
                await service.Delete(d);
            }

            // Assert
            var actualSubmissions = await db.Submissions.ToListAsync();
            Assert.Equal(
                expectedSubmission.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId),
                actualSubmissions.OrderBy(s => s.SubmissionId).Select(c => c.SubmissionId));
        }
    }
}