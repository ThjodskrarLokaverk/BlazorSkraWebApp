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
    public class FormsInfoTest
    {
        private List<FormsInfo> seedFormsInfo;
        private ApplicationDbContext db;
        private FormsInfoService service;

        public FormsInfoTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedFormsInfo = SeedData.GetSeedingFormsInfo();
            service = new FormsInfoService(db);
        }

        [Fact]
        public async Task GetFormsInfoAsync_FormsInfoAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedFormsInfo);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var acutalFormsInfo = Assert.IsAssignableFrom<List<FormsInfo>>(result);
            Assert.Equal(
                seedFormsInfo.OrderBy(m => m.FormId).Select(m => m.FormName),
                acutalFormsInfo.OrderBy(m => m.FormId).Select(m => m.FormName));
        }

        [Fact]
        public async Task GetFormInfoAsync_FormInfoIsReturned()
        {
            // Arrange
            var recId = 1;
            await db.AddRangeAsync(seedFormsInfo);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get(recId);

            // Assert
            var actualFormInfo = await db.FormsInfo.FindAsync(recId);
            Assert.Equal(result, actualFormInfo);
        }

        [Fact]
        public async Task GetDestinationEmailAsync_DestinationEmailIsReturned()
        {
            // Arrange
            var recEmail = "test2@test.com";
            await db.AddRangeAsync(seedFormsInfo);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.GetEmail(recEmail);

            // Assert
            var actualFormInfo = await db.FormsInfo.FirstOrDefaultAsync(f => f.DestinationEmail == recEmail);
            Assert.Equal(result, actualFormInfo);
        }

        [Fact]
        public async Task AddFormInfoAsync_FormInfoIsAdded()
        {

            // Arrange
            var recId = 5;
            var addedFormInfo = new FormsInfo(){ FormId = 5, FormName = "FormInfo 5", DestinationEmail = "test5@test.com"};

            // Act
            await service.Add(addedFormInfo);

            // Assert
            var actualFormInfo = await db.FormsInfo.FindAsync(recId);
            Assert.Equal(actualFormInfo, addedFormInfo);
        }

        [Fact]
        public async Task UpdateFormInfoAsync_FormInfoIsUpdated()
        {

            // Arrange
            var recId = 3;
            var addedFormInfo = new FormsInfo(){ FormId = 3, FormName = "UpdatedForm 3", DestinationEmail = "test3@test.com"};
            await db.AddRangeAsync(addedFormInfo);
            await db.SaveChangesAsync();

            // Act
            await service.Update(addedFormInfo);

            // Assert
            var actualFormInfo = await db.FormsInfo.FindAsync(recId);
            Assert.Equal(actualFormInfo, addedFormInfo);
        }

        [Fact]
        public async Task DeletedFormInfo_FormInfoIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedFormsInfo);
            await db.SaveChangesAsync();
            var recId = 3;
            var expectedFormInfo = seedFormsInfo.Where(f => f.FormId != recId).ToList();

            // Act
            await service.Delete(recId);

            // Assert
            var actualFormInfo = await db.FormsInfo.ToListAsync();
            Assert.Equal(
                expectedFormInfo.OrderBy(f => f.FormId).Select(f => f.FormName),
                actualFormInfo.OrderBy(f => f.FormId).Select(f => f.FormName));
        }
    }
}