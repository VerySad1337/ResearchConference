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
    public partial class AddReview : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userid"] == null)
            {
                Response.Redirect("reviewlogin.aspx");
            }

            if (Session["PaperIDFromRow"] != null)
            {
                string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                string queryResult2 = "Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID= " + currentSessionPaperID;
                string queryResult = "Select Gradings.Grades from Allocation INNER JOIN Gradings ON Allocation.GradeID = Gradings.GradeID where Allocation.PaperID =" +  currentSessionPaperID;
                SqlCommand displayResult = new SqlCommand(queryResult, dbConnection);
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2, dbConnection);
                dbConnection.Open();
                string checkForNull = (string)displayResult.ExecuteScalar();
                string outputPaperTitle = displayPaperTitle.ExecuteScalar().ToString();
                if (string.IsNullOrEmpty(checkForNull))
                {
                    Label6.Text = "No rating given as of now!";
                }
                else 
                {
                    Label6.Text = "Your current rating for this paper for " + (string)displayResult.ExecuteScalar();
                }
                Label5.Text = "Currently you are reviewing: " + displayPaperTitle.ExecuteScalar().ToString();
                //Label5.Text = Session["PaperIDFromRow"].ToString();

            }
            else
            {
                Label5.Text = "Not Found";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["UserID"].ToString();
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            string ratingDropDown = DropDownList1.Text;
            string convertGradesToGradeIDQuery = "Select GradeID from Gradings where Grades =" + "'"+ratingDropDown+"'";
            SqlCommand convertGradesToGradeID = new SqlCommand(convertGradesToGradeIDQuery, dbConnection);
            string convertedGradeID = convertGradesToGradeID.ExecuteScalar().ToString();
            command.CommandText = "UPDATE Allocation SET GradeID = " + convertedGradeID + ",UserID = "+currentSessionUserID+" where paperid = " + Session["PaperIDFromRow"].ToString();
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");
        }

        protected void RatingDropDownlist_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}