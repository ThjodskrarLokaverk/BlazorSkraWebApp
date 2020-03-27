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
        public int FormId { get; set; }
        [Required(ErrorMessage = "Velja þarf heiti tilkynningar")] //Form name is required
        [StringLength(20, ErrorMessage = "Heiti tilkynningar er of langt")] //Name is too long.
        public string FormName { get; set; }
    }
}
