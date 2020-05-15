using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class QuestionsInputModel
    {
        [Required(ErrorMessage = "Velja þarf titil spurningar")]
        [StringLength(100, ErrorMessage = "Spurning má ekki innihalda fleiri en 100 stafi")]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "Velja þarf spurningategund")]
        public string QuestionType { get; set; }
        [ValidateComplexType]
        public List<OptionsInputModel> Options { get; set; }
    }
}
