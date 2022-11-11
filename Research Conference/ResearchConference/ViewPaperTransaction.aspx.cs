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
    public partial class ViewPaperTransaction : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                GVbind();
            }

            
        }

        protected void GVbind()
        {
            
            using(dbConnection)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("ReviewerLogin.aspx");
                }

                else
                {
                    dbConnection.Open();
                    string myUserID = Session["UserID"].ToString();

                    using (dbConnection)
                    {
                        SqlCommand cmd = new SqlCommand("Select PaperTransactionToTieAuthor.TransactionID,PaperTransactionToTieAuthor.UserID, Paper.PaperTitle, Paper.URL from PaperTransactionToTieAuthor, Paper where PaperTransactionToTieAuthor.UserID = Paper.UserIDPosted and PaperTransactionToTieAuthor.PaperID=Paper.PaperID");
                        cmd.Connection = dbConnection;
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.HasRows == true)
                        {
                            GridView1.DataSource = dr;
                            GridView1.DataBind();
                        }

                        else
                        {
                            Console.WriteLine("There is no Transactions !");
                        }
                    }
                }

                

            }

        }
    }
}