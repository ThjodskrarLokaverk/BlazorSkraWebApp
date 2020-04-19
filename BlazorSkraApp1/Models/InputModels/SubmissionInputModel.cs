using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class SubmissionInputModel
    {

        public int FormId;
        //[Required(ErrorMessage = "Required")]
        //[StringLength(500, ErrorMessage = "Hámarks stafafjöldi er 500 stafir")]
        //public string[] Answers;
        public RequiredString[] Answers { get; set; }
        public int[] AnswersOrderNum;
        public List<string> MultipleAnswers;
        public bool Confirmation;
        public DateTime SelectedDate;
    }

    public class RequiredString
    {
        [Required]
        public string Value { get; set; }
    }
}