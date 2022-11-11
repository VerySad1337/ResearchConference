using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ResearchConference
{
    public partial class LoginPage : System.Web.UI.Page
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

        protected void ValidateUser(object sender, EventArgs e)
        {
            bool rememberMeSet = (Login1.FindControl("chkRememberMe") as CheckBox).Checked;
            Literal failureText = (Login1.FindControl("lblFailureText") as Literal);
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                    cmd.Parameters.AddWithValue("@Password", Login1.Password);
                    cmd.Connection = con;
                    con.Open();
                    //userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        failureText.Text = "Username and/or password is incorrect.";
                        break;
                    case -2:
                        failureText.Text = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, rememberMeSet);
                        break;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);

            string UserID = Login1.UserName;
            string password = Login1.Password;
            loginController verify = new loginController();

            foreach (DataRow dr in verify.loginValidationController(UserID, password).Rows)
            {
                Session["userid"] = dr["userid"].ToString();
                Session["name"] = dr["name"].ToString();
                Session["roleid"] = dr["roleid"].ToString();
                string storeUserRole = dr["roleid"].ToString();
                int checkUserRole = int.Parse(storeUserRole);
                Response.Write(checkUserRole);
                if (checkUserRole == 1)
                {
                    Response.Redirect("Successful.aspx");
                }
                else if (checkUserRole == 2)
                {
                    Response.Redirect("Successful.aspx");
                }
                else if (checkUserRole == 3)
                {
                    Response.Redirect("ViewReview.aspx");
                }
                else if (checkUserRole == 4)
                {
                    Response.Redirect("SubmitPaper.aspx");

                }
                dbConnection.Close();
            }

        }
    }
}