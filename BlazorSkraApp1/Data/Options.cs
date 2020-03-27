using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class Options
    {
        [Key]
        public int OptionId { get; set; }
        [Required(ErrorMessage = "Option name is required")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string OptionName { get; set; }
    }
}
