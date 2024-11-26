using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropuestaResto
{
    public partial class PantallaPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // int idmesa = int.Parse(Session["IdMesa"].ToString()); con sesion


            int IdMesa = int.Parse(Request.QueryString["IdMesa"].ToString());
            lbIdMesa.Text = "Mesa numero : " + IdMesa;

            CargarInsumos();

        }





        private void CargarInsumos()
        {
            // lista actuales
            /// configuracion si estamos agregando 
            InsumoNegocio negocio = new InsumoNegocio();
            repInsumos.DataSource = negocio.ListarConSp();
            repInsumos.DataBind();

            //desplegable de los tipos de insumo
            //ddlTipoInsumos.DataSource = negocio.ListarTipoInsumo();
            //ddlTipoInsumos.DataValueField = "IdTipoInsumo";
            //ddlTipoInsumos.DataTextField = "DescripcionTipo";
            //ddlTipoInsumos.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
    }