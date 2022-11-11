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
    public partial class MassAddComment : System.Web.UI.Page
    {
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
            for (int i = 0; i < 100; i++)
            {
                string j = i.ToString();
                string firedword = "My fired script" + j;
                addCommentsController myController = new addCommentsController();
                myController.storeComments(firedword, 3.ToString(), 3.ToString());

            }

        }
    }
}