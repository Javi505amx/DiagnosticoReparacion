using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticoReparacion
{
    public partial class MenuConsultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userlabel.Visible = true;
            userlabel.Text = Session["user"].ToString();
        }
    }
}