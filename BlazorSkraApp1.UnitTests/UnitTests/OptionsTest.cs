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
    public class OptionsTest
    {
        private List<Options> seedOptions;
        private ApplicationDbContext db;
        private OptionsService service;

        public OptionsTest()
        {
            db = new ApplicationDbContext(Utilities.TestDbContextOptions());
            seedOptions = SeedData.GetSeedingOptions();
            service = new OptionsService(db);
        }

        [Fact]
        public async Task GetOptionAsync_OptionIsReturned()
        {
            var recId = 1;
            var expectedOption = new Options(){ OptionId = 1, OptionName = "Option 1"};

            // Arrange
            await db.AddRangeAsync(seedOptions);
            await db.SaveChangesAsync(); 

            // Act
            var result = await service.Get(recId);

            // Assert
            var actualOption = await db.Options.FindAsync(recId);
            Assert.Equal(actualOption, result);
        }

        [Fact]
        public async Task AddOptionAsync_OptionIsAdded()
        {
            // Arrange
            var recId = 5;
            var addedOption = new Options(){ OptionId = 5, OptionName = "Option 5"};

            // Act
            await service.Add(addedOption);

            // Assert
            var actualOption = await db.Options.FindAsync(recId);
            Assert.Equal(actualOption, addedOption);
        }

        [Fact]
        public async Task UpdateOptionAsync_OptionIsUpdated()
        {

            // Arrange
            var recId = 3;
            var addedOption = new Options(){ OptionId = 3, OptionName = "UpdatedOption 3"};
            await db.AddRangeAsync(addedOption);
            await db.SaveChangesAsync();

            // Act
            await service.Update(addedOption);

            // Assert
            var actualOption = await db.Options.FindAsync(recId);
            Assert.Equal(actualOption, addedOption);
        }

        [Fact]
        public async Task DeletedOption_OptionIsDeleted()
        {
            // Arrange
            await db.AddRangeAsync(seedOptions);
            await db.SaveChangesAsync();
            var recId = 3;
            Options deleteOption = new Options(){ OptionId = recId, OptionName = "Option 3" };
            var expectedOption = seedOptions.Where(o => o.OptionId != recId).ToList();

            // Act
            await service.Delete(deleteOption);

            // Assert
            var actualOption = await db.Options.ToListAsync();
            Assert.Equal(
                expectedOption.OrderBy(o => o.OptionId).Select(o => o.OptionName),
                actualOption.OrderBy(o => o.OptionId).Select(o => o.OptionName));
        }
    }
}