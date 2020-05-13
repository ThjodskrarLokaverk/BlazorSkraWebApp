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
        Task<FormsViewModel> Get(int formId);
    }

    public class FormsService : IFormsService
    {
        private readonly ApplicationDbContext _context;

        public FormsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FormsViewModel> Get(int formId)
        {
            var formCategoryAssignment = await _context.CategoriesAssignments
                .Where(c => c.FormId == formId)
                .Include(f => f.FormsInfo)
                .Include(c => c.Categories)
                .FirstOrDefaultAsync();

            var questions = await _context.QuestionsFormAssignments
                .Where(qfa => qfa.FormId == formId)
                .Include(q => q.Questions)
                    .ThenInclude(qt => qt.QuestionTypes)
                .ToListAsync();
            
            var options = await _context.OptionsQuestionAssignmnents
                .Where(oqa => oqa.FormId == formId)
                .Include(o => o.Options)
                .ToListAsync();

            //Save fetched data to FormsViewModel
            var form = new FormsViewModel
            {
                Questions = new List<QuestionsViewModel>(),
                CategoryId = formCategoryAssignment.CategoryId,
                CategoryName = formCategoryAssignment.Categories.CategoryName,
                DestinationEmail = formCategoryAssignment.FormsInfo.DestinationEmail,
                FormName = formCategoryAssignment.FormsInfo.FormName,
                IsAnonymous = formCategoryAssignment.FormsInfo.IsAnonymous
            };

            foreach (var fetchedQuestion in questions)
            {
                var question = new QuestionsViewModel
                {
                    QuestionName = fetchedQuestion.Questions.QuestionName,
                    QuestionOrderNum = fetchedQuestion.QuestionOrderNum,
                    QuestionTypeId = fetchedQuestion.Questions.QuestionTypes.QuestionTypeId,
                    QuestionTypeOrderNum = fetchedQuestion.QuestionTypeOrderNum,
                    Options = new List<OptionsViewModel>()
                };

                foreach (var fetchedOption in options.Where(o => o.QuestionOrderNum == question.QuestionOrderNum))
                {
                    var option = new OptionsViewModel
                    {
                        OptionName = fetchedOption.Options.OptionName,
                        OptionOrderNum = fetchedOption.OptionOrderNum
                    };
                    question.Options.Add(option);
                }
                form.Questions.Add(question);
            }

            return form;
        }
    }
}
