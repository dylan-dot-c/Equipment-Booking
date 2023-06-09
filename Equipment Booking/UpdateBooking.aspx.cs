using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Equipment_Booking
{
    public partial class UpdateBooking : Page
    {
        private readonly String connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            
            if(!IsPostBack)
            {
                GetInfo(id);
            }
        }

        protected void GetInfo(int id)
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM bookings WHERE booking_id = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ddlOptions.SelectedValue = reader["status"].ToString();
                    txtEID.Text = reader["equipment_id"].ToString();
                }
            }
        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlOptions.SelectedValue.ToString();

            if(value == "Returned")
            {
                txtReturnDate.Enabled = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string value = ddlOptions.SelectedValue.ToString();
            int id = Convert.ToInt32(Request.Params["id"]);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string updateQuery = "UPDATE bookings SET status = @STATUS WHERE booking_id = @ID";
                    string updateIsAvailableQuery = "UPDATE equipments SET is_available = 1 WHERE equipment_id = (SELECT equipment_id FROM bookings WHERE booking_id = @ID)";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@ID", id);
                    updateCmd.Parameters.AddWithValue("@STATUS", value);

                    SqlCommand updateIsAvailableCmd = new SqlCommand(updateIsAvailableQuery, conn);
                    updateIsAvailableCmd.Parameters.AddWithValue("@ID", id);

                    int updateAffected = updateCmd.ExecuteNonQuery();

                    if (updateAffected > 0)
                    {
                        if(ddlOptions.SelectedValue == "Returned")
                        {
                            int updateIsAvailableAffected = updateIsAvailableCmd.ExecuteNonQuery();

                            if(updateIsAvailableAffected > 0)
                            {
                                lblInfo.Text = $"Both tables got updates {updateAffected} {updateIsAvailableAffected}";
                            }


                        }else
                        {
                            lblInfo.Text = $"Only status has been updated {updateAffected}";
                        }
                    }
                    

                   
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

    }
}