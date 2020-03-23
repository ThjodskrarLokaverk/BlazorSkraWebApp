﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IFormsService
    {
        Task<List<Forms>> Get();
        Task<List<Forms>> Get(int FormId);
        //Task<Questions> GetQuestionsList(int FormId);
        //Task<CategoriesAssignments> Add(CategoriesAssignments CategoriesAssignment);
        //Task<CategoriesAssignments> Update(CategoriesAssignments CategoriesAssignment);
        //Task<CategoriesAssignments> Delete(int id);
    }

    public class FormsService : IFormsService
    {
        private readonly ApplicationDbContext _context;

        public FormsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Forms>> Get()
        {
            return await _context.Forms
                .Include(f => f.FormId)
                .Include(q => q.Questions)
                .Include(o => o.QuestionOptions)
                .ToListAsync();
        }

        public async Task<List<Forms>> Get(int FormId)
        {
            return await _context.Forms
                .Where(f => f.FormId == FormId)
                .Include(q => q.Questions)
                .Include(o => o.QuestionOptions)
                .ToListAsync();
        }

        /*
        public async Task<List<Questions>> GetQuestionsList(int FormId)
        {
            Questions questionsList = new Questions();

            questionsList = await
                from question in _context.Questions
                join form in _context.Forms on question.QuestionId equals form.Questions.QuestionId
                where form.FormId == FormId
                select question;


                
            return questionsList;
        }
        */
    }
}
