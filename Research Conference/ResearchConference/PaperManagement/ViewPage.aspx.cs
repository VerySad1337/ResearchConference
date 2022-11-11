using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ResearchConference.PaperManagement
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if (Request.QueryString["sent"] != null)
                {
                    if (Request.QueryString["sent"].ToString() == "1")
                    {
                        lblEmailSuccess.Visible = true;
                    }
                    else
                    {
                        lblEmailSuccess.Visible = false;
                    }
                }
                else
                {
                    lblEmailSuccess.Visible = false;
                }

            }
        }


        private void BindGrid()
        {
            //retrieve list of paper
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            string com = "SELECT * FROM Paper AS p JOIN(SELECT al.PaperID, sum(al.GradeID) AS TotalRate, count(al.PaperID) as totalQty, CAST(CAST(sum(al.GradeID / 7) as DECIMAL(7, 2)) / CAST(count(al.PaperID) as DECIMAL(7, 2)) as DECIMAL(7, 2)) as finalRate " +
                "FROM Allocation al WHERE al.GradeID != '' " +
                "GROUP BY al.PaperID) AS s ON p.PaperID = s.PaperID";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gridPaper.DataSource = dt;
            gridPaper.DataBind();


        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPaper.PageIndex = e.NewPageIndex;
            gridPaper.DataBind();
        }

        protected void gridPaper_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gridPaper.EditIndex = e.NewEditIndex;
                BindGrid();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void gridPaper_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridPaper.EditIndex = -1;
            BindGrid();
        }


        protected void gridPaper_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //try
            //{
            //    string servicename = ((TextBox)gridPaper.Rows[e.RowIndex].FindControl("txtxApproval")).Text;
            //    //string filePath = ((FileUpload)gridPaper.Rows[e.RowIndex].FindControl("fuService")).FileName;

            //    _BindService();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            string paperID = ((Label)gridPaper.Rows[e.RowIndex].FindControl("lblPaperID")).Text;

            string paperTitle = ((Label)gridPaper.Rows[e.RowIndex].FindControl("lblTitle")).Text;

            string AuthorID = ((Label)gridPaper.Rows[e.RowIndex].FindControl("lblAuthorID")).Text;


            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            string com2 = "SELECT * FROM Paper WHERE PaperID ='" + paperID + "'";
            SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con2);
            DataTable dt2 = new DataTable();
            adpt2.Fill(dt2);

            string getAppStatus = "Approved";
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    getAppStatus = row.Field<string>("Approval");
                }
            }


            try
            {
                string ddlSelectedApprovalStatus = ((DropDownList)gridPaper.Rows[e.RowIndex].FindControl("ddlApproval")).SelectedValue.ToString();
                //string paperTitlename = ((Label)gridPaper.Rows[e.RowIndex].FindControl("lblTitle")).Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                string com = "UPDATE Paper SET Approval ='" + ddlSelectedApprovalStatus + "' WHERE PaperID ='" + paperID + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                gridPaper.DataSource = dt;
                gridPaper.DataBind();


                string getEmail = "";

                using (SqlConnection sqlConnection2 = con)
                {
                    string status = "select Email from Users where UserID = @userID";
                    SqlCommand sqlComm2 = new SqlCommand(status, sqlConnection2);
                    sqlComm2.Parameters.AddWithValue("@userID", AuthorID);
                    try
                    {
                        sqlConnection2.Open();
                        var returnValue = sqlComm2.ExecuteScalar();
                        if (returnValue != null)
                        {
                            getEmail = returnValue.ToString();
                        }

                        sqlConnection2.Close();
                    }
                    catch (Exception ex)
                    {
                        //handle exception
                    }
                }




                string to = getEmail; //To address    
                string from = "researchconferencesys@zohomail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = "The Paper: '" + paperTitle + "' has been updated by Conference Chair. \n You may check the result on Research Conference system.";
                message.Subject = "Paper Approval Notification";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.zoho.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("researchconferencesys@zohomail.com", "Abcde1234@");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;

                try
                {
                    client.Send(message);

                }

                catch (Exception ex)
                {
                    throw ex;
                }


                Response.Redirect(Request.Url.AbsoluteUri + "?sent=1");



                //set the selected item to the same as database status when edit clicked
                //((DropDownList)gridPaper.Rows[e.RowIndex].FindControl("ddlApproval")).Items.FindByValue(getAppStatus).Selected = true;
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}