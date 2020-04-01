using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

public interface IQuestionTypesService
{
    Task<List<QuestionTypes>> Get();
    Task <QuestionTypes> Get(int typeid);
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
        public async Task<QuestionTypes> Get(int typeid)
        {
            return await _context.QuestionTypes.FindAsync(typeid);
        }
    }
}