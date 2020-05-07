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
        Task<FormsInfo> Add(FormsInfo formInfo);
        Task<FormsInfo> Delete(int formId);
        Task<FormsInfo> Update(FormsInfo forminfo);
        Task<FormsInfo> Get(int formId);
        Task<List<FormsInfo>> GetSearch(string SearchString);
        Task<FormsInfo> GetEmail(string DestinationEmail);
        Task<List<FormsInfo>> Get();
    }
    public class FormsInfoService : IFormsInfoService
    {
        private readonly ApplicationDbContext _context;

        public FormsInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates the specified form in the database
        public async Task<FormsInfo> Add(FormsInfo formInfo)
        {
            _context.FormsInfo.Add(formInfo);
            await _context.SaveChangesAsync();
            return formInfo;
        }

        // Deletes the specified form from the database
        public async Task<FormsInfo> Delete(int formId)
        {
            var form = await _context.FormsInfo.FindAsync(formId);
            _context.FormsInfo.Remove(form);
            await _context.SaveChangesAsync();
            return form;
        }

        // Updates the specified form
        public async Task<FormsInfo> Update(FormsInfo editedForm)
        {
            var form = await _context.FormsInfo.FindAsync(editedForm.FormId);
            form.FormName = editedForm.FormName;
            form.DestinationEmail = editedForm.DestinationEmail;
            _context.Entry(form).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<FormsInfo> Get(int formId)
        {
            return await _context.FormsInfo.FindAsync(formId);
        }

        public async Task<List<FormsInfo>> GetSearch(String SearchString)
        {
            var searchList = _context.FormsInfo.Where(x => x.FormName.Contains(SearchString)).ToListAsync();
            return await searchList;
        }

        public async Task<FormsInfo> GetEmail(string DestinationEmail)
        {
            return await _context.FormsInfo.FindAsync(DestinationEmail);
        }
        public async Task<List<FormsInfo>> Get()
        {
            return await _context.FormsInfo.ToListAsync();
        }
    }
}