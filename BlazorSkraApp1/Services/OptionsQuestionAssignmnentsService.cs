﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IOptionsQuestionAssignmnentsService
    {
        Task<List<OptionsQuestionAssignmnents>> Get();
        Task<List<OptionsQuestionAssignmnents>> Get(int formId);
        Task<OptionsQuestionAssignmnents> Add(OptionsQuestionAssignmnents option);
        Task<OptionsQuestionAssignmnents> Delete(OptionsQuestionAssignmnents option);
        Task<List<OptionsQuestionAssignmnents>> DeleteAll(int formId);
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

        public async Task<List<OptionsQuestionAssignmnents>> Get(int formId)
        {
            var optionsQuestionAssignmentList = await _context.OptionsQuestionAssignmnents
                .Where(f => f.FormId == formId)
                .Include(o => o.Options)
                .ToListAsync();
            return optionsQuestionAssignmentList;
        }

        public async Task<OptionsQuestionAssignmnents> Add(OptionsQuestionAssignmnents option)
        {
            _context.OptionsQuestionAssignmnents.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }
        public async Task<OptionsQuestionAssignmnents> Delete(OptionsQuestionAssignmnents option)
        {
            var deletedOption = await _context.OptionsQuestionAssignmnents.FindAsync(option.OptionOrderNum, option.FormId, option.QuestionOrderNum);
            _context.OptionsQuestionAssignmnents.Remove(deletedOption);
            await _context.SaveChangesAsync();
            return deletedOption;
        }

        //Removes all OptionsQuestionsAssignments and corresponding options in the specified form
        public async Task<List<OptionsQuestionAssignmnents>> DeleteAll(int formId)
        {
            var oqaList = await _context.OptionsQuestionAssignmnents
                .Where(oqa => oqa.FormId == formId)
                .ToListAsync();
            var optionsList = await _context.Options
                //.Where(o => oqaList.Any(oqa => oqa.OptionId == o.OptionId))
                .ToListAsync();
            optionsList.RemoveAll(o => oqaList.All(oqa => oqa.OptionId != o.OptionId));
            _context.OptionsQuestionAssignmnents.RemoveRange(oqaList);
            _context.Options.RemoveRange(optionsList);
            await _context.SaveChangesAsync();
            return oqaList;
        }
    }
}
