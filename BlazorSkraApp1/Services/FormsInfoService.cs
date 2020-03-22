using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;


namespace BlazorSkraApp1.Services
{
    public interface IFormsInfoService
    {
        Task<FormsInfo> Add(FormsInfo forminfo);

        Task<FormsInfo> Delete(int formid);
    }
    public class FormsInfoService : IFormsInfoService
    {
        private readonly ApplicationDbContext _context;

        public FormsInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<FormsInfo> Add(FormsInfo forminfo)
        {
            _context.FormsInfo.Add(forminfo);
            await _context.SaveChangesAsync();
            return forminfo;
        }
        public async Task<FormsInfo> Delete(int formid)
        {
            var form = await _context.FormsInfo.FindAsync(formid);
            _context.FormsInfo.Remove(form);
            await _context.SaveChangesAsync();
            return form;
        }
    }
}