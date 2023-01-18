using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DiagnosticoReparacion
{
    public partial class ReparacionSalida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Text = Session["user"].ToString();
            txtSerial.Focus();

        }

        protected void txtSerial_TextChanged(object sender, EventArgs e)
        {

            string workOrder, serialNumber, modelo, dataScan = txtSerial.Text;
           
            DateTime currentDate = DateTime.Now;


            //Database Connection to Get Serial Details(WO, Model and Serial Number)
            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnectionData = new SqlConnection(conect);
            SqlCommand sqlCommandData = new SqlCommand("GetDiagnosticDetails", sqlConnectionData)
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
                string UserIn = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("DiagnosticUser"));
                DateTime DateIn = sqlDataReaderData.GetDateTime(sqlDataReaderData.GetOrdinal("DiagnosticDate"));
                string Diagnostic = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Diagnostic"));
                string Location = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Location"));

                //string falla = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Failure"));
                //string valor = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Value"));


                //Enable & Disable Fields With Data, and Set data To Textbox and Labels and Format(colors)
                lblLoc.Visible = true;
                lblDiagnostic.Visible = true;
                data8.Visible = true;
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
                lblLoc.Text = Location;
                lblSN.Text = serialNumber;
                lblWO.Text = workOrder;
                lblMOD.Text = modelo;
                lblUSER.Text = UserIn;
                lblDATE.Text = DateIn.ToString();
                lblDiagnostic.Text = Diagnostic;
               // lblFalla.Text = falla;
               // lblValor.Text = valor;
                lblSN.ForeColor = System.Drawing.Color.DarkBlue;
                lblWO.ForeColor = System.Drawing.Color.Black;
                lblMOD.ForeColor = System.Drawing.Color.Black;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                Repair.Visible = true;
               // lblFalla.Visible = true;
                //lblValor.Visible = true;
               // Label1.Visible = true;
               // Label2.Visible = true;

                //lblCodeDefect.Visible = true;
                //txtCodeDefect.Visible = true;
                //lblCodeDefect.Enabled = true;
                //txtCodeDefect.Enabled = true;
                //txtCodeDefect.Focus();
                res.Text = "";

                lblDiagnostic.Visible = true;
                data6.Visible = true;
                data7.Visible = true;
                Repair.Visible = true;
            }
            else
            {
                res.Attributes.Add("class", "alert alert-danger");
                res.Attributes.Add("role", "alert");
                data1.Visible = true;
                data2.Visible = true;
                data3.Visible=true;
                txtSerial.Visible = true;
                lblSN.Visible=true;
                lblMOD.Visible = true;
                lblWO.Visible = true;
                txtSerial.Focus();
                lblMOD.Text = "N/A";
                lblWO.Text = "N/A";
                res.Text = "PIEZA NO ENCONTRADA";
                res.ForeColor = System.Drawing.Color.Red;
                lblSN.ForeColor = System.Drawing.Color.Red;
                lblMOD.ForeColor= System.Drawing.Color.Red;
                lblWO.ForeColor= System.Drawing.Color.Red;
                lblSN.Text = dataScan;
                lblUSER.Text = "N/A";
                lblDATE.Text = "N/A";
                lblUSER.ForeColor = System.Drawing.Color.Red;
                lblDATE.ForeColor = System.Drawing.Color.Red;
                txtSerial.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string  dataScan = txtSerial.Text, User =lblUSER.Text.ToString();
            DateTime currentDate = DateTime.Now;
            //Conection To reapir out the driver 
            string conect2 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnection2 = new SqlConnection(conect2);
            SqlCommand sqlCommand = new SqlCommand("AddFinishRepair", sqlConnection2)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnection2.Open();
            //Adding parameters to Stored Procedure Called "AddRepairFinished"
            sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 200).Value = dataScan;
            sqlCommand.Parameters.Add("@EndUser", SqlDbType.VarChar, 50).Value = userlabel.Text.ToString();
            sqlCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 20).Value = currentDate;
            sqlCommand.Parameters.Add("@Repair", SqlDbType.VarChar, 50).Value = Repair.Text.ToString();
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
                res.Visible = true;
                res.Text = "REPARACIÓN FINALIZADA";
                res.ForeColor = System.Drawing.Color.Green;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }

            //if the SerialNumber is actually inserted on DriverRepair Table the res.Text = "PIEZA YA ESCANEADA";
            else if (rowsInserted == 3)
            {
                res.Attributes.Add("class", "alert alert-warning");
                res.Attributes.Add("role", "alert");
                res.Text = "PIEZA YA ESCRAPPEADA";
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
                res.Text = "driver existente y reparado, reeingrese de nuevo ";
                res.ForeColor = System.Drawing.Color.Orange;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }

            else if (rowsInserted == 4)
            {
                res.Attributes.Add("class", "alert alert-warning");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER SIN DIAGNOSTICO";
                res.ForeColor = System.Drawing.Color.Orange;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            sqlConnection2.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtSerial.Text = "";
            data1.Visible = false;
            data2.Visible = false;
            data3.Visible = false;
            data4.Visible = false;
            data5.Visible = false;
            lblMOD.Visible = false;
            lblWO.Visible = false;
            lblSN.Visible = false;
            lblDATE.Visible = false;
            lblUSER.Visible = false;
            lblSN.Text = "";
            lblWO.Text = "";
            lblMOD.Text = "";
            lblUSER.Text = "";
            lblDATE.Text = "";
            lblSN.ForeColor = System.Drawing.Color.DarkBlue;
            lblWO.ForeColor = System.Drawing.Color.Black;
            lblMOD.ForeColor = System.Drawing.Color.Black;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            res.Text = "";
            lblDiagnostic.Visible = false;
            data6.Visible = false;
            data7.Visible = false;
            res.Visible = false;
        }
    }
}