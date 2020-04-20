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
        public int FormId { get; set; }
        public string Test { get; set; }
        public RequiredString[] Answers { get; set; }
        public int[] AnswersOrderNum { get; set; }
        public List<string> MultipleAnswers { get; set; }
        public bool Confirmation { get; set; }
        public DateTime SelectedDate { get; set; }
    }

    public class RequiredString
    {
        [Required(ErrorMessage = "ATH!!")]
        [StringLength(100, MinimumLength = 1)]
        public string Value { get; set; }
    }
}