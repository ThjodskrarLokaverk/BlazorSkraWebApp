using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IFormsCategoryAssignmentsService
    {
        Task<List<FormsCategoryAssignments>> Get();
        Task<List<FormsCategoryAssignments>> Get(int categoryId);
        Task<FormsCategoryAssignments> Add(FormsCategoryAssignments categoryAssignment);
        Task<FormsCategoryAssignments> Delete(FormsCategoryAssignments categoryAssignment);
        Task<FormsCategoryAssignments> Update(FormsCategoryAssignments categoryAssignment);
    }

    public class FormsCategoryAssignmentsService : IFormsCategoryAssignmentsService
    {
        private readonly ApplicationDbContext _context;

        public FormsCategoryAssignmentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Returns a list of category assignments
        public async Task<List<FormsCategoryAssignments>> Get()
        {
            return await _context.FormsCategoryAssignments
                .Include(c => c.Categories)
                .Include(f => f.FormsInfo)
                .ToListAsync();
        }

        // Returns a list of all category assignments for the specified category
        public async Task<List<FormsCategoryAssignments>> Get(int categoryId)
        {
            var categories = (from category in _context.FormsCategoryAssignments
                              where category.CategoryId == categoryId
                              select category)
            .Include(c => c.Categories)
            .Include(f => f.FormsInfo)
            .ToListAsync();
            return await categories;
        }

        // Creates the specified category assignment in the database
        public async Task<FormsCategoryAssignments> Add(FormsCategoryAssignments categoryAssignment)
        {
            _context.FormsCategoryAssignments.Add(categoryAssignment);
            await _context.SaveChangesAsync();
            return categoryAssignment;
        }

        // Deletes the specified category assignment from the database
        public async Task<FormsCategoryAssignments> Delete(FormsCategoryAssignments categoryAssignment)
        {
            var category = await _context.FormsCategoryAssignments.FindAsync(categoryAssignment.FormId);
            _context.FormsCategoryAssignments.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<FormsCategoryAssignments> Update(FormsCategoryAssignments editedCategoryAssignment)
        {
            var categoryAssignment = await _context.FormsCategoryAssignments
                .Where(ca => ca.FormId == editedCategoryAssignment.FormId)
                .FirstOrDefaultAsync();
            categoryAssignment.CategoryId = editedCategoryAssignment.CategoryId;
            categoryAssignment.FormId = editedCategoryAssignment.FormId;
            _context.Entry(categoryAssignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoryAssignment;
        }
    }
}

