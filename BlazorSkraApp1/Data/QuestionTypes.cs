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
        [StringLength(20)]
        public string QuestionTypeName { get; set; }

        public List<Questions> QuestionList { get; set; }
    }
}
