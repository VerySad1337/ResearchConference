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
        class addReviewController
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public void changeGrade(string dropDownText, string userID, string paperID)
            {
                string dropdown = dropDownText;
                string currentSessionUserID = userID;
                string paper = paperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                myEntity.setGrade(dropdown, currentSessionUserID, paper);

            }

            public string retrieveGrade(string sessionPaperID)
            {
                string currentSessionPaperID = sessionPaperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                var x = myEntity.getGrade(currentSessionPaperID);
                return x;
            }
            public string retrievePaperID(string sessionPaperID)
            {
                string currentSessionPaperID = sessionPaperID;
                AddReviewEntity myEntity = new AddReviewEntity();
                var x = myEntity.getPaperTitle(currentSessionPaperID);
                return x;
            }
        }
        class AddReviewEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public void setGrade(string dropDownText, string userID, string paperID)
            {
                string dropdown = dropDownText;
                string currentSessionUserID = userID;
                string paper = paperID;
                dbConnection.Open();
                SqlCommand command = dbConnection.CreateCommand();
                command.CommandType = CommandType.Text;
                string ratingDropDown = dropdown;
                string convertGradesToGradeIDQuery = "Select GradeID from Gradings where Grades =" + "'" + ratingDropDown + "'";
                SqlCommand convertGradesToGradeID = new SqlCommand(convertGradesToGradeIDQuery, dbConnection);
                string convertedGradeID = convertGradesToGradeID.ExecuteScalar().ToString();
                command.CommandText = "UPDATE Allocation SET GradeID = " + convertedGradeID + ",UserID = " + currentSessionUserID + " where paperid = " + paper;
                command.ExecuteNonQuery();
                dbConnection.Close();

            }

            public string getGrade(string PaperID)
            {
                string currentSessionPaperID = PaperID;
                dbConnection.Open();
                string queryResult = "Select Gradings.Grades from Allocation INNER JOIN Gradings ON Allocation.GradeID = Gradings.GradeID where Allocation.PaperID =" + currentSessionPaperID;
                SqlCommand displayGrade = new SqlCommand(queryResult, dbConnection);
                var outputDisplayGrade = displayGrade.ExecuteScalar();

                if(outputDisplayGrade == null)
                {
                    string x =  (string)displayGrade.ExecuteScalar();
                    dbConnection.Close();
                    return x;
                }
                else
                {
                    string y = displayGrade.ExecuteScalar().ToString();
                    dbConnection.Close();
                    return y;
                }

            }

            public string getPaperTitle(string PaperID)
            {
                string currentSessionPaperID = PaperID;
                dbConnection.Open();
                string queryResult2 = "Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID= " + currentSessionPaperID;
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2,dbConnection);
                var outputPaperTitle = displayPaperTitle.ExecuteScalar();

                if (outputPaperTitle == null)
                {
                    string x = (string)displayPaperTitle.ExecuteScalar();
                    dbConnection.Close();
                    return x;
                }
                else
                {
                    string y =  displayPaperTitle.ExecuteScalar().ToString();
                    dbConnection.Close();
                    return y;
                }

            }

        }
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("ReviewerLogin.aspx");
            }
            else
            {
                if (int.Parse(Session["roleid"].ToString()) == 3)
                {
                    if (Session["PaperIDFromRow"] != null)
                    {
                        string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                        addReviewController myController = new addReviewController();
                        string x = myController.retrievePaperID(currentSessionPaperID);

                        if (x == null)
                        {
                            Label5.Text = "Visit this page in the correct way";
                        }
                        else
                        {
                            Label5.Text = "Currently you are reviewing: " + x;
                            var z = myController.retrieveGrade(currentSessionPaperID);
                            if (string.IsNullOrEmpty(z))
                            {
                                Label6.Text = "You have not rate";
                            }

                            else
                            {
                                Label6.Text = "Your current rating is : " + z;
                            }
                        }
                    }
                    else
                    {
                        Label5.Text = "Visit this page in the proper way";
                        Label6.Visible = false;
                        Button1.Visible = false;
                        Label3.Visible = false;
                        DropDownList1.Visible = false;

                    }

                }
                else
                {
                    Label5.Text = "Shoo! Shoo ! Why are you here? You are not reviewer!";
                    Label6.Visible = false;
                    Button1.Visible = false;
                    Label3.Visible = false;
                    DropDownList1.Visible = false;
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentSessionUserID = Session["UserID"].ToString();
            string paperID = Session["PaperIDFromRow"].ToString();
            string ratingDropDown = DropDownList1.Text;

            addReviewController myController = new addReviewController();
            myController.changeGrade(ratingDropDown, currentSessionUserID, paperID);
            Response.Redirect("~/Successful.aspx");
        }

        protected void RatingDropDownlist_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}