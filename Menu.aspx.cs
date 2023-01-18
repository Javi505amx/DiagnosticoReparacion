using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticoReparacion
{
    public partial class Menu : System.Web.UI.Page
    {
        private const bool V = true;
        private const bool F = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Visible = true;
            userlabel.Text = Session["user"].ToString();

            if (Session["UserAdmin"].ToString() == "1")
            {
                btnConsulta.Visible= true;
                btnDiagnostico.Visible= true;  
                btnReparacion.Visible = true;
                btnUsuarios.Visible= true;
                btnScrap.Visible= true;
                btnScrapSalida.Visible = true;
                btnDiagnostico.Visible = true;
                btnDiagnostico2.Visible = true;
            }
            else if(Session["UserAdmin"].ToString() == "0")
            {
                btnDiagnostico.Visible = true;
                btnReparacion.Visible = true;
                btnDiagnostico2.Visible = true;
                btnScrap.Visible = true;
                btnConsulta.Visible = true;
            }



        }
    }
}