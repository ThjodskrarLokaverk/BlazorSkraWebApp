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
        [Required]
        public string Answer { get; set; }
        [Required]
        public int SubmissionId { get; set; }
        [Required]
        public int FormId { get; set; }
        [Required]
        public int QuestionsQuestionId { get; set; }
        public DateTime SubmissionDate { get; set; }  // To be able to identify submissions by date, and delete old submissions
        [Required]
        //[Required]
        public virtual SubmissionsInfo Submission { get; set; }
        //[Required]
        public virtual FormsInfo Form { get; set; }
    }
}
