using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Models.ViewModels
{
    public class QuestionsViewModel
    {
        public string QuestionName { get; set; }
        public int QuestionOrderNum { get; set; }
        public int QuestionTypeId { get; set; }
        public int QuestionTypeOrderNum { get; set; }
    }
}
