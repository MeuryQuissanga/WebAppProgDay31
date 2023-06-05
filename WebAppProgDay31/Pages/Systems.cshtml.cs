using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebAppProgDay31.Pages
{
    public class SystemsModel : PageModel
    {
        private string Username = "";
        private string Password = "";
        private string System = "";
        public string invalidMessage = "";
        public string validMessage = "";
        public string Message = "";
        public CrudOp objHere = new CrudOp();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Username = Request.Form["username"];
            Password = Request.Form["password"];
            System = Request.Form["System"];

            if (System.Equals("employee"))
            {
                if (objHere.LoginPage(Username, Password, System))
                {
                    validMessage = "Access granted!";
                    Response.Redirect("FarmerTable");
                }
                else
                {
                    invalidMessage = "User not found!";
                }
            }
            else
            {
                if (objHere.LoginPage(Username, Password, System))
                {
                    validMessage = "Access granted!";
                    Response.Redirect("/ProductTable");
                }
                else
                {
                    invalidMessage = "User not found, please contact the administrator";
                }
            }           
           
            }
           
        }
    }
