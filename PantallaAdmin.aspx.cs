using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PropuestaResto
{
    public partial class PantallaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divAltaInsumo.Visible = false;
        }

       
        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            InsumoNegocio negocio = new InsumoNegocio();
            dgvInsumos.DataSource = negocio.ListarConSp();
            dgvInsumos.DataBind();
            divAltaInsumo.Visible = true;


        }
    }
}