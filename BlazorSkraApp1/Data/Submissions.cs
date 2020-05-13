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
        [StringLength(250, ErrorMessage = "Spurning má ekki innihalda fleiri en 250 stafi")]
        public string QuestionName { get; set; }
        [Required]
        public int SubmissionId { get; set; }
        public virtual SubmissionsInfo SubmissionInfo { get; set; }
    }
}
