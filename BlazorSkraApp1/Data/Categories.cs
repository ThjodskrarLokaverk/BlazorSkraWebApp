using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Velja þarf nafn flokks")]
        [StringLength(20, ErrorMessage = "Nafn flokks má ekki innihalda fleiri en 20 stafi")]
        public string CategoryName { get; set; }
    }
}
