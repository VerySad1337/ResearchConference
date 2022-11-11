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
    public partial class PublishPaper : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("ReviewerLogin.aspx");
            }

            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
            dbConnection.Open();
        }

        class PublishPaperController
        {
            string UID;

            public void setID(string userid)
            {
                UID = userid;
            }
            public string getID()
            {
                return UID;
            }

            public void AddPaper(string UserIDPosted, string URL, string DateT, string PaperTitle)
            {
                PublishPaperEntity entity = new PublishPaperEntity();
                entity.insert(UserIDPosted, URL, DateT, PaperTitle);
            }
        }
        class PublishPaperEntity
        {
            SqlConnection dbConnectionE = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            public void insert(string UserIDPosted, string URL, string DateT, string PaperTitle)
            {
                dbConnectionE.Open();
                SqlCommand command = dbConnectionE.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Insert into Paper(PaperTitle,URL, Date,UserIDPosted) values('" + PaperTitle + "', '" + URL + "' , '" + DateT + "' , '" + UserIDPosted + "')";
                command.ExecuteNonQuery();
                dbConnectionE.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            PublishPaperController controller = new PublishPaperController();
            controller.setID(Session["UserID"].ToString());
            string formatForSQL = time.ToString("YYYY-MM-DD hh:mm:ss");
            controller.AddPaper(controller.getID(), TextBox2.Text, formatForSQL, TextBox1.Text);


            Response.Redirect("~/Successful.aspx");

            /*string currentSessionUserID = Session["UserID"].ToString();
            DateTime time = DateTime.Now;
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Paper(PaperTitle,URL, Date,UserIDPosted) values('" + TextBox1.Text + "', '" + TextBox2.Text + "' , '" + time + "' , '" + currentSessionUserID+"')";
            command.ExecuteNonQuery();
            Response.Redirect("~/Successful.aspx");

            TextBox1.Text = "";
            TextBox2.Text = ""; */
        }
    }
}