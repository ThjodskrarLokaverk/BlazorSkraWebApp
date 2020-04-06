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
        void sendMail(short FormId);

    }

    public class MailService : IMailService
    {

    MailForm mailForm = new MailForm();
    public void sendMail(short FormId)
    {
        var message = new MimeMessage();
        //Sender of email here
        message.From.Add(new MailboxAddress("blazor.boiler@gmail.com"));
        //receiver of email
        message.To.Add(new MailboxAddress("bbaldvinsson@gmail.com"));
        message.Subject = "helo";
        //aðaltextinn byggður upp
        message.Body = new TextPart("html")
        {
            Text = "Message: " + FormId
        };

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587);
            //notendanafn og lykilorð á pósthólfinu sem er sent úr
            client.Authenticate("blazor.boiler@gmail.com", "Trigger.0987");
            client.Send(message);
            client.Disconnect(false);

        }

    }

    }
}
