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
    public partial class AddComments : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Reviewlogin.aspx");
            }
 
            if (Session["PaperIDFromRow"] != null)
            {
                string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                string queryResult2 = "Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID= " + currentSessionPaperID;
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2, dbConnection);
                dbConnection.Open();
                string outputPaperTitle = displayPaperTitle.ExecuteScalar().ToString();
                Label3.Text = "Currently giving comments for: "+ outputPaperTitle;                
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                dbConnection.Open();
            }
            else
            {
                Label3.Text = "Nothing assigned for you";
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["userid"].ToString();
            DateTime time = DateTime.Now;
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
            command.CommandText = "Insert into Comments(Comments,PaperID,CreatedDate,UserID ) values('"+TextBox1.Text+"' , '"+currentSessionPaperID+"', '"+time+"', '"+currentSessionUserID+"')";
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }

}