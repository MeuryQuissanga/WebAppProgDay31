using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace WebAppProgDay31.Pages
{
    public class FarmerTableModel : PageModel
    {
        public CrudOp obj = new CrudOp();
        private string FarmerName = "";
        private string FarmerCellphone = "";
        private string FarmName = "";
        private string Locality = "";
        private string StartDate = "";
        private string EndDate = "";
        public string validMessage = "";
        public string invalidMessage = "";
        private string Title = "";
        public string here= "";

        public string FarmerName1 { get => FarmerName; set => FarmerName = value; }
        public string FarmerCellphone1 { get => FarmerCellphone; set => FarmerCellphone = value; }
        public string FarmName1 { get => FarmName; set => FarmName = value; }
        public string Locality1 { get => Locality; set => Locality = value; }
        public string StartDate1 { get => StartDate; set => StartDate = value; }
        public string EndDate1 { get => EndDate; set => EndDate = value; }
        public string Title1 { get => Title; set => Title = value; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try {
                Title = Request.Form["title"];
                FarmerName = Request.Form["name"];
                FarmName = Request.Form["farm"];
                Locality = Request.Form["locality"];
                StartDate = Request.Form["sdate"];
                EndDate = Request.Form["edate"];

                if (obj.InsertFarmer(Title, FarmerName, FarmName, Locality, StartDate, EndDate))
                {
                    validMessage = "Farmer Added!";                 
                }
                else
                {
                    invalidMessage = "Please try again!";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(  e);
            }

        }
    }
}

