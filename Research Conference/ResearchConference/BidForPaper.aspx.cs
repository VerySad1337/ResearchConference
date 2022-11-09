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

        class BidForPaperController
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public SqlDataAdapter displayPaper()
            {
                BidForPaperEntity myEntity = new BidForPaperEntity();
                var x = myEntity.getPaper();
                return x;
            }




        }

        class BidForPaperEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public SqlDataAdapter getPaper()
            {
                dbConnection.Open();
                BidForPaperController myEntity = new BidForPaperController(); //Dont Make any sense if u mark, but you require BCE!.             
                SqlDataAdapter SQLQuery = new SqlDataAdapter ("Select PaperID, PaperTitle, URL from paper", dbConnection);
                dbConnection.Close();
                return SQLQuery;
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
                    dbConnection.Open();
                    string currentSessionUserID = Session["UserID"].ToString();
                    BidForPaperController createTable = new BidForPaperController();
                    DataTable myDataTable = new DataTable();
                    using (dbConnection)
                    {
                        createTable.displayPaper().Fill(myDataTable);
                        GridView2.DataSource = myDataTable;
                        GridView2.DataBind();
                        dbConnection.Close();

                        if (myDataTable.Rows.Count == 0)
                        {
                            Label3.Text = "No paper available";
                        }
                    }
                }
                else
                {
                    Label3.Text = "Why are you here? You are not reviewer!";
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