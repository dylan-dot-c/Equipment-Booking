using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Equipment_Booking
{
    public partial class Dashboard : Page
    {
        private String connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }else
            {
                GetUserInfo();
                GetBookings();
            }
        }

        protected void GetUserInfo()
        {
            int id = Convert.ToInt32(Session["Id"]);

            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM [Table] WHERE officer_id = @ID";

                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    string f_name = reader["first_name"].ToString(), l_name = reader["last_name"].ToString(), imageURL = reader["imageURL"].ToString();

                    lblName.Text = $"{f_name} {l_name}";
                    imgProfile.ImageUrl = imageURL;
                }else
                {
                    lblName.Text = "NO DATA FOR YOU";
                }

                conn.Close();
                reader.Close();
            }
        }

        protected void GetBookings()
        {
            int id = Convert.ToInt32(Session["Id"]);

            string query = "SELECT equipment_id, booking_id, start_date, end_date, rate, status FROM bookings WHERE officer_id = @ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand (query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }

            }catch (Exception ex)
            {
                lblName.Text = ex.Message;
            }

        }


    }
}