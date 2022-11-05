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
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        class ViewCommentController
        {
            public SqlDataAdapter displayComments (string getPaperID)
            {
                SqlConnection dbConnections = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                dbConnections.Open();
                string currentSessionID = getPaperID;
                viewCommentEntity myEntity = new viewCommentEntity(); //Dont Make any sense if u mark, but you require BCE!.
                string iDontUnderstandWhy = myEntity.getPaperID(currentSessionID); //Dont make sense with BCE, slowing down the operation!               
                SqlDataAdapter SQLQuery = new SqlDataAdapter("SELECT Comments.Userid, Comments.CommentID as CommentID ,Comments.Comments as Comments, Users.Name as Name from Comments inner join users on comments.userid = users.userid where Comments.PaperID =" +iDontUnderstandWhy, dbConnections);
                dbConnections.Close();
                return SQLQuery;
            }
        }
        class viewCommentEntity
        {

            public string getPaperID(string fromControllerGetPaperID)
            {
                string currentPaperID = fromControllerGetPaperID;
                return currentPaperID;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            {

                if (Session["UserID"] == null)
                {
                    Response.Redirect("ReviewerLogin.aspx");
                }
                else
                {
                    if (int.Parse(Session["roleid"].ToString()) == 3)
                    {
                        dbConnection.Open();
                        string myUserID = Session["UserID"].ToString();
                        ViewCommentController createTable = new ViewCommentController();
                        string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                        DataTable myDataTable = new DataTable();
                        DataTable myDataTable1 = new DataTable();
                        using (dbConnection)
                        {

                            createTable.displayComments(currentSessionPaperID).Fill(myDataTable);
                            GridView2.DataSource = myDataTable;
                            GridView2.DataBind();
                            if(myDataTable.Rows.Count == 0)
                            {
                                Label3.Text = "No comments as of now";
                            }
                            dbConnection.Close();
                        }
                    }
                    else
                    {
                        Label3.Text = "Why are you here? You are not reviewer!";
                    }
                }              
            }
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}