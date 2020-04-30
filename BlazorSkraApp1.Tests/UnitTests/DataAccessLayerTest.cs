using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Tests.UnitTests
{
    public class DataAccessLayerTest
    {
        [Fact]
        public async Task GetCategoriesAsync_CategoriesAreReturned()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedCategories = ApplicationDbContext.GetSeedingCategories();
                await db.AddRangeAsync(expectedCategories);
                await db.SaveChangesAsync();

                // Act
                // ATH EKKI RETT!!!
                var result = await db.Categories.ToListAsync();

                // Assert
                var actualCategories = Assert.IsAssignableFrom<List<Categories>>(result);
                Assert.Equal(
                    expectedCategories.OrderBy(m => m.CategoryId).Select(m => m.CategoryName),
                    actualCategories.OrderBy(m => m.CategoryId).Select(m => m.CategoryName));
            }
        }
    }
}