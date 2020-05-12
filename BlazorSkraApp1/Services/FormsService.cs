using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Models.ViewModels;

namespace BlazorSkraApp1.Services
{
    public interface IFormsService
    {
        Task<FormsViewModel> Get(int FormId);
    }

    public class FormsService : IFormsService
    {
        private readonly ApplicationDbContext _context;

        public FormsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FormsViewModel> Get(int FormId)
        {
            var formCategoryAssignment = await _context.CategoriesAssignments
                .Where(c => c.FormId == FormId)
                .Include(f => f.FormsInfo)
                .Include(c => c.Categories)
                .FirstOrDefaultAsync();

            var questions = await _context.QuestionsFormAssignments
                .Where(qfa => qfa.FormId == FormId)
                .Include(q => q.Questions)
                    .ThenInclude(qt => qt.QuestionTypes)
                .ToListAsync();
            
            var options = await _context.OptionsQuestionAssignmnents
                .Where(oqa => oqa.FormId == FormId)
                .Include(o => o.Options)
                .ToListAsync();
            
            //Save fetched data to FormsViewModel
            var form = new FormsViewModel();
            form.Questions = new List<QuestionsViewModel>();
            form.CategoryId = formCategoryAssignment.CategoryId;
            form.CategoryName = formCategoryAssignment.Categories.CategoryName;
            form.DestinationEmail = formCategoryAssignment.FormsInfo.DestinationEmail;
            form.FormName = formCategoryAssignment.FormsInfo.FormName;
            form.IsAnonymous = formCategoryAssignment.FormsInfo.IsAnonymous;

            foreach (var fetchedQuestion in questions)
            {
                var question = new QuestionsViewModel();
                question.QuestionName = fetchedQuestion.Questions.QuestionName;
                question.QuestionOrderNum = fetchedQuestion.QuestionOrderNum;
                question.QuestionTypeId = fetchedQuestion.Questions.QuestionTypes.QuestionTypeId;
                question.QuestionTypeOrderNum = fetchedQuestion.QuestionTypeOrderNum;
                question.Options = new List<OptionsViewModel>();
                
                foreach(var fetchedOption in options.Where(o => o.QuestionOrderNum == question.QuestionOrderNum))
                {
                    var option = new OptionsViewModel();
                    option.OptionName = fetchedOption.Options.OptionName;
                    option.OptionOrderNum = fetchedOption.OptionOrderNum;
                    question.Options.Add(option);
                }
                form.Questions.Add(question);
            }

            return form;
        }
    }
}
