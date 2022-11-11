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
        class CurrentMaxReviewController
        {
            string UID;
            
            public void setID(string userid)
            {
                UID = userid;
            }
            public string getID()
            {
                return UID;
            }

            public string displayMaxReview(string userid)
            {
                CurrentMaxReviewEntity entity = new CurrentMaxReviewEntity();
                string result = entity.GetMaxReview(userid);
                return result;
            }

            public void setMaxReview(String userid, string Maxreview)
            {
                CurrentMaxReviewEntity entity = new CurrentMaxReviewEntity();
                entity.setMax(userid, Maxreview);
            }
        }

        class CurrentMaxReviewEntity
        {
            SqlConnection dbConnectionE = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public string GetMaxReview(string userid)
            {
                string queryResult = "Select MaxReview from users where UserID = " + userid;

                SqlCommand displayResult = new SqlCommand(queryResult, dbConnectionE);
                dbConnectionE.Open();
                string checkForNull = displayResult.ExecuteScalar().ToString();
                dbConnectionE.Close();
                return checkForNull;
            }

            public void setMax(String userid, string Maxreview)
            {
                dbConnectionE.Open();
                SqlCommand command = dbConnectionE.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Users SET MaxReview = '" + Maxreview + "' WHERE UserID = '" + userid + "'";
                command.ExecuteNonQuery();
                dbConnectionE.Open();
            }

        }

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
                        
            CurrentMaxReviewController controller = new CurrentMaxReviewController();
            controller.setID(Session["UserID"].ToString());
            string display = controller.displayMaxReview(controller.getID());

            if (display != "")
            {
                Label4.Text = display;
            }


            else if (display == "")
            {
                Label4.Text = "Not set yet!";
            }

            /*string currentSessionUserID = Session["UserID"].ToString();
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
            }*/

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CurrentMaxReviewController controller = new CurrentMaxReviewController();
            controller.setID(Session["UserID"].ToString());
            controller.setMaxReview(controller.getID(), TextBox1.Text);
            
            Response.Redirect("~/Successful.aspx");


            /*String currentSessionUserID = Session["UserID"].ToString();
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Users SET MaxReview = '"+TextBox1.Text+"' WHERE UserID = " + currentSessionUserID;
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";*/
        }

    }
}