using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProgDay31.Pages
{
    public class FarmerAndProductViewModel : PageModel
    {
        public List<GetAndSet> ViewObj = new List<GetAndSet>();
        public string farmer="";
        public string productname = "";
        public string StartDate = "";
        public string EndDate = "";
        private bool isChecked=false;
        public  CrudOp  obj= new CrudOp();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            farmer = Request.Form[""];
            productname = Request.Form[""];
            StartDate = Request.Form[""];
            EndDate = Request.Form[""];
         if(!string.IsNullOrWhiteSpace(StartDate) && string.IsNullOrWhiteSpace(StartDate))
            {
                        isChecked = false;
            }
            if (string.IsNullOrWhiteSpace(StartDate) && !string.IsNullOrWhiteSpace(StartDate))
            {
                isChecked = false;
            }

            if (string.IsNullOrWhiteSpace(StartDate) && string.IsNullOrWhiteSpace(StartDate))
            {
                isChecked = true;
            }

            if (!string.IsNullOrWhiteSpace(StartDate) && !string.IsNullOrWhiteSpace(StartDate))
            {
                isChecked = true;
            }

            if (isChecked)
            {

            }
        }
    }
    }

       

