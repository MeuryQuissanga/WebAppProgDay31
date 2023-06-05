using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace WebAppProgDay31.Pages
{
    public class CrudOp
    {
        private DBconnection crud = new DBconnection();
        private SqlCommand command = null;
        public List<GetAndSet> listObj = new List<GetAndSet>();
        public bool Saved = false;
        public string query = "";
        public bool Logged = false;
        public bool farmerAdded = false;
        public bool ProductSaved = false;
        public List<GetAndSet> listD = new List<GetAndSet>();


        //Method to insert users
        public bool InsertIntoTable(string name, string pass, string system)
        {
            try
            {
                query = "insert into LoginTable (username, password, system) values (@Name, @Pass, @Role)";
                command = new SqlCommand(query, crud.isConnected());
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Pass", pass);
                command.Parameters.AddWithValue("@Role", system);
                command.ExecuteNonQuery();

                Saved = true;
            }
            catch (Exception e)
            {
                Saved = false;
            }
            return Saved;
        }

        //Method for the login page
        public bool LoginPage(string username, string pass, string role)
        {
            listObj.Clear();
            query = "Select * from LoginTable";

            command = new SqlCommand(query, crud.isConnected());
            try
            {
               using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string ID = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        string password = reader.GetString(2);
                        string system = reader.GetString(3);
                        if (name.Equals(username) && password.Equals(pass) && system.Equals(role))
                        {
                            listObj.Add(new GetAndSet());
                            Logged = true;
                        }
                    }
                }

            }
            catch (Exception e)

            {

            }

            return Logged;
        }

        //Method to insert farmer in the system.

        public bool InsertFarmer(string title, string Fname, string farm, string local, string startD, string endD)
        {
            try
            {
                query = "insert into Farmer (title, name, farm, location, startdate, enddate) values (@Title, @Farmname, @farm, @locality, @startdate, @enddate)";
                command = new SqlCommand(query, crud.isConnected());
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Farmname", Fname);
                //command.Parameters.AddWithValue("@cellphone", cell);
                command.Parameters.AddWithValue("@farm", farm);
                command.Parameters.AddWithValue("@locality", local);
                command.Parameters.AddWithValue("@startdate", startD);
                command.Parameters.AddWithValue("@enddate", endD);
                command.ExecuteNonQuery();
                farmerAdded = true;
            }
            catch (Exception e)

            {
                farmerAdded = false;
            }
            return farmerAdded;
        }

        //Method to add products on the database
        public bool InsertProduct(string ProductName, string ProductCategorie, string Price, string Quantity)
        {
            try
            {
                query = "insert into ProductTable (Product, Categorie, Price, Quantity) values (@product, @productcategorie, @price, @quantity)";
                command = new SqlCommand(query, crud.isConnected());
                command.Parameters.AddWithValue("@product", ProductName);
                command.Parameters.AddWithValue("@productcategorie", ProductCategorie);
                command.Parameters.AddWithValue("@price", Price);
                command.Parameters.AddWithValue("@quantity", Quantity);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    ProductSaved = true;
                }
                else
                {
                    ProductSaved = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ProductSaved;
        }

        //Method to display list of farmers and the products added
        public List<GetAndSet>  Table( )
        {
            listD.Clear();
            string sqlQuery = "SELECT * FROM ProductTable  ";
           
          
   
            using (SqlConnection connection = new SqlConnection("Server=tcp:novoserver.database.windows.net,1433;Initial Catalog=programmingpart2;Persist Security Info=False;User ID=meurydatabase;Password=Meury123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
               

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Saving all the values retrieved from the Azure SQL database to the list to be displayed in the employee menu table
                        listD.Add(new GetAndSet()
                        {
                            
                            FarmerName1 = reader.GetString(1),
                            Productid1 = reader.GetString(2),
                            StartDate1 = reader.GetString(3),
                            Locality1 = reader.GetString(4),
                          
                        });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception or log the error.
                }
            }

            return listD;
        }


    }





}
