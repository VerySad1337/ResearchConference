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
        class addCommentsController
        {
            SqlConnection dbConnections = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public string displayCurrentPaperTitle(string currentSessionPaperID)
            {
                dbConnections.Open();
                addCommentEntity displayCurrentPaperTitle = new addCommentEntity();
                string sessionPaperID = currentSessionPaperID;
                dbConnections.Close();
                return displayCurrentPaperTitle.getPaperTitle(sessionPaperID);
            }

            public void storeComments(string comments, string currentSessionPaperID, string currentSessionUserID)
            {
                string PaperID = currentSessionPaperID;
                string inputComments = comments;
                string UserID = currentSessionUserID;
                addCommentEntity addNewComment = new addCommentEntity();
                addNewComment.setComments(inputComments, PaperID, UserID);
            }


        }

        class addCommentEntity
        {
            SqlConnection dbConnections = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public string getPaperTitle(string getPaperID)
            {
                dbConnections.Open();
                string currentPaperSessionID = getPaperID;
                addCommentEntity myEntity = new addCommentEntity(); //Dont Make any sense if u mark, but you require BCE!.             
                SqlCommand SQLQuery = new SqlCommand("Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID = " + currentPaperSessionID, dbConnections);
                string myResult = SQLQuery.ExecuteScalar().ToString();
                dbConnections.Close();
                return myResult;
            }

            public void setComments(string comments, string currentSessionPaperID, string currentSessionUserID)
            {
                dbConnections.Open();
                string PaperID = currentSessionPaperID;
                string inputComments = comments;
                string UserID = currentSessionUserID;
                DateTime currentTime = DateTime.Now;
                SqlCommand insertCommand = dbConnections.CreateCommand();
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "Insert into Comments(Comments,PaperID,CreatedDate,UserID ) values('" + inputComments + "' , '" + PaperID + "', '" + currentTime + "', '" + UserID + "')";
                insertCommand.ExecuteNonQuery();
                dbConnections.Close();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Reviewerlogin.aspx");
            }

            else
            {
                if (int.Parse(Session["roleid"].ToString()) == 3)
                {
                    string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                    addCommentsController myController = new addCommentsController();
                    if (currentSessionPaperID != null)
                    {
                        Label3.Text = "Currently giving comments for: " + myController.displayCurrentPaperTitle(currentSessionPaperID);

                    }
                    else
                    {
                        Label3.Text = "Enter the proper way!";
                        TextBox1.Visible = false;
                        onSubmit.Visible = false;
                        HyperLink1.Visible = false;
                    }
                    dbConnection.Close();
                }
                else
                {
                    Label3.Text = "Why are you here? You are now reviewer!";
                    TextBox1.Visible = false;
                    onSubmit.Visible = false;
                    HyperLink1.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string comments = TextBox1.Text.Trim();
            string currentPaperID = Session["PaperIDFromRow"].ToString();
            string currentSessionUserID = Session["userid"].ToString();
            addCommentsController addNewComments = new addCommentsController();
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                HyperLink1.Text = "Enter some comments!";
            }
            else
            {
                addNewComments.storeComments(comments, currentPaperID, currentSessionUserID);
                Response.Redirect("~/Successful.aspx");

            }


        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }

}