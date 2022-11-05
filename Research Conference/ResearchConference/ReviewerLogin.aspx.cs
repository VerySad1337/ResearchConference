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

        class loginController
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public DataTable loginValidationController(string LoginID, string Passwords)
            {
                string loginID = LoginID;
                string password = Passwords;
                dbConnection.Open();
                loginEntity myLogin = new loginEntity();
                DataTable myData = new DataTable();
                myLogin.getUserID(loginID, password).Fill(myData);
                return myData;
            }
           
        }

        class loginEntity
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            public SqlDataAdapter getUserID(string Loginid, string Passwords)
            {
                dbConnection.Open();
                string login = Loginid;
                string password = Passwords;
                SqlCommand myCommand = dbConnection.CreateCommand();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandText = "Select * from users where username='" + login + "' and password = '" + password + "'";
                myCommand.ExecuteNonQuery();                
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                dbConnection.Close();
                return myDataAdapter;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            string UserID = TextBox1.Text;
            string password = TextBox2.Text;
            loginController verify = new loginController();

            foreach (DataRow dr in verify.loginValidationController(UserID, password).Rows)
            {
                Session["userid"] = dr["userid"].ToString();
                Session["name"] = dr["name"].ToString();
                Session["roleid"] = dr["roleid"].ToString();
                string storeUserRole = dr["roleid"].ToString();
                int checkUserRole = int.Parse(storeUserRole);
                Response.Write(checkUserRole);
                if (checkUserRole == 3)
                {
                    Response.Redirect("ViewReview.aspx");
                }
                else if (checkUserRole == 1)
                {
                    Response.Redirect("Successful.aspx");
                }
            }
            dbConnection.Close();
            Label2.Text = "Invalid ID / Password";
        }
    }
}