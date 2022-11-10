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
        class ConfirmationBidPaperController
        {
            public string addAllocation(string userid, string paperid)
            {
                string x = userid;
                string y = paperid;
                ConfirmationBidPaperEntity entity = new ConfirmationBidPaperEntity();
                string result = entity.setAllocation(x, y);
                return result;
            }
            public string displayPaper(string paperID)
            {
                string paper = paperID;
                ConfirmationBidPaperEntity myEntity = new ConfirmationBidPaperEntity();
                return myEntity.getPaperID(paper);
            }

        }

        class ConfirmationBidPaperEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public string setAllocation(string userid, string paperid)
            {
                string currentSessionUserID =userid;
                string currentPaperID = paperid;
                dbConnection.Open();
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
                        string myoutput = "Error1"; //Cannot bid for your own paper!
                        dbConnection.Close();
                        return myoutput;
                    }
                    else
                    {

                        if (currentreviewcount < ifExceed)
                        {
                            SqlCommand commands = dbConnection.CreateCommand();
                            commands.CommandType = CommandType.Text;
                            string currentSessionPaperID = currentPaperID;
                            commands.CommandText = "Insert into Allocation(PaperID,UserID ) values('" + currentSessionPaperID + "' , '" + currentSessionUserID + "')";
                            commands.ExecuteNonQuery();
                            string pass = "pass";
                            dbConnection.Close();
                            return pass;
                            
                        }
                        else
                        {
                            string output = "Error2"; //Exceed max limit
                            dbConnection.Close();
                            return output;
                        }
                    }
                }
                else
                {
                    string output = "Error3"; //AlreadySelectThis
                    dbConnection.Close();
                    return output;
                }
            }
            public string getPaperID(string paperID)
            {
                dbConnection.Open();
                string myPaper = paperID;
                SqlCommand sqlCommand = dbConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "Select papertitle from paper where paperid=" + paperID;
                sqlCommand.ExecuteNonQuery();
                var outputPaperTitle = sqlCommand.ExecuteScalar().ToString();

                if(outputPaperTitle == null)
                {
                    string myOutput = (string)sqlCommand.ExecuteScalar();
                    dbConnection.Close();
                    return myOutput;
                }
                else
                {
                    string myOutput = sqlCommand.ExecuteScalar().ToString();
                    dbConnection.Close();
                    return myOutput;
                }
            }

        }
            
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null)
            {
                Response.Redirect("Reviewerlogin.aspx");
            }
            if(Session["PaperIDFromRow"] != null)
            {
                if (int.Parse(Session["roleid"].ToString()) == 3)
                {
                    string currentPaperID = Session["PaperIDFromRow"].ToString();
                    ConfirmationBidPaperController controller = new ConfirmationBidPaperController();
                    string display = controller.displayPaper(currentPaperID);
                    Label3.Text = "Currently Bidding for : " + display;
                }
                else
                {
                    Label3.Text = "You know?! You shouldnt be here! How you get here?";
                }
            }
            else
            {
                Label3.Text = "Last warning! Use the proper workflow!";
                Button1.Visible = false;
                Button2.Visible = false;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["userid"].ToString();
            string currentPaperID = Session["PaperIDFromRow"].ToString();

            ConfirmationBidPaperController controller = new ConfirmationBidPaperController();
            string output = controller.addAllocation(currentSessionUserID,currentPaperID);
            if (output == "pass")
            {
                Response.Redirect("~/Successful.aspx");
            }
            else if (output == "Error1")
            {
                Label3.Text = "Cannot bid for your own paper";
                Button1.Visible = false;
            }

            else if (output == "Error2")
            {
                Label3.Text = "You have exceeded your max limit";
                Button1.Visible = false;
            }
            else if(output == "Error3")
            {
                Label3.Text = "You have already selected this";
                Button1.Visible = false;
            }
            else
            {
                Label3.Text = "Screwed up somewhere, you shoudlnt be here";
            }
        }
    }
}