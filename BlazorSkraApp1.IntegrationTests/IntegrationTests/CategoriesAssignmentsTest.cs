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
    public class CategoriesAssignmentsTest
    {
        private List<CategoriesAssignments> seedCategoriesAssignments;
        private ApplicationDbContext db;
        private CategoriesAssignmentsService service;
        public CategoriesAssignmentsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedCategoriesAssignments = SeedData.GetSeedingCategoriesAssignments();
            service = new CategoriesAssignmentsService(db);
        }

        [Fact]
        public async Task GetCategoriesAssignmentsAsync_CategoriesAssignmentsAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedCategoriesAssignments);
            await db.AddRangeAsync(SeedData.GetSeedingCategories());
            await db.AddRangeAsync(SeedData.GetSeedingFormsInfo());
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualCategoriesAssignments = Assert.IsAssignableFrom<List<CategoriesAssignments>>(result);
            Assert.Equal(
                seedCategoriesAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId),
                actualCategoriesAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId));
        }
        
        [Fact]
        public async Task AddCategoryAssignmentAsync_CategoryAssignmentIsAdded()
        {
            // Arrange
            var catId = 5;
            var formId = 1;
            var expectedCategoryAssignment = new CategoriesAssignments(){ CategoryId = catId, FormId = formId};

            // Act
            await service.Add(expectedCategoryAssignment);

            // Assert
            var actualCategoryAssignment = await db.CategoriesAssignments.FindAsync(catId, formId);
            Assert.Equal(expectedCategoryAssignment, actualCategoryAssignment);
        }
        
        [Fact]
        public async Task GetCategoryAssignmentAsync_CategoryAssignmentIsReturned()
        {
            // Arrange
            var catId = 2;
            var formId = 1;
            var expectedCategoryAssignment = new CategoriesAssignments(){ CategoryId = catId, FormId = formId};
            await db.AddRangeAsync(expectedCategoryAssignment);
            await db.SaveChangesAsync();

            // Act
            await service.Get(catId);

            // Assert
            var actualCategoryAssignment = await db.CategoriesAssignments.FindAsync(catId, formId);
            Assert.Equal(expectedCategoryAssignment, actualCategoryAssignment);
        }
        
        [Fact]
        public async Task DeleteCategoryAssignmentAsync_CategoryAssignmentIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedCategoriesAssignments);
            await db.SaveChangesAsync();
            var recId = 3;
            var deletedCategoriesAssignments = new CategoriesAssignments(){ CategoryId = recId, FormId = 3};
            var expectedCategoriesAssignments = seedCategoriesAssignments.Where(c => c.CategoryId != recId).ToList();

            // Act
            await service.Delete(deletedCategoriesAssignments);

            // Assert
            var actualCategoriesAssignments = await db.CategoriesAssignments.ToListAsync();
            Assert.Equal(
                expectedCategoriesAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId),
                actualCategoriesAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId));
        }
    }
}