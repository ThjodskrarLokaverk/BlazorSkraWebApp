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
    }
}