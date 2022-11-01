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
        string dbConnection = @"Data Source=DESKTOP-0R2NCQ5;Initial Catalog = RCMS; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            {
                if (Session["PaperIDFromRow"] != null)
                {
                    using (SqlConnection sqlcon = new SqlConnection(dbConnection))
                    {
                        string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                        sqlcon.Open();
                        SqlDataAdapter sqlda = new SqlDataAdapter("SELECT Comments.Userid, Comments.CommentID as CommentID ,Comments.Comments as Comments, Users.Name as Name from Comments inner join users on comments.userid = users.userid where Comments.PaperID ="+ currentSessionPaperID , sqlcon);
                        DataTable dtbl = new DataTable();
                        sqlda.Fill(dtbl);
                        GridView2.DataSource = dtbl;
                        GridView2.DataBind();

                        string queryResult2 = "Select Comments.PaperID from Comments where paperid = " + currentSessionPaperID;
                        SqlCommand displayPaperTitle = new SqlCommand(queryResult2, sqlcon);
                        string checkForNull = displayPaperTitle.ExecuteScalar().ToString();
                        if (string.IsNullOrEmpty(checkForNull))
                        {
                            Label3.Text = "No comments as of now!";
                        }
                    }
                }
                else
                {
                    Label3.Text = "Please view the comments the proper way";
                }
            }
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}