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
            var actualSubmission = Assert.IsAssignableFrom<List<Submissions>>(result);
            Assert.Equal(
                seedSubmissions.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId),
                actualSubmission.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId));
        }
        [Fact]
        public async Task GetSubmissionAsync_SubmissionIsReturned()
        {
            // Arrange
            var subId = 1;
            var expectedSubmission = new List<Submissions>() {
                new Submissions()
                {
                    SubmissionId = subId, QuestionOrderNum = 1, AnswerOrderNum = 1, FormId = 5, Answer = "Yes", QuestionsQuestionId = 1,
                    Submission = new SubmissionsInfo{SubmissionId = subId, UserId = "test1@test.com"},
                    Form = new FormsInfo{FormId = 5, FormName = "Form 5", DestinationEmail = "dest@test.com"}
                },
                new Submissions()
                {
                    SubmissionId = subId, QuestionOrderNum = 2, AnswerOrderNum = 2, FormId = 5, Answer = "No", QuestionsQuestionId = 2,
                    Submission = new SubmissionsInfo{SubmissionId = subId, UserId = "test1@test.com"},
                    Form = new FormsInfo{FormId = 5, FormName = "Form 5", DestinationEmail = "dest@test.com"}
                }
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
                seedSubmissions.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId),
                actualSubmission.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId));
        }
        [Fact]
        public async Task AddSubmissionAsync_SubmissionIsAdded()
        {
            // Arrange
            var qon = 1;
            var aon = 1;
            var formid = 1;
            var subId = 1;

            var expectedSubmission = new Submissions(){ SubmissionId = subId, QuestionOrderNum = qon, AnswerOrderNum = aon, FormId = formid, Answer = "Maybe", QuestionsQuestionId = 1};

            // Act
            await service.Add(expectedSubmission);

            // Assert
            var actualSubmission = await db.Submissions.FindAsync(subId, qon, aon, formid);
            Assert.Equal(expectedSubmission, actualSubmission);
        }
    }
}