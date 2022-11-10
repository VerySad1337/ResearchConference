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
    public partial class BidForPaper : System.Web.UI.Page
    {
        string dbConnection = @"Data Source=DESKTOP-0R2NCQ5;Initial Catalog = RCMS; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("ReviewerLogin.aspx");
            }
            else
            {

                using (SqlConnection sqlcon = new SqlConnection(dbConnection))
                {
                    string currentSessionUserID = Session["UserID"].ToString();
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("Select PaperID,PaperTitle,URL from paper", sqlcon);

                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    GridView2.DataSource = dtbl;
                    GridView2.DataBind();

                    if (dtbl.Rows.Count == 0)
                    {
                        Label3.Text = "No paper available";
                    }
                }
            }

        }
        protected void bidPaper_Click(object sender, EventArgs e)
        {
            int PaperID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string PaperIDSession = PaperID.ToString();
            Session["PaperIDFromRow"] = PaperIDSession;
            Response.Redirect("ConfirmationBidPaper.aspx");
        }
    }
}