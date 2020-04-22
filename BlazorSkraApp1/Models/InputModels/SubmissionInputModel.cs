using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class SubmissionInputModel
    {
        public int FormId { get; set; }
        [ValidateComplexType]
        public RequiredString[] Answers { get; set; }
        public int[] AnswersOrderNum { get; set; }
        public List<string> MultipleAnswers { get; set; }
        public bool Confirmation { get; set; }
        public DateTime SelectedDate { get; set; }
    }

    public class RequiredString
    {
        [Required(ErrorMessage = "Reitur má ekki vera auður")]
        public string Value { get; set; }
    }
}