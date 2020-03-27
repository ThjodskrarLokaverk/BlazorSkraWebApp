using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IQuestionsFormAssignmentService
    {
        Task <List<QuestionsFormAssignments>> Get(int id);
        Task <QuestionsFormAssignments> Add(QuestionsFormAssignments question);
    }
    public class QuestionsFormAssignmentService : IQuestionsFormAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public QuestionsFormAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionsFormAssignments>> Get(int FormId)
        {
            return await _context.QuestionsFormAssignments
                .Where(f => f.FormId == FormId)
                .Include(q => q.Questions)
                    .ThenInclude(qt => qt.QuestionTypes)
                .ToListAsync();
        }

        public async Task<QuestionsFormAssignments> Add(QuestionsFormAssignments question)
        {
            _context.QuestionsFormAssignments.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }
    }
}