using System.Threading.Tasks;
using BlazorSkraApp1.Data;


namespace BlazorSkraApp1.Services
{
    public interface IFormsInfoService
    {
        Task<FormsInfo> Add(FormsInfo forminfo);

        Task<FormsInfo> Delete(int formid);
        Task<FormsInfo> Update(int formid);
    }
    public class FormsInfoService : IFormsInfoService
    {
        private readonly ApplicationDbContext _context;

        public FormsInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates the specified form in the database
        public async Task<FormsInfo> Add(FormsInfo forminfo)
        {
            _context.FormsInfo.Add(forminfo);
            await _context.SaveChangesAsync();
            return forminfo;
        }

        // Deletes the specified form from the database
        public async Task<FormsInfo> Delete(int formid)
        {
            var form = await _context.FormsInfo.FindAsync(formid);
            _context.FormsInfo.Remove(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<FormsInfo> Update(int formid)
        {
            var form = await _context.FormsInfo.FindAsync(formid);
            _context.Entry(form).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return form;
        }
    }
}