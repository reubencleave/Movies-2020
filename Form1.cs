using System;
using System.Security.Cryptography.X509Certificates;
namespace Movies_2020
{

	partial class Form1 : Form
	{
		//We need a connection to the Database
		private string connectionString = @"Data Source= M97HOFE2\SQLEXPRESS\SQLEXPRESS;Initial
Catalog=Movies;Integrated Security=True;";
		SqlConnection Con = new SqlConnection();
		DataTable CustomersTable = new DataTable();
		DataTable MoviesTable = new DataTable();
		DataTable RentalsTable = new DataTable();
		public Form1()
		{

		}


		private void loaddb()
		{
			//load datatable columns
			datatablecolumns();
			//Wrap the code in a using statement to dispose of it later
			using (SqlConnection connection = new SqlConnection(connectionString))
            {
				//Ask a question
				string QueryString = @"SELECT * FROM Customers order by ID";
				//Open the connection
				connection.Open();

				SqlCommand command = new SqlCommand(QueryString, connection);
				//Start the DB reader
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
                {
					//Add in each row to the datatable
					CustomersTable.Rows.Add(
					reader["Firstname"],
					reader["Surname"],
					reader["Address"],
					reader["Phhone"],
					reader["Datejoined"]),

                }
				//Close the DB reader
				reader.Close();
				//Close the connection
				connection.Close();
				//add the datatable to the Data Grid View
				dgvCustomers.DataSource = CustomersTable;
            }
			
			private void loaddb()
			{
				//load datatable columns
				datatablecolumns();
				//Wrap the code in a using statement to dispose of it later
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					//Ask a question
					string QueryString = @"SELECT * FROM Movies order by ID";
					//Open the connection
					connection.Open();

					SqlCommand command = new SqlCommand(QueryString, connection);
					//Start the DB reader
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						//Add in each row to the datatable
						MoviesTable.Rows.Add(
						reader["ID"]
						reader["Title"],
						reader["Genre"],
						reader["Year"],
						reader["Rating"],
						reader["Plot"],
						reader["Copies"],
						reader["Rental_cost"],
						reader["Date"],
						reader["Add"],


				}
					//Close the DB reader
					reader.Close();
					//Close the connection
					connection.Close();
					//add the datatable to the Data Grid View
					dgvCustomers.DataSource = CustomersTable;
				}
				private void loaddb()
				{
					//load datatable columns
					datatablecolumns();
					//Wrap the code in a using statement to dispose of it later
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						//Ask a question
						string QueryString = @"SELECT * FROM Customers order by ID";
						//Open the connection
						connection.Open();

						SqlCommand command = new SqlCommand(QueryString, connection);
						//Start the DB reader
						SqlDataReader reader = command.ExecuteReader();

						while (reader.Read())
						{
							//Add in each row to the datatable
							CustomersTable.Rows.Add(
							reader["Firstname"],
							reader["Surname"],
							reader["Address"],
							reader["Phhone"],
							reader["Datejoined"]),

                }
						//Close the DB reader
						reader.Close();
						//Close the connection
						connection.Close();
						//add the datatable to the Data Grid View
						dgvCustomers.DataSource = CustomersTable;
					}
				}



				//MessageBox.Show("Datatable
				public void datatablecolumns()
				{
					//clear the old data
					MoviesTable.Clear();
					//add in the column titles to the datatable
					try
					{
						MoviesTable.Columns.Add("ID");
						MoviesTable.Columns.Add("Title");
						MoviesTable.Columns.Add("Genre");
						MoviesTable.Columns.Add("Year");
						MoviesTable.Columns.Add("Rating");
						MoviesTable.Columns.Add("Plot");
						MoviesTable.Columns.Add("Copies");
						MoviesTable.Columns.Add("Rental_Cost");
						MoviesTable.Columns.Add("Date");
						MoviesTable.Columns.Add("Add");


					}
					catch
					{
						//MessageBox.Show("Datatable is not loading");


					}
					public void datatablecolumns()
					{
						//clear out the old data
						CustomersTable.Clear();
						//add in the column titles to the database
						try
						{
							CustomersTable.Columns.Add("Firstname");
							CustomersTable.Columns.Add("Surname");
							CustomersTable.Columns.Add("Address");
							CustomersTable.Columns.Add("Phone");
							CustomersTable.Columns.Add("DateJoined");

						}
						catch
						{
							//MessageBox.Show("DataTable is not loading");
						}
						public void datatablecolumns()
						{
							//clear out the old data
							RentalsTable.Clear();
							//add in the column titles to the database
							try
							{
								CustomersTable.Columns.Add("RMID");
								CustomersTable.Columns.Add("Firstname");
								CustomersTable.Columns.Add("Surname");
								CustomersTable.Columns.Add("Address");
								CustomersTable.Columns.Add("Title");
								CustomersTable.Columns.Add("Rental_cost");
								CustomersTable.Columns.Add("DateRented");
								CustomersTable.Columns.Add("DateReturned");
								CustomersTable.Columns.Add("Add");

							}
							catch
							{
								//MessageBox.Show("DataTable is not loading");
							}
						}		
					} }
			}		}							
