using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class QuestionTypes
    {
        [Key]
        public int QuestionTypeId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Spurningartýpa má ekki innihalda fleiri en 100 stafi")]
        public string QuestionTypeName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Spurningartýpa má ekki innihalda fleiri en 100 stafi")]
        public string QuestionType { get; set; }
    }
}
