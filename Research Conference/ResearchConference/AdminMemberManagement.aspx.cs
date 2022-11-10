using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ResearchConference
{
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
           
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string queryString = "SELECT * FROM [RCMS].[dbo].[Users] WHERE [UserID]='"+ TxtMbrID.Text+ "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);
                    DataSet UerRole = new DataSet();
                    adapter.Fill(UerRole);
                    if (UerRole.Tables.Count > 0 && UerRole.Tables[0].Rows.Count>0)
                    {  
                        lblmessage.Visible = true;
                        lblmessage.Text = "User Exist";
                        divAccountStatus.Visible = true;
                        divDispalyName.Visible = true;
                        divLoginId.Visible = true;
                        divpassword.Visible = true;
                        divSalt.Visible = true;
                        divMaxRevw.Visible = true;
                        divRole.Visible = true;
                        Update.Visible = true;
                        DeleteButton.Visible = true;
                        Search.Visible = true;
                        //
                        TxtMbrID.Text = (UerRole.Tables[0].Rows[0]["UserID"]).ToString();
                        txtAccount.Text = "Active";
                        TxtDisplayName.Text = (UerRole.Tables[0].Rows[0]["Name"]).ToString();
                        TxtUserName.Text = (UerRole.Tables[0].Rows[0]["Username"]).ToString();
                        txtPassword.Text = (UerRole.Tables[0].Rows[0]["Password"]).ToString();
                        TxtSalt.Text = (UerRole.Tables[0].Rows[0]["Salt"]).ToString();
                        TxtMaxReview.Text = (UerRole.Tables[0].Rows[0]["MaxReview"]).ToString();
                        ddRole.ClearSelection();
                        ddRole.Items.FindByValue((UerRole.Tables[0].Rows[0]["RoleID"]).ToString()).Selected = true;

                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "";
                        lblmessage.Text = "User dosen't exist. Please create new user";
             
                        divDispalyName.Visible = true;
                        divLoginId.Visible = true;
                        divpassword.Visible = true;
                        divSalt.Visible = true;
                        divMaxRevw.Visible = true;
                        divRole.Visible = true;
                        divAccountStatus.Visible = false;
                        Insert.Visible = true;
                        Update.Visible = false;
                        DeleteButton.Visible = false;
                        Search.Visible = false;
                        TxtMbrID.Text = "" ;
                        TxtDisplayName.Text = "";
                        TxtUserName.Text = "";
                        txtPassword.Text = "";
                        TxtSalt.Text = "";
                        TxtMaxReview.Text = "";
                        ddRole.ClearSelection();
                    }

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string queryString = "SELECT MAX (UserID) As MaxUserID FROM [RCMS].[dbo].[Users]";
                int maxid = 0;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);
                    DataSet UerRole = new DataSet();
                    adapter.Fill(UerRole);
                    if (UerRole.Tables.Count > 0 && UerRole.Tables[0].Rows.Count > 0)
                    {
                        maxid = Convert.ToInt32((UerRole.Tables[0].Rows[0]["MaxUserID"]).ToString());
                    }
                    string insertQuery="INSERT INTO[dbo].[Users] (UserID,Username,Name,Password,Salt,RoleID,MaxReview) VALUES (@UserID,@Username,@Name,@Password,@Salt,@RoleID,@MaxReview)";
                    using (SqlCommand command = new SqlCommand(insertQuery, con))
                    {
                        command.Parameters.AddWithValue("@UserID", maxid+1);
                        command.Parameters.AddWithValue("@Username", TxtUserName.Text.ToString());
                        command.Parameters.AddWithValue("@Name", TxtDisplayName.Text.ToString());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                        command.Parameters.AddWithValue("@Salt", maxid+1);
                        command.Parameters.AddWithValue("@RoleID",Convert.ToInt32(ddRole.SelectedValue));
                        command.Parameters.AddWithValue("@MaxReview", (!string.IsNullOrEmpty(TxtMaxReview.Text)) ? "0" : TxtMaxReview.Text);
                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            lblmessage.Text = "";
                            lblmessage.Text = "Error inserting data into Database!.";
                        }
                        else
                        {
                            lblmessage.Text = "";
                            lblmessage.Text = "User inserted Sucessfully.";
                            Search.Visible = true;
                            loadGrid();
                        }
                           
                    }

                }
               
               
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                { 
                    string updateQuery = "UPDATE [dbo].[Users] SET UserID =@UserID, Username =@UserID, Name =@Name, " +
                        "Password =@Password, Salt =@Salt, RoleID =@RoleID, MaxReview = @MaxReview WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(updateQuery, con))
                    {
                        command.Parameters.AddWithValue("@UserID", TxtMbrID.Text);
                        command.Parameters.AddWithValue("@Username", TxtUserName.Text.ToString());
                        command.Parameters.AddWithValue("@Name", TxtDisplayName.Text.ToString());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                        command.Parameters.AddWithValue("@Salt", TxtSalt.Text.ToString());
                        command.Parameters.AddWithValue("@RoleID", Convert.ToInt32(ddRole.SelectedValue));
                        command.Parameters.AddWithValue("@MaxReview", (!string.IsNullOrEmpty(TxtMaxReview.Text)) ? "0" : TxtMaxReview.Text);
                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            lblmessage.Text = "";
                            lblmessage.Text = "Error inserting data into Database!.";
                        }
                           
                        else
	                    {
                            lblmessage.Text = "";
                            lblmessage.Text = "User details updated Sucessfully.";
                            Search.Visible = true;
                            loadGrid();
                        }
                    }
                }
             
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string updateQuery = "Delete FROM [dbo].[Users] WHERE UserID= @UserID";
                    using (SqlCommand command = new SqlCommand(updateQuery, con))
                    {
                        command.Parameters.AddWithValue("@UserID", TxtMbrID.Text);
                        con.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            lblmessage.Text = "";
                            lblmessage.Text = "Error inserting data into Database!.";
                        }
                        else
                        {
                            lblmessage.Text = "";
                            lblmessage.Text = "User deleted Sucessfully.";
                            loadGrid();
                        }
                          
                    }
                }
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void loadGrid()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    string queryString = "SELECT u.[UserID] as 'UserID' ,u.[Name] as 'Name',r.[Roles] as 'Role',u.[MaxReview] as 'MaxReview' FROM [RCMS].[dbo].[Users] u inner join Roles r on u.RoleID=r.RoleID;";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);
                    DataSet UerRole = new DataSet();
                    adapter.Fill(UerRole);
                    if (UerRole.Tables.Count > 0)
                    {
                        GV1.DataSource = UerRole.Tables[0];
                        GV1.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

    }
}