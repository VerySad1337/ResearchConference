using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ResearchConference
{
    public partial class PublishPaper : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
            dbConnection.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Paper(PaperTitle,URL, Date) values('" + TextBox1.Text + "', '"+TextBox2.Text+"' , '"+time+"')";
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}