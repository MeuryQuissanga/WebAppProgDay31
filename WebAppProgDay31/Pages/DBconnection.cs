using System.Data.SqlClient;

namespace WebAppProgDay31.Pages
    
{
    //Method contain the conection string
    public class DBconnection
    {
        private string ConnectionString = "Server=tcp:novoserver.database.windows.net,1433;Initial Catalog=programmingpart2;Persist Security Info=False;User ID=meurydatabase;Password=Meury123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection sqlConnection =null;


        public SqlConnection isConnected()
        {
            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
