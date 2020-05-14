using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

public interface IQuestionTypesService
{
    Task<List<QuestionTypes>> Get();
    Task<QuestionTypes> Get(int typeId);
    Task<QuestionTypes> Get(string questionType);
}

namespace BlazorSkraApp1.Services
{
    public class QuestionTypesService : IQuestionTypesService
    {
        private readonly ApplicationDbContext _context;

        public QuestionTypesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionTypes>> Get()
        {
            return await _context.QuestionTypes.ToListAsync();
        }
        public async Task<QuestionTypes> Get(int typeId)
        {
            return await _context.QuestionTypes.FindAsync(typeId);
        }

        public async Task<QuestionTypes> Get(string questionType)
        {
            return await _context.QuestionTypes.Where(qt => qt.QuestionType.Equals(questionType)).FirstOrDefaultAsync();
        }
    }
}