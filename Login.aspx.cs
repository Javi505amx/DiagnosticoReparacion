using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DiagnosticoReparacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        public void saveDataUser()
        {
            string username;
            username = txtUsuario.Text;
            Session["user"] = txtUsuario.Text;
            Session["userLogin"] = lblUser.Text;
            Session["password"] = txtPassword.Text;

            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection cn = new SqlConnection(conect);
            SqlCommand cmd = new SqlCommand("GetFullName", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();
            string fullName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FullName"));
            cn.Close();
            Session["fullName"] = fullName;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Conexion con la base de datos 
            string conect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conect);
            SqlCommand cmd = new SqlCommand("ValidateUser", sqlCon)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Connection.Open();//pasar valores a procedimiento almacenado "Validate USER"
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUsuario.Text;
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int result = dr.GetInt32(dr.GetOrdinal("Users"));
            sqlCon.Close();
            if (result > 0)
            {//valida si usuario es admin
                SqlConnection sqlConAdmin = new SqlConnection(conect);
                SqlCommand cmdAdmin = new SqlCommand("ValidateUserAdmin", sqlConAdmin)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmdAdmin.Connection.Open();
                cmdAdmin.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUsuario.Text;
                cmdAdmin.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                SqlDataReader drAdmin = cmdAdmin.ExecuteReader();
                drAdmin.Read();
                int resultAdmin = drAdmin.GetInt32(drAdmin.GetOrdinal("Users"));
                cmdAdmin.Connection.Close();
                Session["UserAdmin"] = resultAdmin;
                saveDataUser();
                Response.Redirect("Menu.aspx");
            }
            else
            {
                labelwrong.Text = "Usuario o contraseña incorrectos";
                labelwrong.ForeColor = System.Drawing.Color.PaleVioletRed;
                txtUsuario.Text = "";
                txtUsuario.Focus();
            }
            cmd.Connection.Close();
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}