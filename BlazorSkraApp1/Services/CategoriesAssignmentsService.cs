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
        Task<CategoriesAssignments> Get(int id);
        //Task<CategoriesAssignments> Add(CategoriesAssignments CategoriesAssignment);
        //Task<CategoriesAssignments> Update(CategoriesAssignments CategoriesAssignment);
        //Task<CategoriesAssignments> Delete(int id);
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

        public async Task<CategoriesAssignments> Get(int CategoryId)
        {
            var categoriesAssignments = await _context.CategoriesAssignments.FindAsync(CategoryId);
            return categoriesAssignments;
        }
    }
}
