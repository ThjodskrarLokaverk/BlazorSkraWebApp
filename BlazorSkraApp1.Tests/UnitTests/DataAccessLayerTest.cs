using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;

namespace BlazorSkraApp1.Tests.UnitTests
{
    public class DataAccessLayerTest
    {
        

        [Fact]
        public async Task GetCategoriesAsync_CategoriesAreReturned()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                CategoriesService service = new CategoriesService(db);
                // Arrange
                var expectedCategories = ApplicationDbContext.GetSeedingCategories();
                await db.AddRangeAsync(expectedCategories);
                await db.SaveChangesAsync();

                // Act
                var result = await service.Get();

                // Assert
                var actualCategories = Assert.IsAssignableFrom<List<Categories>>(result);
                Assert.Equal(
                    expectedCategories.OrderBy(m => m.CategoryId).Select(m => m.CategoryName),
                    actualCategories.OrderBy(m => m.CategoryId).Select(m => m.CategoryName));
            }
        }

        [Fact]
        public async Task AddCategoryAsync_CategoryIsAdded()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                CategoriesService service = new CategoriesService(db);
                var recId = 5;
                var expectedCategory = new Categories() { CategoryId = recId, CategoryName = "Category 5"};

                // Act
                await service.Add(expectedCategory);

                // Assert
                var actualCategory = await db.Categories.FindAsync(recId);
                Assert.Equal(expectedCategory, actualCategory);
            }
        }

        [Fact]
        public async Task GetCategoryAsync_CategoryIsReturned()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                CategoriesService service = new CategoriesService(db);
                var recId = 5;
                var expectedCategory = new Categories() { CategoryId = recId, CategoryName = "Category 5"};

                // Act
                await service.Add(expectedCategory);
                await service.Get(recId);

                // Assert
                var actualCategory = await db.Categories.FindAsync(recId);
                Assert.Equal(expectedCategory, actualCategory);
            }
        }
        [Fact]
        public async Task UpdateCategoryAsync_CategoryIsUpdated()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                CategoriesService service = new CategoriesService(db);
                var recId = 5;
                var expectedCategory = new Categories() { CategoryId = recId, CategoryName = "Category 5"};

                // Act
                await service.Add(expectedCategory);
                expectedCategory.CategoryName = "Updated name";
                await service.Update(expectedCategory);

                // Assert
                var actualCategory = await db.Categories.FindAsync(recId);
                Assert.Equal(expectedCategory, actualCategory);
            }
        }
        [Fact]
        public async Task DeletedCategory_CategoryIsDeleted()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                CategoriesService service = new CategoriesService(db);
                var recId = 5;
                var expectedCategory = new Categories() { CategoryId = recId, CategoryName = "Category 5"};

                // Act
                await service.Add(expectedCategory);
                var actualCategory = await service.Delete(recId);

                // Assert
                Assert.Equal(expectedCategory, actualCategory);
            }
        }
    }
}