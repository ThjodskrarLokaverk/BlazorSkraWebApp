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
    }
}