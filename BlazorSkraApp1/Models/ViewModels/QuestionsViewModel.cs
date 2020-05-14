using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Models.ViewModels
{
    public class QuestionsViewModel
    {
        public string QuestionName { get; set; }
        public string QuestionType { get; set; }
        public int QuestionOrderNum { get; set; }
        public int QuestionTypeOrderNum { get; set; }

        public List<OptionsViewModel> Options { get; set; }
    }
}
