using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;


namespace BlazorSkraApp1.Services
{
    public interface ISubmissionsInfoService
    {
        Task<SubmissionsInfo> Add(SubmissionsInfo submissionsInfo);
        Task<SubmissionsInfo> Delete(int submissionId);
        Task<SubmissionsInfo> Update(int submissionId);
        Task<SubmissionsInfo> Get(int submissionId);
        Task<List<SubmissionsInfo>> Get();
    }
    public class SubmissionsInfoService : ISubmissionsInfoService
    {
        private readonly ApplicationDbContext _context;

        public SubmissionsInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates the specified submission in the database
        public async Task<SubmissionsInfo> Add(SubmissionsInfo submissionsInfo)
        {
            _context.SubmissionsInfo.Add(submissionsInfo);
            await _context.SaveChangesAsync();
            return submissionsInfo;
        }

        // Deletes the specified submission from the database
        public async Task<SubmissionsInfo> Delete(int submissionId)
        {
            var submission = await _context.SubmissionsInfo.FindAsync(submissionId);
            _context.SubmissionsInfo.Remove(submission);
            await _context.SaveChangesAsync();
            return submission;
        }

        // Updates the specified submission
        public async Task<SubmissionsInfo> Update(int submissionId)
        {
            var submission = await _context.SubmissionsInfo.FindAsync(submissionId);
            _context.Entry(submission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return submission;
        }

        public async Task<SubmissionsInfo> Get(int submissionId)
        {
            return await _context.SubmissionsInfo.FindAsync(submissionId);
        }
        public async Task<List<SubmissionsInfo>> Get()
        {
            return await _context.SubmissionsInfo.ToListAsync();
        }
    }
}