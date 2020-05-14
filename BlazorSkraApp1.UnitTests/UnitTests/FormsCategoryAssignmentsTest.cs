using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;
using BlazorSkraApp1.UnitTests.Helpers;
using System;

namespace BlazorSkraApp1.UnitTests
{
    public class FormsCategoryAssignmentsTest
    {
        private List<FormsCategoryAssignments> seedFormsCategoryAssignments;
        private ApplicationDbContext db;
        private FormsCategoryAssignmentsService service;
        public FormsCategoryAssignmentsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedFormsCategoryAssignments = SeedData.GetSeedingFormsCategoryAssignments();
            service = new FormsCategoryAssignmentsService(db);
        }

        [Fact]
        public async Task GetFormsCategoryAssignmentsAsync_CategoryAssignmentsAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedFormsCategoryAssignments);
            await db.AddRangeAsync(SeedData.GetSeedingCategories());
            await db.AddRangeAsync(SeedData.GetSeedingFormsInfo());
            await db.SaveChangesAsync();

            // Act
            var result = await service.Get();

            // Assert
            var actualFormsCategoryAssignments = Assert.IsAssignableFrom<List<FormsCategoryAssignments>>(result);
            Assert.Equal(
                seedFormsCategoryAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId),
                actualFormsCategoryAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId));
        }

        [Fact]
        public async Task AddCategoryAssignmentAsync_CategoryAssignmentIsAdded()
        {
            // Arrange
            var catId = 5;
            var formId = 1;
            var expectedFormsCategoryAssignment = new FormsCategoryAssignments() { CategoryId = catId, FormId = formId };

            // Act
            await service.Add(expectedFormsCategoryAssignment);

            // Assert
            var actualFormsCategoryAssignment = await db.FormsCategoryAssignments.FindAsync(formId);
            Assert.Equal(expectedFormsCategoryAssignment, actualFormsCategoryAssignment);
        }

        [Fact]
        public async Task GetCategoryAssignmentAsync_CategoryAssignmentIsReturned()
        {
            // Arrange
            var catId = 2;
            var formId = 1;
            var expectedCategoryAssignment = new FormsCategoryAssignments() { CategoryId = catId, FormId = formId };
            await db.AddRangeAsync(expectedCategoryAssignment);
            await db.SaveChangesAsync();

            // Act
            await service.Get(catId);

            // Assert
            var actualCategoryAssignment = await db.FormsCategoryAssignments.FindAsync(formId);
            Assert.Equal(expectedCategoryAssignment, actualCategoryAssignment);
        }

        [Fact]
        public async Task DeleteCategoryAssignmentAsync_CategoryAssignmentIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedFormsCategoryAssignments);
            await db.SaveChangesAsync();
            var recId = 3;
            var deletedFormsCategoryAssignments = new FormsCategoryAssignments() { FormId = 3 };
            var expectedFormsCategoryAssignments = seedFormsCategoryAssignments.Where(c => c.CategoryId != recId).ToList();

            // Act
            await service.Delete(deletedFormsCategoryAssignments);

            // Assert
            var actualFormsCategoryAssignments = await db.FormsCategoryAssignments.ToListAsync();
            Assert.Equal(
                expectedFormsCategoryAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId),
                actualFormsCategoryAssignments.OrderBy(c => c.CategoryId).Select(c => c.CategoryId));
        }
    }
}