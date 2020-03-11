using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class CategoriesAssignments
    {
        public int CategoryId { get; set; }
        public int FormId { get; set; }
        public Categories Categories { get; set; }
        public FormsInfo FormsInfo { get; set; }
    }
}
