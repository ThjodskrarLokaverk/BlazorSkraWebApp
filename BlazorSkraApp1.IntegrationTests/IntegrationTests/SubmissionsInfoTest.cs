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
    public class SubmissionsInfoTest
    {
        private List<SubmissionsInfo> seedSubmissionsInfo;
        private ApplicationDbContext db;
        private SubmissionsInfoService service;
        public SubmissionsInfoTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedSubmissionsInfo = SeedData.GetSeedingSubmissionsInfo();
            service = new SubmissionsInfoService(db);
        }
        [Fact]
        public async Task GetSubmissionsInfoListAsync_SubmissionsInfoListIsReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedSubmissionsInfo);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualSubmissionsInfo = Assert.IsAssignableFrom<List<SubmissionsInfo>>(result);
            Assert.Equal(
                seedSubmissionsInfo.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId),
                actualSubmissionsInfo.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId));
        }

        [Fact]
        public async Task GetSubmissionsInfoAsync_SubmissionsInfoIsReturned()
        {
            // Arrange
            var recId = 4;
            var expectedSubmissionsInfo = new SubmissionsInfo(){ SubmissionId = recId, UserId = "test4@test.com"};
            await db.AddRangeAsync(expectedSubmissionsInfo);
            await db.SaveChangesAsync();

            // Act
            await service.Get(recId);

            // Assert
            var actualSubmissionsInfo = await db.SubmissionsInfo.FindAsync(recId);
            Assert.Equal(expectedSubmissionsInfo, actualSubmissionsInfo);
        }
        [Fact]
        public async Task AddSubmissionsInfoAsync_SubmissionsInfoIsAdded()
        {
            // Arrange
            var recId = 7;
            var expectedSubmissionsInfo = new SubmissionsInfo(){ SubmissionId = recId, UserId = "test7@test.com"};

            // Act
            await service.Add(expectedSubmissionsInfo);

            // Assert
            var actualSubmissionsInfo = await db.SubmissionsInfo.FindAsync(recId);
            Assert.Equal(expectedSubmissionsInfo, actualSubmissionsInfo);
        }
        [Fact]
        public async Task DeleteSubmissionsInfoAsync_SubmissionsInfoIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedSubmissionsInfo);
            await db.SaveChangesAsync();
            var recId = 1;
            var expectedSubmissionsInfo = seedSubmissionsInfo.Where(s => s.SubmissionId != recId).ToList();

            // Act
            await service.Delete(recId);

            // Assert
            var actualSubmissionsInfo = await db.SubmissionsInfo.ToListAsync();
            Assert.Equal(
                expectedSubmissionsInfo.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId),
                actualSubmissionsInfo.OrderBy(s => s.SubmissionId).Select(s => s.SubmissionId));
        }
    }
}