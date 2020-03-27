using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IOptionsQuestionAssignmnentsService
    {
        Task<List<OptionsQuestionAssignmnents>> Get();
        Task<OptionsQuestionAssignmnents> Add(OptionsQuestionAssignmnents option);
    }
    public class OptionsQuestionAssignmnentsService : IOptionsQuestionAssignmnentsService
    {
        private readonly ApplicationDbContext _context;

        public OptionsQuestionAssignmnentsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OptionsQuestionAssignmnents>> Get()
        {
            return await _context.OptionsQuestionAssignmnents
                .Include(o => o.Options)
                .ToListAsync();
        }

        public async Task<OptionsQuestionAssignmnents> Add(OptionsQuestionAssignmnents option)
        {
            _context.OptionsQuestionAssignmnents.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }
    }
}
