using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResearchConference
{
    public partial class PaperAssignment : System.Web.UI.Page
    {
        DataSet1 ds = new DataSet1();
        DataSet1TableAdapters.AllocationTableAdapter allocateTableAdpter = new DataSet1TableAdapters.AllocationTableAdapter();


        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccessMsg.Visible = false;
            lblErrorMsg.Visible = false;
            if (!IsPostBack)
            {
                

                //retrieve list of paper
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                string com = "select * from Paper";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlPaperselection.DataSource = dt;
                ddlPaperselection.DataBind();
                ddlPaperselection.DataTextField = "PaperTitle";
                ddlPaperselection.DataValueField = "PaperID";
                ddlPaperselection.DataBind();
                ddlPaperselection.Items.Insert(0, new ListItem("---- Select ----", ""));
                ddlPaperselection.SelectedIndex = 0;


                //retrieve reviewer users list from Users DB
                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                string com2 = "select * from Users where RoleID ='3' ";
                SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con2);
                DataTable dt2 = new DataTable();
                adpt2.Fill(dt2);
                ddlReviewer.DataSource = dt2;
                ddlReviewer.DataBind();
                ddlReviewer.DataTextField = "Name";
                ddlReviewer.DataValueField = "UserID";
                ddlReviewer.DataBind();
                ddlReviewer.Items.Insert(0, new ListItem("---- Select ----", ""));
                ddlReviewer.SelectedIndex = 0;
            }
            
        }

        protected void ddlPaperselection_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        protected void ddlReviewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAssignOnClick(object sender, EventArgs e)
        {
            allocateTableAdpter.InsertQuery(Int32.Parse(ddlPaperselection.SelectedValue),Int32.Parse(ddlReviewer.SelectedValue));
            lblSuccessMsg.Visible = true;
            lblErrorMsg.Visible = false;
        }



    }
}