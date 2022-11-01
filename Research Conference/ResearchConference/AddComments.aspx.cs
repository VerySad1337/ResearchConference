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
    public partial class AddComments : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PaperIDFromRow"] != null)
            {
                string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
                string queryResult2 = "Select Paper.PaperTitle from Paper INNER JOIN Allocation On Allocation.PaperID = Paper.PaperID where Paper.PaperID= " + currentSessionPaperID;
                SqlCommand displayPaperTitle = new SqlCommand(queryResult2, dbConnection);
                dbConnection.Open();
                string outputPaperTitle = displayPaperTitle.ExecuteScalar().ToString();
                Label3.Text = "Currently giving comments for: "+ outputPaperTitle;                
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                dbConnection.Open();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            string currentSessionPaperID = Session["PaperIDFromRow"].ToString();
            command.CommandText = "Insert into Comments(Comments,PaperID) values('"+TextBox1.Text+"' , '"+currentSessionPaperID+"')";
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }

}