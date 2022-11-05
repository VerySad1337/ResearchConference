using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResearchConference.PaperManagement
{
    public partial class ViewComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    string reqPaperID = Request.QueryString["id"].ToString();
                    //retrieve Comments base on paperID
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
                    string com = "SELECT *,p.PaperTitle FROM Comments cmt, Paper p WHERE cmt.PaperID = p.PaperID AND cmt.PaperID = '" + reqPaperID + "'";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    gridPaper.DataSource = dt;
                    gridPaper.DataBind();

                    string papertitlt = "";
                    if(dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            papertitlt = row.Field<string>("PaperTitle");
                        }

                        lblTitle.Text = "'" + papertitlt + "' paper comment(s)";
                    }
                    else
                    {

                        string com2 = "SELECT * FROM Paper WHERE PaperID = '" + reqPaperID + "'";
                        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, con);
                        DataTable dt2 = new DataTable();
                        adpt2.Fill(dt2);

                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt2.Rows)
                            {
                                papertitlt = row.Field<string>("PaperTitle");
                            }

                            lblTitle.Text = "'" + papertitlt + "' paper comment(s)";
                            lblErrormsg.Text = "No Comment found.";
                        }                
                    }
                    
                }
                else
                {
                    lblErrormsg.Text = "No Comment found.";
                }
            }
        }
    }
}