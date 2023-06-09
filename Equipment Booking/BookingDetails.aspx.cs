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
    public partial class BookingDetails : Page
    {
        private readonly String connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.Params["id"]);
            GetBookingInfo(id);

        }

        protected void GetBookingInfo(int id)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT clients.first_name, clients.last_name, clients.email, equipments.equipment_name, equipments.type, bookings.start_date, bookings.end_date FROM bookings INNER JOIN equipments ON equipments.equipment_id = bookings.equipment_id INNER JOIN clients ON clients.client_id = bookings.client_id WHERE booking_id = @ID";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}