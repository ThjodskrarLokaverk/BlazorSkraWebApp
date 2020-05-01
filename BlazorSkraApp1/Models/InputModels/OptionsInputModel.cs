using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class OptionsInputModel
    {
        [Required(ErrorMessage = "Velja þarf nafn á valkost")]
        [StringLength(50, ErrorMessage = "Nafn valkosts má ekki innihalda fleiri en 50 stafi")]
        public string OptionName { get; set; }
    }
}
