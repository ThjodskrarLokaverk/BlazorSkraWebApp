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
        Task<List<CategoriesAssignments>> Get(string id);
        Task<CategoriesAssignments> Add(CategoriesAssignments CategoriesAssignment);
        //Task<CategoriesAssignments> Update(CategoriesAssignments CategoriesAssignment);
        Task<CategoriesAssignments> Delete(CategoriesAssignments categoryAssignment);
    }

    public class CategoriesAssignmentsService : ICategoriesAssignmentsService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesAssignmentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriesAssignments>> Get()
        {
            return await _context.CategoriesAssignments
                .Include(c => c.Categories)
                .Include(f => f.FormsInfo)
                .ToListAsync();
        }

        public async Task<List<CategoriesAssignments>> Get(string Categoryid)
        {
            var CategoryId = Int16.Parse(Categoryid);
            var categories = (from category in _context.CategoriesAssignments
                              where category.CategoryId == CategoryId
                              select category)
            .Include(c => c.Categories)
            .Include(f => f.FormsInfo)
            .ToListAsync();
            return await categories;
        }

        public async Task<CategoriesAssignments> Add(CategoriesAssignments categoryAssignment)
        {
            _context.CategoriesAssignments.Add(categoryAssignment);
            await _context.SaveChangesAsync();
            return categoryAssignment;
        }

        public async Task<CategoriesAssignments> Delete(CategoriesAssignments categoryAssignment)
        {
            var category = await _context.CategoriesAssignments.FindAsync(categoryAssignment.FormId);
            _context.CategoriesAssignments.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}

