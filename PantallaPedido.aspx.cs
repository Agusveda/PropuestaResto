﻿using Negocio;
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
            Insumo insu = negocio.ListarConSp().Find(i => i.IdInsumo == idInsumo);

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

            List<Insumo> pedidoTemporal = (List<Insumo>)Session["PedidoTemporal"];
            Insumo insumoAEliminar = pedidoTemporal.Find(i => i.IdInsumo == idInsumo);
            if (insumoAEliminar != null)
            {
                pedidoTemporal.Remove(insumoAEliminar); // nota: remove elimina el insumo elegido
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
