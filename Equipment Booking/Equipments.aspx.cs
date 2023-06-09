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
    public partial class Equipments : Page
    {
        private String connString = WebConfigurationManager.ConnectionStrings["EquipmentDB"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }else
            {
                Get_Equipments();
            }

           

        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int equipmentId = Convert.ToInt32(e.CommandArgument);

                // Call a method to delete the equipment based on the equipmentId
                Boolean result = DeleteEquipment(equipmentId);

                if (result)
                {
                    ShowAlert($"Item has been deleted");
                }

                // Perform any necessary actions after deletion
                // For example, you can rebind the GridView to reflect the updated data
                Get_Equipments();
            }
        }

        protected Boolean DeleteEquipment(int equip_id)
        {
            Boolean result = false;
            try
            {
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "DELETE FROM equipments WHERE equipment_id = @EID";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EID", equip_id);

                    int affected = cmd.ExecuteNonQuery();

                    if(affected > 0)
                    {
                        
                        result= true;
                    }else
                    {
                        ShowAlert($"No rows has been deleted");
                    }
                }
            }catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
           

            return result;
        }

        protected void Get_Equipments()
        {
            //function to get all equipments and load into grid view

            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM equipments WHERE is_available = 1 ";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader= cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }else
                {
                    lblInfo.Text = "No equipents found.";
                }

                conn.Close();
                reader.Close();


            }
        }

        private void ShowAlert(string message)
        {
            string script = $"<script>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddEquipments.aspx");
        }
    }
}