using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeFood
{
    public class ListModel : PageModel
    {
        private IConfiguration _confg;
        public ListModel(IConfiguration confg)
        {
            _confg = confg;
        }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = _confg["Message"];
        }
    }
}