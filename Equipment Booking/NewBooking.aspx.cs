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
    public partial class NewBooking : Page
    {

        private string connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }else
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                Get_Info(id);
            }

        }

        protected void Get_Info(int id)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = $"SELECT * FROM equipments WHERE equipment_id = {id}";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        txtName.Text = reader["equipment_name"].ToString();
                        txtName.Enabled = false;
                    }else
                    {
                        lblError.Text = "Error getting info";
                    }
                }
            }catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string equipmentName = txtName.Text;
            decimal rate = Convert.ToDecimal(txtRate.Text);
            string firstName = txtFName.Text;
            string lastName = txtLName.Text;
            string email = txtEmail.Text;
            string trn = txttrn.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string passportPhoto = txtPhoto.Text;
            string phoneNumber = txtPhone.Text;
            DateTime startDate = Convert.ToDateTime(dateStart.Text);
            DateTime returnDate = Convert.ToDateTime(dateEnd.Text);

            int officerId = Convert.ToInt32(Session["Id"]);
            int equipmentId = Convert.ToInt32(Request.Params["id"]);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    string addressQuery = "INSERT INTO address (address_line1, address_line2) VALUES (@AL1, @AL2); SELECT SCOPE_IDENTITY();";
                    string clientQuery = "INSERT INTO clients (first_name, last_name, email, photo_url, trn, phone_number, address_id) VALUES (@FN, @LN, @EMAIL, @photo_url, @TRN, @phone, @AID); SELECT SCOPE_IDENTITY();";
                    string bookingQuery = "INSERT INTO bookings (officer_id, client_id, equipment_id, start_date, end_date, rate, status) VALUES (@OID, @CID, @EID, @SD, @ED, @rate, 'Pending')";
                    string updateEquipmentQuery = "UPDATE equipments SET is_available = 0 WHERE equipment_id = @EID";

                    using (SqlCommand cmd = new SqlCommand(addressQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@AL1", address1);
                        cmd.Parameters.AddWithValue("@AL2", address2);
                        int addressId = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = clientQuery;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@FN", firstName);
                        cmd.Parameters.AddWithValue("@LN", lastName);
                        cmd.Parameters.AddWithValue("@EMAIL", email);
                        cmd.Parameters.AddWithValue("@photo_url", passportPhoto);
                        cmd.Parameters.AddWithValue("@TRN", trn);
                        cmd.Parameters.AddWithValue("@phone", phoneNumber);
                        cmd.Parameters.AddWithValue("@AID", addressId);
                        int clientId = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = bookingQuery;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@OID", officerId); // Replace with appropriate officer ID
                        cmd.Parameters.AddWithValue("@CID", clientId);
                        cmd.Parameters.AddWithValue("@EID", equipmentId); // Replace with appropriate equipment ID
                        cmd.Parameters.AddWithValue("@SD", startDate);
                        cmd.Parameters.AddWithValue("@ED", returnDate);
                        cmd.Parameters.AddWithValue("@rate", rate);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = updateEquipmentQuery;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@EID", equipmentId); // Replace with appropriate equipment ID
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }

                    lblError.Text = "Booking created Successfully";
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    lblError.Text = ex.Message;
                    lblError.ForeColor = System.Drawing.Color.Red;

                }
            }
        }


    }
}