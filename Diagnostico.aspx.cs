using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DiagnosticoReparacion
{
    public partial class Diagnostico : System.Web.UI.Page
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
                string falla = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Failure"));
                string valor = sqlDataReaderData.GetString(sqlDataReaderData.GetOrdinal("Value"));


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
                lblFalla.Text = falla;
                lblValor.Text = valor;
                lblSN.ForeColor = System.Drawing.Color.DarkBlue;
                lblWO.ForeColor = System.Drawing.Color.Black;
                lblMOD.ForeColor = System.Drawing.Color.Black;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                txtDiag.Visible = true;
                txtLoc.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                lblFalla.Visible = true;
                lblValor.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                res.Visible = true;
                desc.Visible = true;

                //lblCodeDefect.Visible = true;
                //txtCodeDefect.Visible = true;
                //lblCodeDefect.Enabled = true;
                //txtCodeDefect.Enabled = true;
                //txtCodeDefect.Focus();
                res.Text = "";
            }
            else
            {
                res.Attributes.Add("class", "alert alert-danger");
                res.Attributes.Add("role", "alert");
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
                res.ForeColor = System.Drawing.Color.Red;
                lblSN.ForeColor = System.Drawing.Color.Red;
                lblMOD.ForeColor = System.Drawing.Color.Red;
                lblWO.ForeColor = System.Drawing.Color.Red;
                lblSN.Text = dataScan;
                lblUSER.Text = "N/A";
                lblDATE.Text = "N/A";
                lblUSER.ForeColor = System.Drawing.Color.Red;
                lblDATE.ForeColor = System.Drawing.Color.Red;
                txtSerial.Text = "";
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                txtDiag.Visible = false;
                txtLoc.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //variables 
            string dataScan = txtSerial.Text;
            DateTime currentDate = DateTime.Now;
            //Conection To Add a driver into Driver Repair Table
            string conect2 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlConnection2 = new SqlConnection(conect2);
            SqlCommand sqlCommand = new SqlCommand("AddDiagnostic", sqlConnection2)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlConnection2.Open();
            //Adding parameters to Stored Procedure Called "AddDriverRepair"
            sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = dataScan;
            sqlCommand.Parameters.Add("@EndUser", SqlDbType.VarChar, 30).Value = userlabel.Text;
            sqlCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 50).Value = currentDate;
            sqlCommand.Parameters.Add("@Diagnostic", SqlDbType.VarChar, 30).Value = txtDiag.Text;
            sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = txtLoc.Text;

            sqlCommand.CommandTimeout = 9000;
            SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
            sqlDataReader2.Read();
            int rowsInserted = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
            //if the SerialNumber was succesfullly inserted into Driver repair Table, the Label "Res", set Text to  "INGRESADO CORRECTAMENTE";
            if (rowsInserted == 1)
            {
                res.Attributes.Add("class", "alert alert-success");
                res.Attributes.Add("role", "alert");
                res.Text = "DIAGNOSTICADO CON EXITO";
                res.ForeColor = System.Drawing.Color.Green;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                txtSerial.Focus();
            }

            else if (rowsInserted == 2)
            {
                res.Attributes.Add("class", "alert alert-danger");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER  DIAGNOSTICADO";
                res.ForeColor = System.Drawing.Color.Orange;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }

            else if (rowsInserted == 3)
            {
                res.Attributes.Add("class", "alert alert-primary font-weight-bold");
                res.Attributes.Add("role", "alert");
                res.Text = "DRIVER REPARADO";
                res.ForeColor = System.Drawing.Color.Blue;
                lblSN.Text = dataScan;
                txtSerial.Text = "";
                // txtCodeDefect.Text = "";
                txtSerial.Focus();
            }
            else if (rowsInserted == 4)
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
            lblFalla.Text = "";
            lblValor.Text = "";
            lblUSER.Text = "";
            lblDATE.Text = "";
            
            btnSave.Visible = false;
            btnCancel.Visible = false;
            Label4.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            txtDiag.Visible = false;
            txtLoc.Visible = false;
            //txtValue.Visible = false;
            data4.Visible = false;
            data5.Visible = false;
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
            txtDiag.Visible = false;
            txtLoc.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false; 
            Label3.Visible = false;
            Label4.Visible = false;
            txtLoc.Text = "";
            txtDiag.Text = "";
            lblSN.Text = "";
            lblWO.Text = "";
            lblMOD.Text = "";
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