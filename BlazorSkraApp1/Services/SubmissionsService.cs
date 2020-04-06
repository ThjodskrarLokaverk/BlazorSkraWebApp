using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;


namespace BlazorSkraApp1.Services
{
    public interface ISubmissionsService
    {
        Task<Submissions> Add(Submissions submissions);
        Task<Submissions> Get(int submissionId);
        Task<List<Submissions>> Get();
    }
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext _context;

        public SubmissionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates the specified form in the database
        public async Task<Submissions> Add(Submissions submissions)
        {
            _context.Submissions.Add(submissions);
            await _context.SaveChangesAsync();
            return submissions;
        }

        public async Task<Submissions> Get(int submissionId)
        {
            return await _context.Submissions.FindAsync(submissionId);
        }
        public async Task<List<Submissions>> Get()
        {
            return await _context.Submissions
                .Include(i => i.Submission)
                .Include(f => f.Form)
                .ToListAsync();
        }
    }
}