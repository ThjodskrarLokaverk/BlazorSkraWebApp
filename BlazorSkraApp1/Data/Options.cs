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
        [Required(ErrorMessage = "Velja þarf nafn á valkost")]
        [StringLength(200, ErrorMessage = "Nafn valkosts má ekki innihalda fleiri en 200 stafi")]
        public string OptionName { get; set; }
    }
}
