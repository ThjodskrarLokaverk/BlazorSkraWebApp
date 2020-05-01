using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class Submissions
    {
        [Required]
        public int QuestionOrderNum { get; set; }
        [Required]
        public int AnswerOrderNum { get; set; }
        public string Answer { get; set; }
        [Required]
        public int SubmissionId { get; set; }
        [Required]
        public int FormId { get; set; }
        [Required]
        public int QuestionsQuestionId { get; set; }
        //[Required]
        public virtual SubmissionsInfo Submission { get; set; }
        //[Required]
        public virtual FormsInfo Form { get; set; }
        [Required]
        public Questions Questions { get; set; }

        




    }
}
