using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DiagnosticoReparacion
{
    public partial class Scrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();
            txtSerial.Focus();
        }

        protected void txtSerial_TextChanged(object sender, EventArgs e)
        {
            string workOrder, serialNumber, modelo, dataScan = txtSerial.Text, User = lblUSER.Text.ToString();

            DateTime currentDate = DateTime.Now;
            //Database Connection to Get Serial Details(WO, Model and Serial Number)
            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(conect);
            SqlCommand sqlCommandData = new SqlCommand("GetDriverDetails", sqlConnectionData)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnectionData.Open();
            sqlCommandData.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = dataScan;
            sqlCommandData.CommandTimeout = 9000;
            SqlDataReader sqlDataReaderData = sqlCommandData.ExecuteReader();
            sqlDataReaderData.Read();
            if (sqlDataReaderData.HasRows)
            {   //SqlDataReader (WO, Model and Serial Number)
                serialNumber = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("SerialNumber"));
                workOrder = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("WorkOrder"));
                modelo = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Model"));
                string UserIn = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("UserScan"));
                DateTime DateIn = sqlDataReaderData.GetDateTime(sqlDataReaderData.GetOrdinal("ScanDate"));
                //Enable & Disable Fields With Data, and Set data To Textbox and Labels and Format(colors)
                data1.Visible = true;
                data2.Visible = true;
                data3.Visible = true;
                data4.Visible = true;
                data5.Visible = true;
                lblMOD.Visible = true;
                lblWO.Visible = true;
                lblSN.Visible = true;
                lblDATE.Visible = true;
                lblUSER.Visible = true;
                lblSN.Text = serialNumber;
                lblWO.Text = workOrder;
                lblMOD.Text = modelo;
                lblUSER.Text = UserIn;
                lblDATE.Text = DateIn.ToString();
                lblSN.ForeColor = System.Drawing.Color.DarkBlue;
                lblWO.ForeColor = System.Drawing.Color.Black;
                lblMOD.ForeColor = System.Drawing.Color.Black;
                res.Text = "";
                //Conection To scrap in the driver 
                string conect2 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection sqlConnection2 = new SqlConnection(conect2);
                SqlCommand sqlCommand = new SqlCommand("AddScrap", sqlConnection2)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection2.Open();
                //Adding parameters to Stored Procedure Called "AddRepairFinished"
                sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 200).Value = dataScan;
                sqlCommand.Parameters.Add("@UserScan", SqlDbType.VarChar, 50).Value = UserIn;
                sqlCommand.Parameters.Add("@ScanDate", SqlDbType.DateTime, 20).Value = DateIn;
                sqlCommand.Parameters.Add("@EndUser", SqlDbType.VarChar, 50).Value = userlabel.Text.ToString();
                sqlCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 20).Value = currentDate;
                //sqlCommand.Parameters.Add("@CodeDefect", SqlDbType.VarChar, 20).Value = txtCodeDefect.Text;
                sqlCommand.CommandTimeout = 9000;
                SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
                sqlDataReader2.Read();
                int rowsInserted = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                //if the SerialNumber was succesfullly inserted into Driver repair Table, the Label "Res", set Text to  "INGRESADO CORRECTAMENTE";
                if (rowsInserted == 1)
                {
                    res.Attributes.Add("class", "alert alert-success");
                    res.Attributes.Add("role", "alert");
                    res.Text ="MANDADO A SCRAP CORRECTAMENTE";
                    res.ForeColor = System.Drawing.Color.Green;
                    lblSN.Text = dataScan;
                    txtSerial.Text = "";
                    // txtCodeDefect.Text = "";
                    txtSerial.Focus();
                }
                else if (rowsInserted == 0)
                {
                    res.Attributes.Add("class", "alert alert-danger");
                    res.Attributes.Add("role", "alert");
                    res.Text = "DRIVER SIN INGRESAR";
                    res.ForeColor = System.Drawing.Color.Red;
                    lblSN.Text = dataScan;
                    txtSerial.Text = "";
                    // txtCodeDefect.Text = "";
                    txtSerial.Focus();
                }
                //if the SerialNumber is actually inserted on DriverRepair Table the res.Text = "PIEZA YA ESCANEADA";
                else if (rowsInserted < 0)
                {
                    res.Text = "PIEZA YA ESCANEADA";
                    res.ForeColor = System.Drawing.Color.Orange;
                    lblSN.Text = dataScan;
                    txtSerial.Text = "";
                    // txtCodeDefect.Text = "";
                    txtSerial.Focus();
                }
                else if (rowsInserted == 2)
                {
                    res.Attributes.Add("class", "alert alert-warning");
                    res.Attributes.Add("role", "alert");
                    res.Text = "Driver ya se scrappeo antes";
                    res.ForeColor = System.Drawing.Color.Orange;
                    lblSN.Text = dataScan;
                    txtSerial.Text = "";
                    // txtCodeDefect.Text = "";
                    txtSerial.Focus();
                }
                //if the SerialNumber is not finded on [Traceability].[dbo].PottingScan Table the Res.Text is setted to "PIEZA NO ENCONTRADA";


                sqlConnection2.Close();
            }
            else
            {
                data1.Visible = true;
                data2.Visible = true;
                data3.Visible = true;
                txtSerial.Visible = true;
                lblSN.Visible = true;
                lblMOD.Visible = true;
                lblWO.Visible = true;
                txtSerial.Focus();
                lblMOD.Text = "N/A";
                lblWO.Text = "N/A";
                res.Text = "PIEZA NO ENCONTRADA";
                lblUSER.Text = "N/A";
                lblDATE.Text = "N/A";
                lblUSER.ForeColor = System.Drawing.Color.Red;
                lblDATE.ForeColor = System.Drawing.Color.Red;
                res.ForeColor = System.Drawing.Color.Red;
                lblSN.ForeColor = System.Drawing.Color.Red;
                lblMOD.ForeColor = System.Drawing.Color.Red;
                lblWO.ForeColor = System.Drawing.Color.Red;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
            }//else


        }
    }
}