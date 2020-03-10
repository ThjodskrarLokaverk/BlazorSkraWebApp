using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class FormsInfo
    {
        [Key]
        public int FormInfoId { get; set; }
        [Required(ErrorMessage = "Form name is required")]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string FormName { get; set; }
    }
}
