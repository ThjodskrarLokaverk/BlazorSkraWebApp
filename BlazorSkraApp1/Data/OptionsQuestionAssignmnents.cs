using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class OptionsQuestionAssignmnents
    {
        public int OptionOrderNum { get; set; }
        public int OptionId { get; set; }
        public int FormId { get; set; }
        public int QuestionOrderNum { get; set; }
        
        public virtual QuestionsFormAssignments QuestionsFormAssignments { get; set; }
        public virtual Options Options { get; set; }
    }
}
