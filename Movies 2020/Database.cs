using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Movies_2020
{
    class Database
    {
       public string connectionString = @"Data Source = LAPTOP - M97HOFE2\SQLEXPRESS; Integrated Security = True";
        string ConnectionString = @"Data Source=LAPTOP-M97HOFE2\SQLEXPRESS;Initial Catalog=VBMOVIESFULLDATA.MDF;Integrated Security=True;";

        //Create a Connection, Command, Adapter
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public Database()
        {
            string connectionString = @"Data Source=LAPTOP-M97HOFE2\SQLEXPRESS;Initial Catalog = VBMOVIESFULLDATA.MDF; Integrated Security = True;";
            Connection.ConnectionString = connectionString;
            Command.Connection = Connection;
        }

        public DataTable FillDGVCustomers()
        {
            //create a database as we only have one table, the Customer
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter data = new SqlDataAdapter("select * from Customer", Connection))
            {
                //connect into the Database and get the SQL
                Connection.Open();
                //open a connection to the Database 
                data.Fill(dataTable);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }

            return dataTable; //pass the datatable data to the DataGridView
        }


        public DataTable FillDGVMovies()
        {
            //create a database as we only have one table, the Movie
            DataTable dataTable = new DataTable();
            using (da = new SqlDataAdapter("select * from Movies", Connection))
            {
                //connect into the Database and get the SQL
                Connection.Open();
                //open a connection to the Database 
                da.Fill(dataTable);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
            return dataTable; //pass the datatable data to the DataGridView
        }


        public DataTable FillDGVRentals()
        {
            //create a database as we only have one table, the Rental
            DataTable dataTable = new DataTable();
            using (da = new SqlDataAdapter("select * from RentedMovies", Connection))
            {
                //connect into the Database and get the SQL
                Connection.Open();
                //open a connection to the Database 
                da.Fill(dataTable);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }

            return dataTable; //pass the datatable data to the DataGridView
        }
        /// <summary>
        /// The insert cust.
        /// </summary>
        /// <param name="insertArr">The insert arr.</param>
        public void InsertCust(string[] insertArr)
        {
            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string entryStatement = "INSERT INTO Customers(FirstName, Surname, Address, Phone) VALUES(@FirstName, @SurName, @Address, @Phone, @DateJoined)";

            // Define DB Connection
            SqlConnection Connection = new SqlConnection(ConnectionString);

            using (SqlCommand entryData = new SqlCommand(entryStatement, Connection))
            {
                // Assigns Parameters
                entryData.Parameters.AddWithValue("@FirstName", insertArr[0]);
                entryData.Parameters.AddWithValue("@SurName", insertArr[1]);
                entryData.Parameters.AddWithValue("@Address", insertArr[2]);
                entryData.Parameters.AddWithValue("@Phone", insertArr[3]);
                entryData.Parameters.AddWithValue("@DateJoined", insertArr[4]);

                // Open DB Connection
                Connection.Open();

                // Run SQL Command - Will return how many rows were effected
                int returnValue = entryData.ExecuteNonQuery();

                // Close DB Connection
                Connection.Close();
            }
        }

        public string AddCustomer(string Firstname, string Surname, string Address, string Phone, string dateJoined, string Add)
        {
            try
            {
                //Add gets passed through the parameter
                if (Add == "Add")
                {
                    //Create a command object //Create a query. create and open a connection to SQL server
                 string query = "INSERT INTO Customers (Firstname, Surname, Address, Phone, Date Joined) VALUES (@Firstname, @Surname, @Address, @Phone, @Date Joined)";

                    var myCommand = new SqlCommand(query, Connection);
                    //create parameters
                    myCommand.Parameters.AddWithValue("@FirstName", Firstname);
                    myCommand.Parameters.AddWithValue("@SurName", Surname);
                    myCommand.Parameters.AddWithValue("@Address", Address);
                    myCommand.Parameters.AddWithValue("@Phone", Phone);
                    myCommand.Parameters.AddWithValue("@Date Joined", dateJoined);
                    //myCommand.Parameters.AddWithValue("@DateJoined", DateJoined);
                    Connection.Open();
                    // Open Connection and add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();


                }



                return "is successful";
            }
            catch (Exception e)
            {
                //need to get it to close a second time 
                Connection.Close();
                return "has failed with" + e;
            }

        }
        
        

        public void DeleteCustomer(string ID)
        {
            var myCommand = new SqlCommand("DELETE FROM Customer where CustomerID = @ID", Connection);
            myCommand.Parameters.AddWithValue("@ID", ID);
            Connection.Open();
            myCommand.ExecuteNonQuery();
            Connection.Close();

        }
        public void AddMovie(string ID, string Title, string Genre, string Year, string Rating, string Plot, string Copies, string Rental_cost, string Date, string Add)
        {
            try
            {
                //Add gets passed through the parameter
                if (Add == "Add")
                {
                    //Create a command object //Create a query. create and open a connection to SQL server
                    string query = "INSERT INTO Movies (ID, Title, Genre, Year, Rating, Plot, Copies, Rental_cost, Date, Add) VALUES (@ID, @Title, @Genre, @Year, @Rating, @Plot, @Copies, @Rental_Cost, @Date, @Add)";

                    var myCommand = new SqlCommand(query, Connection);
                    //create parameters
                    myCommand.Parameters.AddWithValue("@ID", ID);
                    myCommand.Parameters.AddWithValue("@Title", Title);
                    myCommand.Parameters.AddWithValue("@Genre", Genre);
                    myCommand.Parameters.AddWithValue("@Year", Year);
                    myCommand.Parameters.AddWithValue("@Rating", Rating);
                    myCommand.Parameters.AddWithValue("@Plot", Plot);
                    myCommand.Parameters.AddWithValue("@Copies", Copies);
                    myCommand.Parameters.AddWithValue("@Rental_cost", Rental_cost);
                    myCommand.Parameters.AddWithValue("@Date", Date);
                    myCommand.Parameters.AddWithValue("@Add", Add);

                    //myCommand.Parameters.AddWithValue("@DateJoined", DateJoined);
                    Connection.Open();
                    // Open Connection and add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();


                }
            }
            catch { }
        }

        public void AddRental(String RMID, string FirstName, string Surname, String Address, string Title, string Rental_cost, string DateRented, string DateReturned, string Add)
        {
            try
            {
                //Add gets passed through the parameter
                if (Add == "Add")
                {
                    //Create a command object //Create a query. create and open a connection to SQL server
                    string query = "INSERT INTO Rentals (RMID, Firstname, Surname, Address, Title, Rental_cost, DateRented, DateReturned) VALUES (@RMID, @Firstname, @Surname, @Address, @Title, @Rental_cost, @DateRented, @DateReturned,)";

                    var myCommand = new SqlCommand(query, Connection);
                    //create parameters
                    myCommand.Parameters.AddWithValue("@RMID", RMID);
                    myCommand.Parameters.AddWithValue("@FirstName", FirstName);
                    myCommand.Parameters.AddWithValue("@Surname", Surname);
                    myCommand.Parameters.AddWithValue("@Address", Address);
                    myCommand.Parameters.AddWithValue("@Title", Title);
                    myCommand.Parameters.AddWithValue("@Rental_Cost", Rental_cost);
                    myCommand.Parameters.AddWithValue("@DateRented", DateRented);
                    myCommand.Parameters.AddWithValue("@DateReturned", DateReturned);

                    //myCommand.Parameters.AddWithValue("@DateJoined", DateJoined);
                    Connection.Open();
                    // Open Connection and add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();


                }
            }
            catch { }
            }

    }
}