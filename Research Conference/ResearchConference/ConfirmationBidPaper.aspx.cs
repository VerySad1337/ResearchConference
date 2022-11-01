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
    public partial class ConfirmationBidPaper : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null)
            {
                Response.Redirect("Reviewerlogin.aspx");
            }
            if(Session["PaperIDFromRow"] != null)
            {
                dbConnection.Open();
                string currentPaperID = Session["PaperIDFromRow"].ToString();
                SqlCommand myCommand = dbConnection.CreateCommand();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandText = "Select papertitle from paper where paperid=" + currentPaperID ;
                myCommand.ExecuteNonQuery();
                string outputPaperTitle = myCommand.ExecuteScalar().ToString();
                Label3.Text = "Currently Bidding for: " + outputPaperTitle;
            }
            else
            {
                Label3.Text = "No paper selected";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["userid"].ToString();
            string currentPaperID = Session["PaperIDFromRow"].ToString();

            SqlCommand myCommand = dbConnection.CreateCommand();
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = "Select * from allocation where paperid='" + currentPaperID + "' and userid = '" + currentSessionUserID + "'";
            myCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);

            if (dt.Rows.Count < 1)
            {
                DateTime time = DateTime.Now;
                SqlCommand command = dbConnection.CreateCommand();
                command.CommandType = CommandType.Text;
                string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                command.CommandText = "Insert into Allocation(PaperID,UserID ) values('" + currentSessionPaperID + "' , '" + currentSessionUserID + "')";
                command.ExecuteNonQuery();
                Response.Redirect("~/Successful.aspx");
            }
            else
            {
                Label3.Text = "You already have selected this";
            }

        }
    }
}