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
    public partial class InventarioBacklog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Visible = true;
            userlabel.Text = Session["user"].ToString();
            //BindGridView2();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Reporte de Backlog" + "_" + DateTime.Now + ".xls";
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        private void BindGridView2()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetBacklog", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                GridView12.DataSource = sqlCommand.ExecuteReader();
                GridView12.DataBind();

                sqlConnectionData.Close();
            }
        }

        protected void GridView12_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get value of third column. Index is zero based, to
                // get text of third column we use Cells[2].Text
                int CellValue = Convert.ToInt32(e.Row.Cells[4].Text);

                // If value is greater of 10, change format
                if (CellValue >= 14)
                {
                    // Use this syntax to change format of complete row
                    e.Row.BackColor = System.Drawing.Color.LightCoral;
                    // Use this syntax to change format of single cell
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightCoral;
                }
                else if (CellValue < 14)
                {
                    // Use this syntax to change format of complete row
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                    // Use this syntax to change format of single cell
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightGreen;
                }
                else if (CellValue == 0)
                {
                    // Use this syntax to change format of complete row
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                    // Use this syntax to change format of single cell
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }
    }
}