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
    public partial class Login : Page
    {
        private String connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("~/Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM login INNER JOIN [Table] ON [Table].login_id = login.login_id WHERE login.username = @username AND login.password = @password";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Session["Username"] = reader["username"];
                        Session["Id"] = reader["officer_id"];
                        Response.Redirect("~/Dashboard.aspx");
                    }
                    else
                    {
                        lblError.Text = "Invalid Credintials";
                    }
                }catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }

            }
        }
    }
}