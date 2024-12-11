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
    public partial class PantallaReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPedidosMesa_Click(object sender, EventArgs e)
        {
            // Mostrar secciones relacionadas con Mesa
            divPedidoxMesa.Visible = true;
            repPedidosMesa.Visible = true;
            divMESAS.Visible = true;

            // Ocultar secciones relacionadas con Mesero
            DIVMESERO.Visible = false;
            rptPedidosMesero.Visible = false;
            divPedidosXMesero.Visible = false;

            // Reiniciar etiquetas de totales
            lbTotal.Visible = true;
            lblTotalmesero.Visible = false;
        }

        protected void btnPedidosMesero_Click(object sender, EventArgs e)
        {
            // Mostrar secciones relacionadas con Mesero
            DIVMESERO.Visible = true;
            divPedidosXMesero.Visible = true;
            rptPedidosMesero.Visible = true;

            // Ocultar secciones relacionadas con Mesa
            divPedidoxMesa.Visible = false;
            repPedidosMesa.Visible = false;
            divMESAS.Visible = false;

            // Reiniciar etiquetas de totales
            lblTotalmesero.Visible = true;
            lbTotal.Visible = false;
        }


        protected void ConfirmarPedidosMesa_Click(object sender, EventArgs e)
        {
            int idmesa = int.Parse(txtIdMesa.Text); 
            ReporteNegocio negocio = new ReporteNegocio();
            List<Pedido> listaPedidoMesa = new List<Pedido>();
            listaPedidoMesa = negocio.ObtenerDetallePedidoPorMesa(idmesa);

            decimal totalPrecio = listaPedidoMesa.Sum( p => p.Precio);

            lblTotalPrecio.Text = totalPrecio.ToString();
            lbTotal.Visible = true;
            lblTotalmesero.Visible = false;


            repPedidosMesa.DataSource = listaPedidoMesa;
            repPedidosMesa.DataBind();

        }

        protected void ConfirmarPedidosMesero_Click(object sender, EventArgs e)
        {
            int idmesero = int.Parse(txtidMesero.Text);
            ReporteNegocio negocio = new ReporteNegocio();
            List<PedidoReporte> listaPedidoMesero = new List<PedidoReporte>();
            listaPedidoMesero = negocio.ObtenerPedidoPorMesero(idmesero);

            decimal totalpreciomesero = listaPedidoMesero.Sum(p => p.Precio);
            lblTotalPrecioMesero.Text = totalpreciomesero.ToString();
            lblTotalmesero.Visible = true;
            lbTotal.Visible = false;


            rptPedidosMesero.DataSource = listaPedidoMesero;
            rptPedidosMesero.DataBind();

        }
    }
}