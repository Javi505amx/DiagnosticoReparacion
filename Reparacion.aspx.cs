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
    public partial class Reparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   

            userlbl.Visible = true;
            userlabel.Text = Session["user"].ToString();

            txtSerial.Focus();
        }



        protected void txtSerial_TextChanged(object sender, EventArgs e)
        {
            //Local VAriables
            string workOrder, serialNumber, modelo, dataScan = txtSerial.Text;


            //Database Connection to Get Serial Details(WO, Model and Serial Number)
            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(conect);
            SqlCommand sqlCommandData = new SqlCommand("GetSerialDetails", sqlConnectionData)
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
                //Enable & Disable Fields With Data, and Set data To Textbox and Labels and Format(colors)
                data1.Visible = true;
                data2.Visible = true;
                data3.Visible = true;
                data4.Visible = true;
                data5.Visible = true;
                lblMOD.Visible = true;
                lblWO.Visible = true;
                lblSN.Visible = true;
                lblSN.Text = serialNumber;
                lblWO.Text = workOrder;
                lblMOD.Text = modelo;
                lblSN.ForeColor = System.Drawing.Color.DarkBlue;
                lblWO.ForeColor = System.Drawing.Color.Black;
                lblMOD.ForeColor = System.Drawing.Color.Black;
                res.Text = "";
                btnSave.Visible = true;
                btnCancel.Visible = true;
                txtValue.Visible = true;
                ListValue.Visible = true;
                LinkButton1.Visible = false;


            }
            //if the SerialNumber was not finded on PottingScan Table shows on lblSN.Text = "SERIAL NO ENCONTRADO"; res.Text = "INTENTE NUEVAMENTE";
            else
            {
                res.Attributes.Add("class", "alert alert-danger");
                res.Attributes.Add("role", "alert");
                data1.Visible = true;
                data2.Visible = true;
                data3.Visible = true;
                lblSN.ForeColor = System.Drawing.Color.Red;
                lblSN.Text = "SERIAL NO ENCONTRADO";
                txtSerial.Focus();
                lblMOD.Text = "N/A";
                lblWO.Text = "N/A";
                lblWO.ForeColor = System.Drawing.Color.Red;
                lblMOD.ForeColor = System.Drawing.Color.Red;
                txtSerial.Text = "";
                
                txtSerial.Focus();
                res.Text = "INTENTE NUEVAMENTE";
            }
            sqlConnectionData.Close();
            //*******************************************************************************************************************************************************////
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //variables 
            string  dataScan = txtSerial.Text;
            DateTime currentDate = DateTime.Now;
            //Conection To Add a driver into Driver Repair Table
            string conect2 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnection2 = new SqlConnection(conect2);
            SqlCommand sqlCommand = new SqlCommand("AddDriverRepair", sqlConnection2)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnection2.Open();
            //Adding parameters to Stored Procedure Called "AddDriverRepair"
            sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = dataScan;
            sqlCommand.Parameters.Add("@RepairDate", SqlDbType.DateTime, 50).Value = currentDate;
            sqlCommand.Parameters.Add("@RepairUser", SqlDbType.VarChar, 30).Value = userlabel.Text;
            sqlCommand.Parameters.Add("@Failure", SqlDbType.VarChar, 30).Value = ListValue.SelectedValue.ToString();
            sqlCommand.Parameters.Add("@Value", SqlDbType.VarChar, 20).Value = txtValue.Text;


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
                res.Text = "DRIVER INGRESADO";
                res.ForeColor = System.Drawing.Color.Green;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                ListValue.Visible = false;
                txtValue.Visible = false;
                data4.Visible = false;
                data5.Visible = false;
                txtSerial.Focus();
            }

            //if the SerialNumber is actually inserted on DriverRepair Table the res.Text = "DRIVER EN PROCESO DE REPARACION";
            else if (rowsInserted == 2)
            {
                res.Attributes.Add("class", "alert alert-danger mx-auto");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER YA SE ENCUENTRA INGRESADO";
                res.ForeColor = System.Drawing.Color.Red;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                txtSerial.Focus();
            }
            else if (rowsInserted == 3)
            {   
                res.Attributes.Add("class", "alert alert-primary font-weight-bold");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER DIAGNOSTICADO";
                res.ForeColor = System.Drawing.Color.Blue;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            else if (rowsInserted == 4)
            {
                res.Attributes.Add("class", "alert alert-primary font-weight-bold mx-auto");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER REEINGRESADO";
                res.ForeColor = System.Drawing.Color.Blue;
                lblSN.Text = dataScan;
                txtSerial.Text = ""; 
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            else if (rowsInserted == 5)
            {
                res.Attributes.Add("class", "alert alert-primary font-weight-bold");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER EN SCRAP";
                res.ForeColor = System.Drawing.Color.Blue;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            else if (rowsInserted == 8)
            {
                res.Attributes.Add("class", "alert alert-danger font-weight-bold");
                res.Attributes.Add("role", "alert");
                res.Text = "CONTACTAR A IT";
                res.ForeColor = System.Drawing.Color.Red;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            btnSave.Visible = false;
            btnCancel.Visible = false;
            ListValue.Visible = false;
            txtValue.Visible = false;
            data4.Visible = false;
            data5.Visible = false;
            sqlConnection2.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {   txtSerial.Text = "";
            data1.Visible = false;
            data2.Visible = false;
            data3.Visible = false;
            data4.Visible = false;
            data5.Visible = false;
            lblMOD.Visible = false;
            lblWO.Visible = false;
            lblSN.Visible = false;
            txtValue.Visible = false;
            ListValue.Visible = false;
            lblSN.Text = "";
            lblWO.Text = "";
            lblMOD.Text = "";
            txtValue.Text = "";
            lblSN.ForeColor = System.Drawing.Color.DarkBlue;
            lblWO.ForeColor = System.Drawing.Color.Black;
            lblMOD.ForeColor = System.Drawing.Color.Black;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            res.Visible = false;
            res.Text = "";
        }
    }
}