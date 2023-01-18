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
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();
            txtWO.Focus();
            //BindGridView();
            if (!Page.IsPostBack )
            {
                BindGridView2();

            }

            //System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
            //GridView1.RenderControl(htmlWriter);
            //string s = stringWriter.ToString();
            //Response.Write(s);
            //Response.End();

        }

        private void BindGridView()
        {

            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(connection);
            {
                SqlCommand sqlCommand = new SqlCommand("GetSerialsByWO", sqlConnectionData)
                { 
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                sqlCommand.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
                GridView1.DataSource = sqlCommand.ExecuteReader();
                if(GridView1.Rows.Count >= 1)
                {

                    GridView1.DataBind();
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
                SqlCommand sqlCommand = new SqlCommand("GetSerials", sqlConnectionData)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionData.Open();
                GridView1.DataSource = sqlCommand.ExecuteReader();
                GridView1.DataBind();

                sqlConnectionData.Close();
            }
        }

        protected void txtWO_TextChanged(object sender, EventArgs e)
        {   
            data1.Visible = true;
            data2.Visible = true;
            data3.Visible = true;
            data4.Visible = true;
            lblScrap.Visible = true;
            lblTotalWO.Visible = true;
            lblWO.Visible = true;
            lblDiag.Visible = true;
            lblIng.Visible = true;
            lblRepa.Visible = true;
            data5.Visible = true;
            string WO = txtWO.Text;
            Session["WO"] = WO;
            //btn_export.Visible = true;  
            BindGridView();
            AcumRepa();
            AcumWO();
            AcumScrap();
            AcumIngresadas();
            AcumDiagnos();
        }

        private void AcumRepa()
        {
            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData2 = new SqlConnection(connection);
            SqlCommand sqlCommand2 = new SqlCommand("GetQtyRepaWO", sqlConnectionData2)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData2.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
            SqlDataReader reader = sqlCommand2.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int qtyRepaWO = reader.GetInt32(reader.GetOrdinal("ConteoRepaWO"));
                lblRepa.Text = qtyRepaWO.ToString();
            }
            else
            {
                lblRepa.Text = "0";
            }
            sqlConnectionData2.Close();
        }

        private void AcumWO()
        {

            string connection4 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData4 = new SqlConnection(connection4);
            SqlCommand sqlCommand4 = new SqlCommand("GetInfoWOPTH", sqlConnectionData4)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData4.Open();
            sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
            SqlDataReader reader2 = sqlCommand4.ExecuteReader();
            reader2.Read();
            int QTYWO = reader2.GetInt32(reader2.GetOrdinal("Quantity"));
            lblTotalWO.Text = QTYWO.ToString();

            sqlConnectionData4.Close();
        }

        private void AcumScrap()
        {
            string connection5 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData5 = new SqlConnection(connection5);
            SqlCommand sqlCommand5 = new SqlCommand("GetQtyScrapWO", sqlConnectionData5)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData5.Open();
            sqlCommand5.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
            SqlDataReader reader3 = sqlCommand5.ExecuteReader();
            reader3.Read();
            int QTYWO = reader3.GetInt32(reader3.GetOrdinal("ConteoScrapWO"));
            lblScrap.Text = QTYWO.ToString();

            sqlConnectionData5.Close();
        }

        private void AcumDiagnos()
        {
            string connection6 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData6 = new SqlConnection(connection6);
            SqlCommand sqlCommand5 = new SqlCommand("GetQtyDiagnos", sqlConnectionData6)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData6.Open();
            sqlCommand5.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
            SqlDataReader reader3 = sqlCommand5.ExecuteReader();
            reader3.Read();
            int QTYWO = reader3.GetInt32(reader3.GetOrdinal("ConteoD"));
            lblDiag.Text = QTYWO.ToString();

            sqlConnectionData6.Close();
        }


        private void AcumIngresadas()
        {
            string connection7 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData7 = new SqlConnection(connection7);
            SqlCommand sqlCommand5 = new SqlCommand("GetQtyIngreso", sqlConnectionData7)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData7.Open();
            sqlCommand5.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 30).Value = txtWO.Text;
            SqlDataReader reader3 = sqlCommand5.ExecuteReader();
            reader3.Read();
            int QTYWO = reader3.GetInt32(reader3.GetOrdinal("ConteoI"));
            lblIng.Text = QTYWO.ToString();

            sqlConnectionData7.Close();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "WO_" + Session["WO"]  + "_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
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
    }
}