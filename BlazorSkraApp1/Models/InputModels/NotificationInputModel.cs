using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Models.InputModels
{
    public class NotificationInputModel
    {
        public string CategoryId { get; set; }
        public string NewFormName { get; set; }
        public string DestinationEmail { get; set; }
        public string QuestionName { get; set; }
        public string QuestionTypeId { get; set; }
        public List<Options> Options { get; set; }
    }
}