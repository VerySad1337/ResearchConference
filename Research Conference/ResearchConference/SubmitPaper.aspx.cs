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
    public partial class SubmitPaper : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) 
            { Response.Redirect("LoginPage.aspx"); }

            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
            dbConnection.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(Session["roleid"].ToString()) == 4)
            {
                string currentSessionUserID = Session["UserID"].ToString();
                DateTime time = DateTime.Now;
                SqlTransaction sqltrans = dbConnection.BeginTransaction();
                SqlCommand command = dbConnection.CreateCommand();
                command.Transaction = sqltrans;
                command.CommandType = CommandType.Text;
                command.CommandText = "Insert into Paper(PaperTitle,URL, Date,UserIDPosted) values('" + PaperTitle.Text + "', '" + URL.Text + "' , '" + time + "' , '" + currentSessionUserID + "')";
                //string sql = "";
                // sql += "Insert into PaperTransactionToTieAuthor(AuthorID,PaperID)";
                //sql += "select PaperID, UserIDPosted From Paper";
                //sql += "where Paper.UserIDPosted = '" + currentSessionUserID + "'";
                command.ExecuteNonQuery();
                command.CommandText = "Insert into PaperTransactionToTieAuthor(UserID,PaperID) values('" + currentSessionUserID + "' , (SELECT MAX(PaperID) From Paper))";
                

                command.ExecuteNonQuery();
                sqltrans.Commit();

                Response.Redirect("~/Successful.aspx");

                PaperTitle.Text = "";
                URL.Text = "";
            }
        }





    }
}
