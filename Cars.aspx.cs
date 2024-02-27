using RideYouRent.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RideYouRent
{
    public partial class Cars : System.Web.UI.Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            //Telling the gridView there is no data source for it
            GridView1.DataSource = null;
            //linking the null source to the gridview (won't display)
            GridView1.DataBind();

            CarIdTextBox2.Text = "";
            CarNoTextBox2.Text = "";
            kilometersTravelledTextBox2.Text = "";
            kilometerServicedTextBox2.Text = "";
            availabilityDropDownList2.Text = "";
            Label19.Text = "";
        }

        DBHelper helper = new DBHelper();
        protected void AddCarButton_Click(object sender, EventArgs e)
        {
            Validations validations = new Validations();
            Car car = new Car();
           
            List<Car> cars = helper.CarsFromDatabase();
            string carId = CarIdTextBox1.Text;
            string carNo = CarNoTextBox1.Text;
            int bodyTypeId = BodyTypeDropDownList1.SelectedIndex+1;
            int make_Id =  MakeDropDownList1.SelectedIndex + 1;
            int model_Id = ModelDropDownList1.SelectedIndex + 1;
            string kilometersTravelled = KilometersTavelledTextBox1.Text;
            string kilometersServiced = kilometersServicedTextBox1.Text;
            string availability = availabilityDropDownList1.Text;

            car.CarNo = carNo;
            if (CarIdTextBox1.Text == "" || CarNoTextBox1.Text == "" || KilometersTavelledTextBox1.Text == "" ||kilometersServicedTextBox1.Text == "")
            {
                Label19.Text = "All data fields must be entered";
            }
            else if (int.Parse(CarIdTextBox1.Text) <= cars.Count) 
            {
                Label19.Text = "Invalid carId entered";   
            }else if (Validations.ValidateString(carNo) ==false )
            {
                Label19.Text = "carNo Must be a string ";
            }
            else if (cars.Contains(car) ) 
            {
                Label19.Text = "CarNo already exists";
            }
            else if (Validations.ValidateString(KilometersTavelledTextBox1.Text) == true)
            {
                Label19.Text = "kilomters travelled must be an integar";
            }
            else if (Validations.ValidateString(kilometersServicedTextBox1.Text))
            {
                Label19.Text = "kilomters serviced must be an integar";
            }
            else
            {
                string adding_CarData = "insert into car(carId,carNo,bodyType_Id,make_Id,model_Id,availabilitys,kilometersTravelled,kilometersServiced) values (@carId,@carNo,@bodyType_Id,@Make_Id,@model_Id,@availabilitys,@kilometersTravelled,@kilometersServiced)";
                using (SqlConnection connectDatabase = new SqlConnection(dbConnection))
                {
                    connectDatabase.Open();
                    SqlCommand command3 = new SqlCommand(adding_CarData, connectDatabase);
                    command3.Parameters.AddWithValue("@carId", carId);
                    command3.Parameters.AddWithValue("@carNo", carNo);
                    command3.Parameters.AddWithValue("@bodyType_Id", bodyTypeId);
                    command3.Parameters.AddWithValue("@make_Id", make_Id);
                    command3.Parameters.AddWithValue("@model_Id", model_Id);
                    command3.Parameters.AddWithValue("@availabilitys", availability);
                    command3.Parameters.AddWithValue("@kilometersTravelled", kilometersTravelled);
                    command3.Parameters.AddWithValue("@kilometersServiced", kilometersServiced);

                    command3.ExecuteNonQuery();
                    connectDatabase.Close();
                }
            }
        }
        //check if works
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            List<Car> cars = helper.CarsFromDatabase();
            if (CarIdTextBox2.Text == "")
            {
                Label19.Text = "Please select from table first!";
            }else if (int.Parse(CarIdTextBox2.Text) > cars.Count || int.Parse(CarIdTextBox2.Text) < 0) 
            {
                Label19.Text = "Invalid carId !";
            }
            else
            {
                string query = "DELETE FROM car WHERE carId = @CarId";
                using (SqlConnection connectDatabase = new SqlConnection(dbConnection))
                {
                    SqlCommand delete = new SqlCommand(query, connectDatabase);
                    delete.Parameters.AddWithValue("@CarId", CarIdTextBox2.Text);
                    connectDatabase.Open();
                    delete.ExecuteNonQuery();
                    connectDatabase.Close();
                }
            }
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            //Getting  car table data from the database using the helper class
            List<Car> cars = helper.CarsFromDatabase();
            //Telling the gridView where it must get data from
            GridView1.DataSource = cars;
            //Links the gridView to the data source
            GridView1.DataBind();
        }
       
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getting selected data from table
            CarIdTextBox2.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            CarNoTextBox2.Text = GridView1.SelectedRow.Cells[2].Text.ToString();  
            MakeDropDownList2.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            ModelDropDownList2.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            BodyTypeDropDownList2.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
            kilometersTravelledTextBox2.Text = GridView1.SelectedRow.Cells[6].Text.ToString();
            kilometerServicedTextBox2.Text = GridView1.SelectedRow.Cells[7].Text.ToString();
            availabilityDropDownList2.Text = GridView1.SelectedRow.Cells[8].Text.ToString();

           
        }

        protected void SaveCarButton_Click(object sender, EventArgs e)
        {
            List<Car> cars = helper.CarsFromDatabase();
            Car car2 = new Car();
            car2.CarNo = CarNoTextBox2.Text;
            if (CarIdTextBox2.Text == "" || CarNoTextBox2.Text == ""||kilometersTravelledTextBox2.Text==""||kilometerServicedTextBox2.Text=="") 
            {
                Label19.Text = "All data fields must be entered";
            }
            else if (Validations.ValidateString(CarIdTextBox2.Text) == true)
            {
                Label19.Text = "carId  must be string";
            }
            else if (Validations.ValidateString(CarNoTextBox2.Text) == false)
            {
                Label19.Text = "carNo Must be a string ";
            }
            else if (cars.Contains(car2))
            {
                Label19.Text = "CarNo already exists";
            }
            else if (Validations.ValidateString(kilometersTravelledTextBox2.Text) == true)
            {
                Label19.Text = "kilometers travelled must be an integar";
            }
            else if (Validations.ValidateString(kilometerServicedTextBox2.Text))
            {
                Label19.Text = "kilometers serviced must be an integar";
            }
            else
            {
                SqlConnection connectDatabase = new SqlConnection(dbConnection);
                //SQL code that adds a new record to carBodyTable
                string query = "update car set carNo = @carNo, make_Id = @make_Id,bodyType_Id = @bodyType_Id,model_Id = @model_Id, availabilitys = @availabilitys, kilometersTravelled = @kilometersTravelled, kilometersServiced = @kilometersServiced WHERE carId = @carId";

                using (SqlCommand updateCar = new SqlCommand(query, connectDatabase))
                {

                    updateCar.Parameters.AddWithValue("@carNo", CarNoTextBox2.Text);

                    updateCar.Parameters.AddWithValue("@bodyType_Id", BodyTypeDropDownList2.SelectedIndex + 1);
                    updateCar.Parameters.AddWithValue("@make_Id", MakeDropDownList2.SelectedIndex + 1);//0
                    updateCar.Parameters.AddWithValue("@model_Id", ModelDropDownList2.SelectedIndex + 1);

                    updateCar.Parameters.AddWithValue("@availabilitys", availabilityDropDownList2.Text);
                    updateCar.Parameters.AddWithValue("@kilometersTravelled", kilometersTravelledTextBox2.Text);
                    updateCar.Parameters.AddWithValue("@kilometersServiced", kilometerServicedTextBox2.Text);
                    updateCar.Parameters.AddWithValue("@carId", CarIdTextBox2.Text);

                    //Establishes connection to database
                    connectDatabase.Open();
                    //Storing the command that we will run
                    updateCar.ExecuteNonQuery();
                }
                connectDatabase.Close();
            }
           
        }
    }
}