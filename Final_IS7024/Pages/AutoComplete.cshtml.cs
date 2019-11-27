using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_IS7024.Pages
{
    public class AutoCompleteModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> tvShowNames = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["term"];

            
            AddTvShow("Friends");
            AddTvShow("Shark Tanks");
            AddTvShow("");

            return new JsonResult(tvShowNames);
        }

        private void AddTvShow(string studentName)
        {
            string lowername = studentName.ToLower();
            string lowerterm = Term.ToLower();
            if (lowername.Contains(lowerterm))
            {
                tvShowNames.Add(studentName);
            }
        }
    }

}
