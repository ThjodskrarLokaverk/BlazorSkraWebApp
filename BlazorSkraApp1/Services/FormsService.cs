using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Services
{
    public interface IFormsService
    {
      
       
    }

    public class FormsService : IFormsService
    {
        private readonly ApplicationDbContext _context;

        public FormsService(ApplicationDbContext context)
        {
            _context = context;
        }

       

       
    }
}
