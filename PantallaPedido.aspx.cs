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

                if (pedidoActual != null) // si no es nulo, cargo el pedido 
                {
                    Session["IdPedidoActual"] = pedidoActual.IdPedido; // asigno el idpedido actual 

                    if (Session["PedidoTemporal"] == null || ((List<Insumo>)Session["PedidoTemporal"]).Count == 0) // si es nulo y la lista tiene 0 registros
                    {
                        Session["PedidoTemporal"] = negocio.ObtenerDetallePedidoPorId(pedidoActual.IdPedido); // cargo los insumos del pedido por el idpedido
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
            Session.Add("ListaInsumos", negocio.ListarConSp());
            repInsumos.DataSource = Session["ListaInsumos"];
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
            PedidoNegocio negociopedido = new PedidoNegocio();
            InsumoNegocio negocio = new InsumoNegocio();
            Insumo insu = negocio.ListarConSp().Find(i => i.IdInsumo == idInsumo); // nota: busca en la lista. 

            if (insu != null)
            {
                if (insu.Cantidad <= 0)
                {

                    return;
                }
                List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
                Insumo insumoExistente = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
                    negociopedido.RestarCantidadEnInsumos(insu.IdInsumo, 1);

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
                CargarInsumos();
            }
        }

        protected void btnAumentar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);
            PedidoNegocio negociopedido = new PedidoNegocio();
            InsumoNegocio negocio = new InsumoNegocio();
            Insumo insu = negocio.ListarConSp().Find(i => i.IdInsumo == idInsumo);
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumo = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);

            if (insumo != null)
            {
                if (insu.Cantidad <= 0) 
                {
                    return;
                }

                    insumo.Cantidad += 1;
                negociopedido.RestarCantidadEnInsumos(idInsumo, 1);
                CargarDetallePedido();
                CargarInsumos();
            }
        }

        protected void btnDisminuir_Click(object sender, EventArgs e)
        {
            // declaracion de variables
            PedidoNegocio negociopedido = new PedidoNegocio();

            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);
            PedidoNegocio negocio = new PedidoNegocio();
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumo = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);


            // validaciones

            if (insumo != null)
            {
                insumo.Cantidad -= 1; // rest a la cantida 1

                if (insumo.Cantidad <= 0)
                {

                    pedidoTemporal.Remove(insumo); // Eliminar del list si la cantidad es 0
                    negocio.SumarCantidadEnInsumos(idInsumo, insumo.Cantidad);


                    if (Session["IdPedidoActual"] != null)
                    {
                    int idpedido = (int)Session["IdPedidoActual"];
                    negocio.EliminarInsumoDelPedido(idInsumo, idpedido);

                    }
                }

                negociopedido.SumarCantidadEnInsumos(insumo.IdInsumo, 1);
                CargarInsumos();
                CargarDetallePedido(); //cargo de nuevo el detall del opedido
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // declaración de variables
            Button btn = (Button)sender;
            int idInsumo = int.Parse(btn.CommandArgument);
            PedidoNegocio negocio = new PedidoNegocio();
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumoAEliminar = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);

            
            if (insumoAEliminar != null)
            {

                pedidoTemporal.Remove(insumoAEliminar); // Elimina del pedido temporal
                Session["PedidoTemporal"] = pedidoTemporal; 
                negocio.SumarCantidadEnInsumos(insumoAEliminar.IdInsumo, insumoAEliminar.Cantidad);

            // si el pedido ya fue creado ahi si puedo eliminar de bd, sino, solo interactua con el temporal (sin idpedido, sin iddetale)
                if (Session["IdPedidoActual"] != null)
                {
                    int idPedido = (int)Session["IdPedidoActual"];
                    negocio.EliminarInsumoDelPedido(idInsumo, idPedido); // Elimina de la base de datos
                }
                CargarDetallePedido();
                CargarInsumos();
            }
        }


        protected void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            MesaNegocio mesaNegocio = new MesaNegocio();
            Usuario user = (Usuario)Session["usuario"];

            if (Session["IdPedidoActual"] == null)
            {
                Pedido nuevoPedido = new Pedido
                {
                    IdMesa = IdMesa,
                    IdUsuario = user.IdUsuario,
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

                // finalizo el pedido seteo finalizado igual a 1 
                negocio.FinalizarPedido(idPedido);




                // pongo en false la mesa ya que no tiene pedidos.
                mesaNegocio.ActualizarMesa(IdMesa, false);

                // Limpiar la sesión
                Session["IdPedidoActual"] = null;
                Session["PedidoTemporal"] = null;
                Session.Add("IdPedidoFinal", idPedido);


                Response.Redirect("PantallaFinalizarPedido.aspx");
            }

            // esta funcion de java script me funciona para mostrar mensajes emergentes.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Por favor, confirme el pedido antes de finalizarlo.');", true);


        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {

            List<Insumo> lista = (List<Insumo>)Session["ListaInsumos"];

            List<Insumo> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repInsumos.DataSource = listaFiltrada;
            repInsumos.DataBind();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaMesas.aspx", false);
        }
    }
}

