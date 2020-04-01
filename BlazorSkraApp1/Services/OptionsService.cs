using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IOptionsService
    {
        Task<Options> Add(Options option);
        Task<Options> Update(Options option);
        Task<Options> Delete(Options option);
    }
    public class OptionsService : IOptionsService
    {
        private readonly ApplicationDbContext _context;

        public OptionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Options> Add(Options option)
        {
            _context.Options.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }
        public async Task<Options> Update(Options option)
        {
            var updatedOption = await _context.Options.FindAsync(option.OptionId);
            _context.Entry(updatedOption).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedOption;
        }
        public async Task<Options> Delete(Options option)
        {
            var deletedOption = await _context.Options.FindAsync(option.OptionId);
            _context.Options.Remove(deletedOption);
            await _context.SaveChangesAsync();
            return deletedOption;
        }
    }
}