using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSkraApp1.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class QuestionInputModel
    {
        [Required(ErrorMessage = "Velja þarf titil spurningar")]
        [StringLength(50, ErrorMessage = "Spurning má ekki innihalda fleiri en 50 stafi")]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "Velja þarf spurningategund")]
        public string QuestionTypeId { get; set; }
        [ValidateComplexType]
        public List<Options> Options { get; set; }
    }
}
