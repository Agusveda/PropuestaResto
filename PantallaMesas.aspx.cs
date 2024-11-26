using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropuestaResto
{
    public partial class PantallaMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarMesa();


        }

        public void CargarMesa() 
        { 
            
            MesaNegocio negocio = new MesaNegocio();
            rptMesas.DataSource = negocio.listarMesas();
            rptMesas.DataBind();

        
        
        }

        protected void BtnAgregarPedido_Click(object sender, EventArgs e)
        {
            int idMesa = int.Parse(((Button)sender).CommandArgument);


            Session.Add("IdMesa", idMesa); // CREO LA SESION PARA EL IDMESA

            Response.Redirect("PantallaPedido.aspx",false);

        }

        protected void btnEliminarPedido_Click(object sender, EventArgs e)
        {

        }
    }
}