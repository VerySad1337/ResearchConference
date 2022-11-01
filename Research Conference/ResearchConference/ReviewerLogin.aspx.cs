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
    public partial class ReviewerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            dbConnection.Open();
            SqlCommand myCommand = dbConnection.CreateCommand();
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText= "Select * from users where username='" +TextBox1.Text+"' and password = '"+ TextBox2.Text+"'";
            myCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                Session["userid"] = dr["userid"].ToString();
                Session["name"] = dr["name"].ToString();
                Session["roleid"] = dr["roleid"].ToString();
                string storeUserRole = dr["roleid"].ToString();
                int checkUserRole = int.Parse(storeUserRole);
                if (checkUserRole == 3)
                {
                    Response.Redirect("ViewReview.aspx");
                }
                else if (checkUserRole == 1)
                {
                    Response.Redirect("Successful.aspx");
                }
                else
                {
                    Label2.Text = "Wrong username / password";
                }

            }

            dbConnection.Close();
            Label2.Text = "Invalid ID / Password";

        }
    }
}