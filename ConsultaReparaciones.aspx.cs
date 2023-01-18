using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DiagnosticoReparacion
{
    public partial class ConsultaReparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Visible = true;
            userlabel.Text = Session["user"].ToString();
            BindGridView2();
        }

        protected void txtWO_TextChanged(object sender, EventArgs e)
        {
            BindGridView();
            string WO = txtWO.Text;
            Session["WO"] = WO;
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Reporte de Reparaciones" + "_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView12.GridLines = GridLines.Both;
            GridView12.HeaderStyle.Font.Bold = true;
            GridView12.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        private void BindGridView()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetRepairedSerialsWo", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                sqlCommand.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
                GridView12.DataSource = sqlCommand.ExecuteReader();
                if (GridView12.Rows.Count >= 1)
                {

                    GridView12.DataBind();
                }
                else
                {
                    lblTotalWO.Text = "WO No Encontrada";
                    lblTotalWO.ForeColor = System.Drawing.Color.Red;
                }

                sqlConnectionData.Close();
            }
        }


        private void BindGridView2()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetRepairedSerials", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                GridView12.DataSource = sqlCommand.ExecuteReader();
                GridView12.DataBind();

                sqlConnectionData.Close();
            }
        }


    }
}