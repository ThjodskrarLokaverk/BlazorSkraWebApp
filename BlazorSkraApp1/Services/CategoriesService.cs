using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;


namespace BlazorSkraApp1.Services
{
    public interface ICategoriesService
    {
        Task<List<Categories>> Get();
        Task<Categories> Get(int id);
        Task<Categories> Add(Categories category);
        Task<Categories> Update(Categories category);
        Task<Categories> Delete(int id);
    }

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Returns a list of all categories
        public async Task<List<Categories>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        // Returns the specified category
        public async Task<Categories> Get(int CategoryId)
        {
            return await _context.Categories.FindAsync(CategoryId); 
        }

        // Creates the specified category in the database
        public async Task<Categories> Add(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Updates the specified category in the database
        public async Task<Categories> Update(Categories category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        // Deletes the specified category from the database
        public async Task<Categories> Delete(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}