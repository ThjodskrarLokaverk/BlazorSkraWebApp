using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface ICategoriesAssignmentsService
    {
        Task<List<CategoriesAssignments>> Get();
        Task<List<CategoriesAssignments>> Get(int CategoryId);
        Task<CategoriesAssignments> Add(CategoriesAssignments categoryAssignment);
        Task<CategoriesAssignments> Delete(CategoriesAssignments categoryAssignment);
        Task<CategoriesAssignments> Update(CategoriesAssignments categoryAssignment);
    }

    public class CategoriesAssignmentsService : ICategoriesAssignmentsService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesAssignmentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Returns a list of category assignments
        public async Task<List<CategoriesAssignments>> Get()
        {
            return await _context.CategoriesAssignments
                .Include(c => c.Categories)
                .Include(f => f.FormsInfo)
                .ToListAsync();
        }

        // Returns a list of all category assignments for the specified category
        public async Task<List<CategoriesAssignments>> Get(int CategoryId)
        {
            var categories = (from category in _context.CategoriesAssignments
                              where category.CategoryId == CategoryId
                              select category)
            .Include(c => c.Categories)
            .Include(f => f.FormsInfo)
            .ToListAsync();
            return await categories;
        }

        // Creates the specified category assignment in the database
        public async Task<CategoriesAssignments> Add(CategoriesAssignments categoryAssignment)
        {
            _context.CategoriesAssignments.Add(categoryAssignment);
            await _context.SaveChangesAsync();
            return categoryAssignment;
        }

        // Deletes the specified category assignment from the database
        public async Task<CategoriesAssignments> Delete(CategoriesAssignments categoryAssignment)
        {
            var category = await _context.CategoriesAssignments.FindAsync(categoryAssignment.CategoryId, categoryAssignment.FormId);
            _context.CategoriesAssignments.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoriesAssignments> Update(CategoriesAssignments editedCategoryAssignment)
        {
            var categoryAssignment = await _context.CategoriesAssignments.FindAsync(editedCategoryAssignment.FormId);
            categoryAssignment.CategoryId = editedCategoryAssignment.CategoryId;
            categoryAssignment.FormId = editedCategoryAssignment.FormId;
            _context.Entry(categoryAssignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoryAssignment;
        }
    }
}

