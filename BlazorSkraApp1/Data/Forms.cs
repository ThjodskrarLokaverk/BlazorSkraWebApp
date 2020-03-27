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

        //[Required]
        public virtual FormsInfo Form { get; set; }
        [Required]
        public Questions Questions { get; set; }
        //[Required] //If we have a text question the QuestionOptions Column is NULL
        public Options Options { get; set; }
    }
}



