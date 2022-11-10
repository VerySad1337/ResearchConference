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

        class AddReviewController
        {
            public void insertGrade(string userID, string theRating, string paperID)
            {
                string myID = userID;
                string myRating = theRating;
                string myPaper = paperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                myEntity.setReview(myID, myRating, myPaper);
            }
            public string displayGrades(string paperID)
            {
                string currentSessionPaperID = paperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                return myEntity.getGrades(currentSessionPaperID);
            }

            public string displayPaperTitle(string paperID)
            {
                string currentSessionPaperID = paperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                return myEntity.getPaperTitle(currentSessionPaperID);
            }
        }

        class AddReviewEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public void setReview(string userID,string theRating, string paperID)
            {
                dbConnection.Open();
                string currentSessionUserID = userID;
                string rating = theRating;
                string paper = paperID;
                SqlCommand command = dbConnection.CreateCommand();
                command.CommandType = CommandType.Text;
                string convertGradesToGradeIDQuery = "Select GradeID from Gradings where Grades =" + "'" + rating + "'";
                SqlCommand convertGradesToGradeID = new SqlCommand(convertGradesToGradeIDQuery, dbConnection);
                string convertedGradeID = convertGradesToGradeID.ExecuteScalar().ToString();
                command.CommandText = "UPDATE Allocation SET GradeID = " + convertedGradeID + ",UserID = " + currentSessionUserID + " where paperid = " + paper;
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
            public string getGrades(string paperID)
            {
                string currentSessionPaperID = paperID;
                dbConnection.Open();
                string queryResult = "Select Gradings.Grades from Allocation INNER JOIN Gradings ON Allocation.GradeID = Gradings.GradeID where Allocation.PaperID =" + currentSessionPaperID;
                SqlCommand displayResult = new SqlCommand(queryResult, dbConnection);
                var myGrades = displayResult.ExecuteScalar();
                if(myGrades == null)
                {
                    var emptyGrade = (string )displayResult.ExecuteScalar();
                    dbConnection.Close();
                    return emptyGrade;
                }
                else
                {
                    var haveGrade = displayResult.ExecuteScalar().ToString();
                    dbConnection.Close();
                    return haveGrade;
                }
            }

            public string getPaperTitle(string paperID)
            {
                string currentSessionPaperID = paperID;
                dbConnection.Open();
                string queryResult2 = "Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID= " + currentSessionPaperID;
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2, dbConnection);
                var myTitle = displayPaperTitle.ExecuteScalar();
                if(myTitle == null)
                {
                    string finalOutput = (string)displayPaperTitle.ExecuteScalar();
                    dbConnection.Close();
                    return finalOutput;
                }
                else
                {
                    string finalOutput = displayPaperTitle.ExecuteScalar().ToString();
                    dbConnection.Close();
                    return finalOutput;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userid"] == null)
            {
                Response.Redirect("reviewlogin.aspx");
            }
            if (int.Parse(Session["roleid"].ToString()) == 3)
            {
                if (Session["PaperIDFromRow"] != null)
                {
                    string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                    AddReviewController controller = new AddReviewController();
                    var myGrade = controller.displayGrades(currentSessionPaperID);
                    if (myGrade == null)
                    {
                        Label6.Text = "No rating given as of now!";
                    }
                    else
                    {
                        Label6.Text = "Your current grading for this paper is : " + myGrade;
                    }
                    var thePaper = controller.displayPaperTitle(currentSessionPaperID);
                    Label5.Text = "You are currently reviewing: " + thePaper;
                }
                else
                {
                    Label5.Text = "Visit this page through the proper workflow";
                    Label6.Visible = false;
                    DropDownList1.Visible = false;
                    Button1.Visible = false;
                    Label3.Visible = false;
                }
            }
            else
            {
                Label5.Text = "Shoo ! Shoo! You are not reviewer!";
                Label6.Visible = false;
                DropDownList1.Visible = false;
                Button1.Visible = false;
                Label3.Visible = false;

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["UserID"].ToString();
            string paperID = Session["PaperIDFromRow"].ToString();
            string myDropDown = DropDownList1.Text;
            AddReviewEntity myEntity = new AddReviewEntity();
            myEntity.setReview(currentSessionUserID,myDropDown,paperID);
            Response.Redirect("~/Successful.aspx"); 
        }

        protected void RatingDropDownlist_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}