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
    public partial class CurrentMaxReview : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["userid"] == null)
            {
                Response.Redirect("reviewerlogin.aspx");
            }
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
            string currentSessionUserID = Session["UserID"].ToString();
            string queryResult = "Select MaxReview from users where UserID = " + currentSessionUserID;
            SqlCommand displayResult = new SqlCommand(queryResult,dbConnection);
            dbConnection.Open();
            string checkForNull = displayResult.ExecuteScalar().ToString();
            if (checkForNull != "")
            {
                Label4.Text = displayResult.ExecuteScalar().ToString();
            }
            

            else if(checkForNull == "")
            {
                Label4.Text = "Not set yet!";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String currentSessionUserID = Session["UserID"].ToString();
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Users SET MaxReview = '"+TextBox1.Text+"' WHERE UserID = " + currentSessionUserID;
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";
        }

    }
}