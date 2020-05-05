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
    public class CategoriesTest
    {
        private List<Categories> seedCategories;
        private ApplicationDbContext db;
        private CategoriesService service;
        public CategoriesTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedCategories = SeedData.GetSeedingCategories();
            service = new CategoriesService(db);
        }

        [Fact]
        public async Task GetCategoriesAsync_CategoriesAreReturned()
        {
            // Arrange
            await db.AddRangeAsync(seedCategories);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get();

            // Assert
            var actualCategories = Assert.IsAssignableFrom<List<Categories>>(result);
            Assert.Equal(
                seedCategories.OrderBy(c => c.CategoryId).Select(c => c.CategoryName),
                actualCategories.OrderBy(c => c.CategoryId).Select(c => c.CategoryName));
        }

        [Fact]
        public async Task AddCategoryAsync_CategoryIsAdded()
        {
            // Arrange
            var recId = 5;
            var expectedCategory = new Categories() { CategoryId = recId, CategoryName = "Category 5"};

            // Act
            await service.Add(expectedCategory);

            // Assert
            var actualCategory = await db.Categories.FindAsync(recId);
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public async Task GetCategoryAsync_CategoryIsReturned()
        {
            // Arrange
            var recId = 1;
            var expectedCategory = new Categories(){ CategoryId = recId, CategoryName = "Category 1"};
            await db.AddRangeAsync(expectedCategory);
            await db.SaveChangesAsync();

            // Act
            await service.Get(recId);

            // Assert
            var actualCategory = await db.Categories.FindAsync(recId);
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public async Task UpdateCategoryAsync_CategoryIsUpdated()
        {
            // Arrange
            var recId = 2;
            var expectedCategory = new Categories(){ CategoryId = recId, CategoryName = "Category 2"};
            await db.AddRangeAsync(expectedCategory);
            await db.SaveChangesAsync();

            // Act
            expectedCategory.CategoryName = "Updated name";
            await service.Update(expectedCategory);

            // Assert
            var actualCategory = await db.Categories.FindAsync(recId);
            Assert.Equal(expectedCategory, actualCategory);
        }
        [Fact]
        public async Task DeleteCategoryAsync_CategoryIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedCategories);
            await db.SaveChangesAsync();
            var recId = 3;
            var expectedCategories = seedCategories.Where(c => c.CategoryId != recId).ToList();

            // Act
            await service.Delete(recId);

            // Assert
            var actualCategories = await db.Categories.ToListAsync();
            Assert.Equal(
                expectedCategories.OrderBy(c => c.CategoryId).Select(c => c.CategoryName),
                actualCategories.OrderBy(c => c.CategoryId).Select(c => c.CategoryName));
        }
    }
}