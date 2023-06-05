using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProgDay31.Pages
{
    public class ProductTableModel : PageModel
    {
        public CrudOp operations = new CrudOp();
        private string Productid = "";
        private string ProductName = "";
        private string ProductCategorie = "";
        private string  Price="";
        private string Quantity= "";
        public string validMessage = "";
        public string InvalidMessage = "";

        public string Productid1 { get => Productid; set => Productid = value; }
        public string ProductName1 { get => ProductName; set => ProductName = value; }
        public string ProductCategorie1 { get => ProductCategorie; set => ProductCategorie = value; }
        public string Price1 { get => Price; set => Price = value; }
        public string Quantity1 { get => Quantity; set => Quantity = value; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                ProductName = Request.Form["productname"];
                ProductCategorie = Request.Form["productcategorie"];
                Price = Request.Form["price"];
                Quantity = Request.Form["quantity"];
           
                if (operations.InsertProduct(ProductName, ProductCategorie, Price, Quantity))
                {
                    validMessage = "Product Saved!";
                }
                else
                {
                    InvalidMessage = "Product Not saved, please try again!";
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }            
        }
    }
}


