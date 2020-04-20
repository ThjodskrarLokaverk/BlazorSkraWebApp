using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSkraApp1.Reports;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;

namespace BlazorSkraApp1.Models.InputModels
{
    public class Report : PageModel
    {
        public string UserName { get; set; }
        public string FormName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Anonymous { get; set; }

    }
}