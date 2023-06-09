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
    public partial class AddEquipments : Page
    {

        private string connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void AddEquipment(string name, string type, int price)
        {
            try
            {
                using(SqlConnection conn =  new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "INSERT INTO equipments (equipment_name, price, type) VALUES (@NAME, @PRICE, @TYPE)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@PRICE", price);
                    cmd.Parameters.AddWithValue("@TYPE", type);

                    int rows = cmd.ExecuteNonQuery();

                    if(rows > 0)
                    {
                        lblError.Text = "New Equipment Added";
                        Response.Redirect("~/Equipments.aspx");
                    }else
                    {
                        lblError.Text = "Error Adding to Database";
                    }
                }


            }catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string type = txtType.Text;
            int price = Convert.ToInt32(txtCost.Text);

            AddEquipment(name, type, price);
        }
    }
}