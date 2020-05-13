using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using Microsoft.AspNetCore.Identity;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.JSInterop;
using BlazorSkraApp1.Reports;
using BlazorSkraApp1.Models.InputModels;
using Serilog;

namespace BlazorSkraApp1.Services
{
    public interface IMailService
    {
        void MailBuilder(short FormId,  int submissionId, string userEmail, bool anonymous);
        void PDFBuilder(string formName, int submissionId, string userEmail, bool anonymous, IJSRuntime js);
    }

    public class MailService : IMailService
    {
        MailForm mailForm = new MailForm();
        string emailBody = "";
        List<Submissions> subList;
        FormsInfo formsInfo = new FormsInfo();

        private readonly ApplicationDbContext _context;

        public MailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SendMail()
        {   
            try{
            var message = new MimeMessage();
            var builder = new BodyBuilder ();
            //Sender of email here
            message.From.Add(new MailboxAddress("blazor.boiler@gmail.com"));
            //receiver of email
            message.To.Add(new MailboxAddress(formsInfo.DestinationEmail));
            message.Subject = "Ný innsending - " + formsInfo.FormName + " - " + DateTime.Now.ToString("dd/MM/yy");

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
            catch(Exception)
            {
                Log.Error($"Eitthvað fór úrskeiðis");
            }
        }

        public async Task<List<Submissions>> GetAnswers(int submissionId)
        {
            return await _context.Submissions
                .Where(s => s.SubmissionId == submissionId)
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
        public async void MailBuilder(short FormId,  int submissionId, string userEmail, bool anonymous)
        {
            subList = await GetAnswers(submissionId);
            //formsInfo = await GetForm(FormId);

            string newLine = Environment.NewLine;

            if (anonymous == false)
            {
                emailBody += "Sendandi: " + userEmail + newLine + newLine;
            }
            else
            {
                emailBody += "Sendandi óskaði eftir nafnleynd" + newLine + newLine;
            }
            
            //Answers added to email body
            foreach(var submissionLine in subList)
            {
                emailBody += submissionLine.QuestionOrderNum+1 + ". " + submissionLine.QuestionName + newLine;
                emailBody += "Svar: " + submissionLine.Answer + newLine + newLine;  
            }
            emailBody += "Númer innsendingar: " + submissionId;
            SendMail();
        }

        public async void PDFBuilder(string formName, int submissionId, string userEmail, bool anonymous, IJSRuntime js)
        {
            subList = await GetAnswers(submissionId);
            //var Form = await GetForm(FormId);

            List<Report> iReport = new List<Report>();

            foreach(var submissionLine in subList)
            {      
                iReport.Add(new Report(){ UserName = userEmail, FormName = formName, Question = submissionLine.QuestionName, Answer = submissionLine.Answer});
            }

            GeneratePDF(js, iReport);
        }

        public void GeneratePDF(IJSRuntime js, List<Report> iReport)
        {
            PrepareReport iPrepareReport = new PrepareReport();
            js.InvokeAsync<Report>(
                "SaveAsFile",
                "Submission.pdf",
                Convert.ToBase64String(iPrepareReport.PDFReport(iReport)));
        }

    }
}