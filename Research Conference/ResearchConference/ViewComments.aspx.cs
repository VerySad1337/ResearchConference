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
    public partial class ViewComments : System.Web.UI.Page
    {

        class viewCommentController
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public string retrievePaperID(string sessionPaperID)
            {
                string currentSessionPaperID = sessionPaperID;
                viewCommentEntity myEntity = new viewCommentEntity();
                var x = myEntity.getPaperID(currentSessionPaperID);
                return x;
            }

            public SqlDataAdapter displayComment(string sessionPaperID)
            {
                string currentSessionPaperID = sessionPaperID;
                viewCommentEntity myEntity = new viewCommentEntity();
                return myEntity.displayComments(currentSessionPaperID);
            }

        }

        class viewCommentEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public string getPaperID(string sessionPaperID)
            {
                string currentSessionPaperID = sessionPaperID;
                dbConnection.Open();
                string queryResult2 = "Select Comments.PaperID from Comments where paperid = " + currentSessionPaperID;
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2, dbConnection);
                var x = displayPaperTitle.ExecuteScalar();
                if (x == null)
                {
                    return (string)displayPaperTitle.ExecuteScalar();
                }
                else
                {
                    return displayPaperTitle.ExecuteScalar().ToString();
                }
            }

            public SqlDataAdapter displayComments(string PaperID)
            {
                string currentSessionPaperID = PaperID;
                dbConnection.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT Comments.Userid, Comments.CommentID as CommentID ,Comments.Comments as Comments, Users.Name as Name from Comments inner join users on comments.userid = users.userid where Comments.PaperID =" + currentSessionPaperID, dbConnection);
                return sqlda;
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
                    string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                    viewCommentController controller = new viewCommentController();
                    controller.retrievePaperID(currentSessionPaperID);

                    string x = controller.retrievePaperID(currentSessionPaperID);
                    if (string.IsNullOrEmpty(x))
                    {
                        Label3.Text = "No comments as of now";
                    }
                    DataTable myDataTable = new DataTable();
                    controller.displayComment(currentSessionPaperID).Fill(myDataTable);
                    GridView2.DataSource = myDataTable;
                    GridView2.DataBind();

                }
                else
                {
                    Label3.Text = "Why are you here? You are not reviewer!";
                }
            }
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}