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
        //SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        string dbConnection = @"Data Source=DESKTOP-0R2NCQ5;Initial Catalog = RCMS; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(dbConnection))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT Allocation.AllocationID, Allocation.PaperID,  Allocation.UserID,Users.Name, Allocation.GradeID, Paper.Date, Paper.PaperTitle, Paper.URL, Allocation.PaperID as session FROM (Allocation  INNER JOIN Paper ON Allocation.PaperID = Paper.PaperID) INNER JOIN USERS on Allocation.UserID = Users.UserID ", sqlcon);

                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
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
    }
}