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
                SqlCommand myQuery = dbConnection.CreateCommand();
                myQuery.CommandType = CommandType.Text;
                myQuery.CommandText = "Select maxreview from users where userid=" + currentSessionUserID;
                myQuery.ExecuteNonQuery();
                int checkMaxReviewExceed = int.Parse(myQuery.ExecuteScalar().ToString());

                SqlCommand myQuery2 = dbConnection.CreateCommand();
                myQuery2.CommandType = CommandType.Text;
                myQuery2.CommandText = "Select count(*) from allocation where GradeID IS NULL and userid=" + currentSessionUserID;
                myQuery2.ExecuteNonQuery();
                int ifExceed = int.Parse(myQuery.ExecuteScalar().ToString());
                int currentreviewcount = int.Parse(myQuery2.ExecuteScalar().ToString());

                SqlCommand myQuery3 = dbConnection.CreateCommand();
                myQuery3.CommandType = CommandType.Text;
                myQuery3.CommandText = "Select UserIDPosted from paper where paperid=" + currentPaperID;
                myQuery3.ExecuteNonQuery();
                int checkForMyOwnPaper = int.Parse(myQuery3.ExecuteScalar().ToString());


                int convertToIntForCurrentUserID = int.Parse(currentSessionUserID);

                if (convertToIntForCurrentUserID == checkForMyOwnPaper)
                {
                    Label3.Text = "You cant bid on your own paper";
                }
                else
                {

                    if (currentreviewcount < ifExceed)
                    {
                        SqlCommand commands = dbConnection.CreateCommand();
                        commands.CommandType = CommandType.Text;
                        string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                        commands.CommandText = "Insert into Allocation(PaperID,UserID ) values('" + currentSessionPaperID + "' , '" + currentSessionUserID + "')";
                        commands.ExecuteNonQuery();
                        Response.Redirect("~/Successful.aspx");
                    }
                    else
                    {
                        Label3.Text = "Exceeded your max limit";
                    }
                }
            }
            else
            {
                Label3.Text = "You already have selected this";
            }

        }
    }
}