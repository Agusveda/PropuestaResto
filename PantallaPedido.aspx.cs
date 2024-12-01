using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace PropuestaResto
{
    public partial class PantallaPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdMesa = int.Parse(Request.QueryString["IdMesa"].ToString());
            lbIdMesa.Text = "Mesa número: " + IdMesa;

            if (!IsPostBack)
            {
                CargarInsumos();
                Session["PedidoTemporal"] = new List<Insumo>();
                CargarDetallePedido();
            }
        }

        private void CargarInsumos()
        {
            InsumoNegocio negocio = new InsumoNegocio();
            repInsumos.DataSource = negocio.ListarConSp();
            repInsumos.DataBind();
        }

        private void CargarDetallePedido()
        {
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            repDetallePedido.DataSource = pedidoTemporal;
            repDetallePedido.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);

            InsumoNegocio negocio = new InsumoNegocio();
            Insumo insu = negocio.ListarConSp().Find(i => i.IdInsumo == idInsumo); // nota: metodo FIND busca en la lista lo que coincida con lo q definas

            if (insu != null)
            {
                List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
                pedidoTemporal.Add(insu);
                Session["PedidoTemporal"] = pedidoTemporal;
                CargarDetallePedido();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);

            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumoAEliminar = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
            if (insumoAEliminar != null)
            {
                pedidoTemporal.Remove(insumoAEliminar);
                Session["PedidoTemporal"] = pedidoTemporal;
                CargarDetallePedido();
            }
        }

        protected void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
        }
    }
}
