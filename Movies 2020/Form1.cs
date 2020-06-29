using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Movies_2020
{

    public partial class Form1 : Form
    {
        //create an instance of the Database class
        Database myDatabase = new Database();
        string ConnectionString = @"Data Source=LAPTOP-M97HOFE2\SQLEXPRESS;Initial Catalog=VBMOVIESFULLDATA.MDF;Integrated Security=True;";


        //Create a Connection, Command, Adapter
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter data = new SqlDataAdapter();


        public object connection { get; private set; }

        public Form1()
        {
            InitializeComponent();
            
         string ConnectionString = @"Data Source = LAPTOP - M97HOFE2\SQLEXPRESS; Integrated Security = True;";
            Connection.ConnectionString = ConnectionString;
            Command.Connection = Connection;

            LoadDB();
        }

        public void LoadDB()
        {
            //load the Customers dgv
            DisplayGridViewCustomers();

            //load the Movies dgv
            DisplayGridViewMovies();

            //load the Rentals dgv
            DisplayGridViewRentals();
        }
        //load the Customer datagrid
        private void DisplayGridViewCustomers()
        {
            //clear out the old data
            DGVCustomers.DataSource = myDatabase.FillDGVCustomers();
        }
        // DGVCustomers.AutoresizeColumns(DataGridViewAutoSizeColumnMode.AllCells);

        //load the Movies datagrid
        private void DisplayGridViewMovies()
        {
            //clear out the old data
            DGVMovies.DataSource = myDatabase.FillDGVMovies();
        }
        // DGVMovies.AutoresizeColumns(DataGridViewAutoSizeColumnMode.AllCells);

        //load the Rentals datagrid
        private void DisplayGridViewRentals()
        {
            //clear out the old data
            DGVRentals.DataSource = myDatabase.FillDGVRentals();
        }
        // DGVRentals.AutoresizeColumns(DataGridViewAutoSizeColumnMode.AllCells);

        

        private void loaddb()
        {
            //load datatable columns
            datatablecolumns();
        }

        private void datatablecolumns()
        {
            throw new NotImplementedException();
        }

        private void DGVMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //show the data in the DGV in the text boxes
                string newvalue = DGVMovies.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //show the output on the header
                string text = "Row :" + e.RowIndex.ToString() + " Col :" + e.ColumnIndex.ToString() + "Value =" + newvalue;

                //pass the data to the text boxes
                txtID.Text = DGVCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = DGVCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtGenre.Text = DGVCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtYear.Text = DGVCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtRating.Text = DGVCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPlot.Text = DGVCustomers.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCopies.Text = DGVCustomers.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtRental_cost.Text = DGVCustomers.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDate.Text = DGVCustomers.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAdd.Text = DGVCustomers.Rows[e.RowIndex].Cells[9].Value.ToString();

            }
            catch { }



        }

        private void DGVCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //show the data in the DGV in the text boxes
                string newvalue = DGVCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //show the output on the header
                string text = "Row :" + e.RowIndex.ToString() + " Col :" + e.ColumnIndex.ToString() + "Value =" + newvalue;
                //pass the data to the text boxes
                txtFirstname.Text = DGVCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSurname.Text = DGVCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = DGVCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = DGVCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDateJoined.Text = DGVCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
            catch { }
        }
        
        private void DGVRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //show the data in the DGV in the text boxes
                string newvalue = DGVRentals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //show the output on the header
                string text = "Row :" + e.RowIndex.ToString() + " Col :" + e.ColumnIndex.ToString() + "Value =" + newvalue;
                //pass the data to the text boxes
                txtRMID.Text = DGVRentals.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFirstname.Text = DGVRentals.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSurname.Text = DGVRentals.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = DGVRentals.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTitle.Text = DGVRentals.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtRental_cost.Text = DGVRentals.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDateRented.Text = DGVRentals.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCustID.Text = DGVRentals.Rows[e.RowIndex].Cells[7].Value.ToString();

            }
            catch { }
        }

      
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {  
           string newEntry = "INSERT INTO Customer (Firstname, Surname, Address, Phone, DateJoined) VALUES (@Firstname, @Surname, @Address, @Phone, @DateJoined)";
            // creates array from string input from text box
            string[] insertArr = { txtFirstname.Text, txtSurname.Text, txtAddress.Text, txtPhone.Text, txtDateJoined.Text };
            //calls my database
            myDatabase.InsertCust(insertArr);
            //loads database / refresh dgv
            LoadDB();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string DeleteCommand = "Delete Customer where ID = @ID";
            SqlCommand DeleteData = new SqlCommand(DeleteCommand, Connection);
            DeleteData.Parameters.AddWithValue("@ID", txtID.Text);
            Connection.Open();
            DeleteData.ExecuteNonQuery();
            Connection.Close();
            loaddb();
            //Run the LoadDatabase method we made earlier to see the new data.
            loaddb(); 
      
        }       

        private void btnAddmovie_Click(object sender, EventArgs e)
        {
            string newEntry = "INSERT INTO Movies (ID, Title, Genre, Year, Rating, Plot, Copies, Rental_cost, Date, Add) VALUES (ID, Title, Genre, Year, Rating, Plot, Copies, Rental_cost, Date, Add)";
            using (SqlCommand newData = new SqlCommand(newEntry, Connection))
            {
                newData.Parameters.AddWithValue("@ID", txtID.Text);
                newData.Parameters.AddWithValue("@Title", txtTitle.Text);
                newData.Parameters.AddWithValue("@Genre", txtGenre.Text);
                newData.Parameters.AddWithValue("@Year", txtYear.Text);
                newData.Parameters.AddWithValue("@Rating", txtRating.Text);
                newData.Parameters.AddWithValue("@Plot", txtPlot.Text);
                newData.Parameters.AddWithValue("@Copies", txtCopies.Text);
                newData.Parameters.AddWithValue("@Rental_cost", txtRental_cost.Text);
                newData.Parameters.AddWithValue("@Date", txtDate.Text);

                Connection.Open();//open the connection to the database
                //it's a nonquery
                newData.ExecuteNonQuery();
                Connection.Close();//Close the connection
                MessageBox.Show("Data has been Inserted!");

                //Run the loaddb method
                LoadDB();
            }
        }

        private void btnUpdateCustomer_Click_1(object sender, EventArgs e)
        {
            //this updates existing data in the database where the ID of the data equals the the text box
            string updatestatement = "UPDATE Customers SET Firstname=@Firstname, Surname=@Surname, Address=@Address, Phone=@Phone, dateJoined=@dateJoined";

            SqlCommand update = new SqlCommand(updatestatement, Connection);
            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
            update.Parameters.AddWithValue("@Surname", txtSurname.Text);
            update.Parameters.AddWithValue("@Address", txtAddress.Text);
            update.Parameters.AddWithValue("@Phone", txtPhone.Text);
            update.Parameters.AddWithValue("@DateJoined", txtDateJoined.Text);
            Connection.Open();
            //its NONQuery as data is only going up
            //Run the LoadDatabase method to see the new data
            //loadDB();
            Connection.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            Connection.Close();
            LoadDB();
        }

        private void btnRentMovie_Click(object sender, EventArgs e)
        {
            string newEntry = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) VALUES (@MovieIDFK, @CustIDFK, @DateRented)";

            DateTime today = DateTime.Today;

            using (SqlCommand newData = new SqlCommand(newEntry, Connection))
            {
                newData.Parameters.AddWithValue("@MovieIDFK", txtID.Text);
                newData.Parameters.AddWithValue("@CustIDFK", txtCustID.Text);
                newData.Parameters.AddWithValue("@DateRented", today);
                

                Connection.Open();//open the connection to the database
                //it's a nonquery
                newData.ExecuteNonQuery();
                Connection.Close();//Close the connection
                MessageBox.Show("Movie has been Rented!");

                //Run the loaddb method
                LoadDB();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //this updates existing data in the database where the ID of the data equals the the text box
            string updatestatement = "UPDATE RentedMovies SET DateReturned=@DateReturned WHERE RMID=@RMID";
            DateTime today = DateTime.Today;

            SqlCommand update = new SqlCommand(updatestatement, Connection);
            //create the parameters and pass the data from the textboxes
            update.Parameters.AddWithValue("@RMID", txtRMID.Text);

            update.Parameters.AddWithValue("@DateReturned", today );
            Connection.Open();
            //its NONQuery as data is only going up
            //Run the LoadDatabase method to see the new data
            //loadDB();
            Connection.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            Connection.Close();
            LoadDB();
        }

        
    }
} 
    
                   

            
                
                

           
            
