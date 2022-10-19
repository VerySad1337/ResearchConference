using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResearchConference
{
    public partial class PaperAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPaperselection.Items.Insert(0, new ListItem(" --Select--", "0"));
                ddlPaperselection.SelectedIndex = 0;
                ddlReviewer.Items.Insert(0, new ListItem(" --Select--", "0"));
                ddlReviewer.SelectedIndex = 0;
            }
            
        }

        protected void ddlPaperselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            ddlPaperselection.Items.Clear();
            //ddlPaperselection.DataSource = dt.Tables[0];
            ddlPaperselection.DataTextField = "ReportType";
            ddlPaperselection.DataValueField = "ReportTypeID";
            ddlPaperselection.DataBind();
            ddlPaperselection.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlReportType.Items[0].Value = "0";
            ddlPaperselection.SelectedIndex = 0;
            */
            
        }

        protected void ddlReviewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



    }
}