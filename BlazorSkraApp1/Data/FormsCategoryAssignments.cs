using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class FormsCategoryAssignments
    {
        public int CategoryId { get; set; }
        public int FormId { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual FormsInfo FormsInfo { get; set; }
    }
}
