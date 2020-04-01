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
        Task <List<QuestionsFormAssignments>> Get(int formId);
        Task<QuestionsFormAssignments> Add(QuestionsFormAssignments question);
        Task<QuestionsFormAssignments> Delete(QuestionsFormAssignments question);
    }
    public class QuestionsFormAssignmentService : IQuestionsFormAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public QuestionsFormAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionsFormAssignments>> Get(int formId)
        {
            return await _context.QuestionsFormAssignments
                .Where(f => f.FormId == formId)
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

        public async Task<QuestionsFormAssignments> Delete(QuestionsFormAssignments question)
        {
            var deletedQuestion = await _context.QuestionsFormAssignments.FindAsync(question.FormId, question.QuestionOrderNum);
            _context.QuestionsFormAssignments.Remove(deletedQuestion);
            await _context.SaveChangesAsync();
            return deletedQuestion;
        }
    }
}