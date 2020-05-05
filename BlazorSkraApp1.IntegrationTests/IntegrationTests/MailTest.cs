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
    public class MailTest
    {
        private List<Categories> seedCategories;
        private List<FormsInfo> seedFormsInfo;
        private ApplicationDbContext db;
        private MailService service;

        public MailTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedCategories = SeedData.GetSeedingCategories();
            seedFormsInfo = SeedData.GetSeedingFormsInfo();
            service = new MailService(db);
        }

        [Fact]
        public async Task GetCategoryAsync_CategoryIsReturned()
        {
            var recId = 1;
            var expectedCategory = new Categories(){ CategoryId = recId, CategoryName = "Category 1"};

            // Arrange
            await db.AddRangeAsync(seedCategories);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.GetCategory(recId);

            // Assert
            var actualCategory = await db.Categories.FindAsync(recId);
            Assert.Equal(actualCategory, result);
        }

        [Fact]
        public async Task GetFormInfoAsync_FormInfoIsReturned()
        {
            var recId = 2;
            var expectedFormInfo = new FormsInfo(){ FormId = recId, FormName = "Form 2", DestinationEmail = "test2@test.com"};

            // Arrange
            await db.AddRangeAsync(seedFormsInfo);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.GetForm(recId);

            // Assert
            var actualFormInfo = await db.FormsInfo.FindAsync(recId);
            Assert.Equal(actualFormInfo, result);
        }
    }
}