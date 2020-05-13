using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class QuestionsFormAssignments
    {
        public int FormId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOrderNum { get; set; }
        public int QuestionTypeOrderNum { get; set; }
        
        public virtual FormsInfo FormsInfo { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
