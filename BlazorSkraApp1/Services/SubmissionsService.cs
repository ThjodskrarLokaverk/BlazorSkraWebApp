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
        Task<Submissions> Delete(Submissions submissions);
        Task<List<Submissions>> Get(int submissionId);
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

        public async Task<Submissions> Delete(Submissions submission)
        {
            var deletedSubmission = await _context.Submissions.FindAsync(submission.SubmissionId);
            _context.Submissions.Remove(deletedSubmission);
            await _context.SaveChangesAsync();
            return deletedSubmission;
        }

        public async Task<List<Submissions>> Get(int submissionId)
        {
            return await _context.Submissions
                .Where(s => s.SubmissionId == submissionId)
                .Include(f => f.Form)
                .ToListAsync();
        }
        public async Task<List<Submissions>> Get()
        {
            return await _context.Submissions
                .Include(s => s.Submission)
                .Include(f => f.Form)
                .ToListAsync();
        }
    }
}