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
    public partial class ViewReview : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        class viewReviewController
        {
            public SqlDataAdapter viewReviewTable(string getUserID)
            {
                SqlConnection dbConnections = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                dbConnections.Open();
                string currentSessionID = getUserID;             
                SqlDataAdapter SQLQuery = new SqlDataAdapter("SELECT Allocation.AllocationID, Allocation.PaperID,  Allocation.UserID,Users.Name, Allocation.GradeID, Paper.Date, Paper.PaperTitle, Paper.URL, Allocation.PaperID as session FROM (Allocation  INNER JOIN Paper ON Allocation.PaperID = Paper.PaperID) INNER JOIN USERS on Allocation.UserID = Users.UserID where Allocation.UserID = " + currentSessionID, dbConnections);
                dbConnections.Close();
                return SQLQuery;
            }

        }

        class viewReviewEntity
        {
            int userID;
            int paperID;

            public void getUserID(int userid)
            {
                userid = 0; 
            }

            public void getPaperID(int PaperID)
            {
                paperID = 0;
            }

        }
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
                    dbConnection.Open();
                    string myUserID = Session["UserID"].ToString();
                    viewReviewController createTable = new viewReviewController();
                    DataTable myDataTable = new DataTable();
                    using (dbConnection)
                    {
                        createTable.viewReviewTable(myUserID).Fill(myDataTable);
                        GridView2.DataSource = myDataTable;
                        GridView2.DataBind();
                        dbConnection.Close();
                    }
                }
                else
                {
                    Response.Write("Invalid User");
                    Label3.Visible = false;
                }
            }          

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ViewReviewFromDB_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void giveReview_Click(object sender, EventArgs e)
        {
            int PaperID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string PaperIDSession = PaperID.ToString();
            Session["PaperIDFromRow"] = PaperIDSession;
            Response.Redirect("AddReview.aspx");
        }
        protected void giveComments_Click(object sender, EventArgs e)
        {
            int PaperID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string PaperIDSession = PaperID.ToString();
            Session["PaperIDFromRow"] = PaperIDSession;
            Response.Redirect("AddComments.aspx");
        }
    }
}