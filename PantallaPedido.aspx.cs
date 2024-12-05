using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Linq;

namespace PropuestaResto
{
    public partial class PantallaPedido : System.Web.UI.Page
    {
        public int idpedido {  get; set; }
        int IdMesa;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdMesa = int.Parse(Request.QueryString["IdMesa"].ToString());
            lbIdMesa.Text = "Mesa número: " + IdMesa;

            
            if (Session["IdMesaActual"] == null || (int)Session["IdMesaActual"] != IdMesa) // compruebo q la mesa que se ingresa es dintinta a la mesa de sesion
            {

                Session["IdMesaActual"] = IdMesa; // envio sesion de mesa actual

                Session["IdPedidoActual"] = null;
                Session["PedidoTemporal"] = null;
            }

            if (!IsPostBack)
            {
                CargarInsumos();

                PedidoNegocio negocio = new PedidoNegocio();
                Pedido pedidoActual = negocio.ObtenerPedidoActivoPorMesa(IdMesa);

                if (pedidoActual != null)
                {
                    Session["IdPedidoActual"] = pedidoActual.IdPedido;

                    if (Session["PedidoTemporal"] == null || ((List<Insumo>)Session["PedidoTemporal"]).Count == 0)
                    {
                        Session["PedidoTemporal"] = negocio.ObtenerDetallePedidoPorId(pedidoActual.IdPedido);
                    }
                    idpedido = pedidoActual.IdPedido;
                }
                else
                {
                    Session["PedidoTemporal"] = new List<Insumo>();
                }

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
            Insumo insu = negocio.ListarConSp().Find(i => i.IdInsumo == idInsumo); // nota: busca en la lista. 

            if (insu != null)
            {
                List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];

                Insumo insumoExistente = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
                if (insumoExistente != null)
                {
          
                    insumoExistente.Cantidad += 1;
                }
                else
                {
               
                    insu.Cantidad = 1;
                    pedidoTemporal.Add(insu);
                }

                Session["PedidoTemporal"] = pedidoTemporal;
                CargarDetallePedido();
            }
        }

        protected void btnAumentar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);

            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumo = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
            if (insumo != null)
            {
                insumo.Cantidad += 1;
                CargarDetallePedido();
            }
        }

        protected void btnDisminuir_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);

            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumo = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
            if (insumo != null)
            {
                insumo.Cantidad -= 1;
                if (insumo.Cantidad <= 0)
                {
                    pedidoTemporal.Remove(insumo); // Eliminar si la cantidad es 0
                }
                CargarDetallePedido();
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);
            
            

            // ELIMINO LOGICAMENTE PARA ASEGURARME QUE NO VUELVA A APARECER EL PDIDO, VINCU
            PedidoNegocio negocio = new PedidoNegocio();
            /// traigo el idinsumo
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumoAEliminar = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
         
            if (insumoAEliminar != null)
            {
                pedidoTemporal.Remove(insumoAEliminar); // nota: remove elimina el insumo elegido de sesion
                Session["PedidoTemporal"] = pedidoTemporal;
                CargarDetallePedido();
                negocio.EliminarInsumoDelPedido(idInsumo, idpedido);
            }
            else
            {
            negocio.EliminarInsumoDelPedido(idInsumo,); // Elimino logicamente para que no aparezca luego en la lista temporal o la lista normal

            }


        }

        protected void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            MesaNegocio mesaNegocio = new MesaNegocio();

            if (Session["IdPedidoActual"] == null)
            {
                Pedido nuevoPedido = new Pedido
                {
                    IdMesa = IdMesa,
                    IdUsuario = 1,
                    Precio = pedidoTemporal.Sum(i => i.Precio * i.Cantidad),
                    Finalizado = false
                };

                pedidoNegocio.AgregarPedido(nuevoPedido);
                int idPedido = pedidoNegocio.ObtenerUltimoIdPedido();
                Session["IdPedidoActual"] = idPedido;
            }
            else
            {
                int idPedido = (int)Session["IdPedidoActual"];
                pedidoNegocio.ActualizarPrecioPedido(idPedido, pedidoTemporal.Sum(i => i.Precio * i.Cantidad));
            }

            int idpedido = (int)Session["IdPedidoActual"];
            foreach (Insumo insu in pedidoTemporal)
            {
                pedidoNegocio.AgregarDetallePedido(insu, idpedido);
            }

            mesaNegocio.ActualizarMesa(IdMesa, true);

            CargarDetallePedido();
            Response.Redirect("PantallaMesas.aspx");
        }



        protected void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (Session["IdPedidoActual"] != null)
            {
                int idPedido = (int)Session["IdPedidoActual"];
                PedidoNegocio negocio = new PedidoNegocio();
                MesaNegocio mesaNegocio = new MesaNegocio();

                negocio.FinalizarPedido(idPedido);

            
                mesaNegocio.ActualizarMesa(IdMesa, false);

                // Limpiar la sesión
                Session["IdPedidoActual"] = null;
                Session["PedidoTemporal"] = null;

                Response.Redirect("PantallaMesas.aspx");
            }
        }

    }
}

