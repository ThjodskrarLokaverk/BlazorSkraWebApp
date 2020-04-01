using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IQuestionsService
    {
        Task<Questions> Add(Questions question);
        Task<Questions> Update(Questions question);
        Task<Questions> Delete(Questions question);

    }
    public class QuestionsService : IQuestionsService
    {
        private readonly ApplicationDbContext _context;

        public QuestionsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Questions> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            return question;
        }
        public async Task<Questions> Add(Questions question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }
        public async Task<Questions> Update(Questions question)
        {
            var updatedQuestion = await _context.Questions.FindAsync(question.QuestionId, question.QuestionTypes.QuestionTypeId);
            _context.Entry(updatedQuestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedQuestion;

        }
        public async Task<Questions> Delete(Questions question)
        {
            var deletedQuestion = await _context.Questions.FindAsync(question.QuestionId, question.QuestionTypes.QuestionTypeId);
            _context.Questions.Remove(deletedQuestion);
            await _context.SaveChangesAsync();
            return deletedQuestion;
        }
    }
}