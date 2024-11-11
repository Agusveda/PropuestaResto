using Dominio;
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
            // lista actuales

            InsumoNegocio negocio = new InsumoNegocio();
            dgvInsumos.DataSource = negocio.ListarConSp();
            dgvInsumos.DataBind();

            //desplegable de los tipos de insumo
            ddlTipoInsumos.DataSource = negocio.ListarTipoInsumo();
            ddlTipoInsumos.DataValueField = "IdTipoInsumo";
            ddlTipoInsumos.DataTextField = "DescripcionTipo";
            ddlTipoInsumos.DataBind();


            //visibilidad 
            divAltaInsumo.Visible = true;




        }

        protected void btnAceptarAgregarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                InsumoNegocio negocio = new InsumoNegocio();
                Insumo nuevo = new Insumo();

                nuevo.Descripcion = txtDescripcionInsumo.Text;
                nuevo.Cantidad = int.Parse(txtCantidadInsumo.Text);
                nuevo.Precio= int.Parse(txtPrecioInsumo.Text);

                nuevo.IdTipoInsumo = new TipoInsumo();
                nuevo.IdTipoInsumo.IdtipoInsumo = int.Parse(ddlTipoInsumos.SelectedValue);

                negocio.AgregarInsumo(nuevo);
                Response.Redirect("PantallaAdmin.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}