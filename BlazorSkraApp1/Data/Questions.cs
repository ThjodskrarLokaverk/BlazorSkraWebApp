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
        [Required(ErrorMessage = "Question name is required")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string QuestionName { get; set; }

        //public int QuestionTypeId { get; set; }
        [Required(ErrorMessage = "Question has to have a valid type")]
        public QuestionTypes QuestionTypes { get; set; }
    }
}
