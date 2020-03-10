using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class Forms
    {
        [Required]
        public int QuestionOrderNum { get; set; }
        [Required]
        public int OptionOrderNum { get; set; }
        [Required]
        public int FormId { get; set; }

        [Required]
        //public int FormInfoId { get; set; }
        public virtual FormsInfo Form { get; set; }
        //public int QuestionId { get; set; }
        [Required]
        public Questions Questions { get; set; }
        //public int OptionId { get; set; }
        [Required]
        public QuestionOptions QuestionOptions { get; set; }
    }
}



