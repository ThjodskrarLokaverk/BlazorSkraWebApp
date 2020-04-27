using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class SubmissionInputModel
    {
        public int FormId { get; set; }
        [ValidateComplexType]
        public RequiredShortText[] ShortText { get; set; }
        [ValidateComplexType]
        public RequiredLongText[] LongText { get; set; }
        [ValidateComplexType]
        public RequiredRadio[] Radio { get; set; }
        [ValidateComplexType]
        public RequiredCheckbox[] Checkbox { get; set; }
        [ValidateComplexType]
        public RequiredDate[] Date { get; set; }
        //public int[] AnswersOrderNum { get; set; }
        public List<string> MultipleAnswers { get; set; }
    }

    public class RequiredShortText
    {
        [Required(ErrorMessage = "Reitur má ekki vera auður")]
        [StringLength(100, ErrorMessage = "Hámarks stafafjöldi er 100 stafir")]
        public string Value { get; set; }
    }
    public class RequiredLongText
    {
        [Required(ErrorMessage = "Reitur má ekki vera auður")]
        [StringLength(4000, ErrorMessage = "Hámarks stafafjöldi er 4000 stafir")]
        public string Value { get; set; }
    }
    public class RequiredRadio
    {
        [Required(ErrorMessage = "Velja verður einn valkost")]
        public string Value { get; set; }
    }
    public class RequiredCheckbox
    {
        [Required(ErrorMessage = "Velja verður að minnsta kosti einn valkost")]
        public string Value { get; set; }
    }
    public class RequiredDate
    {
        [Required(ErrorMessage = "Velja verður gilda dagsetningu")]
        public string Value { get; set; }
    }
}