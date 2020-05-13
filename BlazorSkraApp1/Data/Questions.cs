using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Velja þarf titil spurningar")]
        [StringLength(200, ErrorMessage = "Spurning má ekki innihalda fleiri en 200 stafi")]
        public string QuestionName { get; set; }

        [Required(ErrorMessage = "Velja þarf spurningategund")]
        
        public QuestionTypes QuestionTypes { get; set; }
    }
}
