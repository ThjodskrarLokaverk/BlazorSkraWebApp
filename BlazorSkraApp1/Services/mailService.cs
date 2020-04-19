using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using Microsoft.AspNetCore.Identity;
using MailKit.Net.Smtp;
using MimeKit;


namespace BlazorSkraApp1.Services
{
    public interface IMailService
    {
        void mailBuilder(short FormId,  int submissionId, string userEmail, bool anonymous);
    }

    public class MailService : IMailService
    {
        MailForm mailForm = new MailForm();
        List<QuestionsFormAssignments> questionsList ;
        string emailBody = "";
        List<Submissions> subList;
        string userMail;
        FormsInfo formsInfo = new FormsInfo();

        

        private readonly ApplicationDbContext _context;

        public MailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void sendMail()
        {   
            //message.Body = myList;
            var message = new MimeMessage();
            var builder = new BodyBuilder ();
            //Sender of email here
            message.From.Add(new MailboxAddress("blazor.boiler@gmail.com"));
            //receiver of email
            message.To.Add(new MailboxAddress(formsInfo.DestinationEmail));
            message.Subject = "Ný tilkynning - Heiti: " + formsInfo.FormName + " - " +  "Dagsetning: " + DateTime.Now.ToShortDateString();

            builder.TextBody = emailBody;

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                //notendanafn og lykilorð á pósthólfinu sem er sent úr
                client.Authenticate("blazor.boiler@gmail.com", "Trigger.0987");
                client.Send(message);
                client.Disconnect(false);
            }
        }

         public async Task<List<Submissions>> GetAnswers(int submissionId)
        {
            return await _context.Submissions
                .Include(i => i.Submission)
                .Include(f => f.Form)
                .Where(s => s.Submission.SubmissionId == submissionId)
                .ToListAsync();
        }

        public async Task<Categories> GetCategory(int CategoryId)
        {
            var categories = await _context.Categories.FindAsync(CategoryId);
            return categories;
        }

         public async Task<List<QuestionsFormAssignments>> GetQuestions(int formId)
        {
            return await _context.QuestionsFormAssignments
                .Where(f => f.FormId == formId)
                .Include(q => q.Questions)
                    .ThenInclude(qt => qt.QuestionTypes)
                .ToListAsync();
        }

        public async Task<FormsInfo> GetForm(int formId)
        {
            return await _context.FormsInfo.FindAsync(formId);
        }
        
    
        public async void mailBuilder(short FormId,  int submissionId, string userEmail, bool anonymous)
        {
            subList = await GetAnswers(submissionId);
            questionsList = await GetQuestions(FormId);
            formsInfo = await GetForm(FormId);
            userMail = userEmail;

            string newLine = Environment.NewLine;

            if (anonymous == false)
            {
                emailBody += "Sendandi tilkynningar: " + userEmail + newLine + newLine;
            }
            else
            {
                emailBody += "Sendandi tilkynningar óskaði eftir nafnleynd" + newLine + newLine;
            }
            
            foreach(var question in questionsList)
            {
                emailBody += question.QuestionOrderNum + ". " +question.Questions.QuestionName + newLine;
                
                foreach(var answer in subList.Where(answer => answer.QuestionsQuestionId == question.Questions.QuestionId))
                {
                   emailBody += "Svar: " + answer.Answer + newLine + newLine;  
                }
            }
            sendMail();
        }

    }
}