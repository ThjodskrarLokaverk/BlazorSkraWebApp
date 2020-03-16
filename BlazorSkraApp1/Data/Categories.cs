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
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string CategoryName { get; set; }
    }
}
