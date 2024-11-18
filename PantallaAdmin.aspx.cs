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
        }

        //                                      ABM DE INSUMOSSSSS 
        protected void btnAbmInsumos_Click(object sender, EventArgs e)
        {
            // lista actuales
            /// configuracion si estamos agregando 
            InsumoNegocio negocio = new InsumoNegocio();
            repInsumos.DataSource = negocio.ListarConSp();
            repInsumos.DataBind();

            //desplegable de los tipos de insumo
            ddlTipoInsumos.DataSource = negocio.ListarTipoInsumo();
            ddlTipoInsumos.DataValueField = "IdTipoInsumo";
            ddlTipoInsumos.DataTextField = "DescripcionTipo";
            ddlTipoInsumos.DataBind();


            //visibilidad 
            ABMINSUMOS.Visible = true;
            divAltaInsumo.Visible = false;
            btnAceptarModificarInsumo.Visible = false;
            ABMUSUARIOS.Visible = false;
          

            /// configuracion si estamos modificando




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
        protected void btnModificar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(((Button)sender).CommandArgument);

            InsumoNegocio negocio = new InsumoNegocio();
            List<Insumo> lista = negocio.ListarXId(id);

            Insumo seleccionado = lista[0];

            // pre cargar campos..

            ddlTipoInsumos.DataSource = negocio.ListarTipoInsumo();
            ddlTipoInsumos.DataValueField = "IdTipoInsumo";
            ddlTipoInsumos.DataTextField = "DescripcionTipo";

            txtIdInsumo.Text = id.ToString();
            txtDescripcionInsumo.Text = seleccionado.Descripcion;
            txtCantidadInsumo.Text = seleccionado.Cantidad.ToString();
            txtPrecioInsumo.Text = seleccionado.Precio.ToString();
            ddlTipoInsumos.SelectedValue = seleccionado.IdTipoInsumo.IdtipoInsumo.ToString();
            ddlTipoInsumos.DataBind();
            ABMINSUMOS.Visible = true;
            divAltaInsumo.Visible = true;
            btnAceptarAgregarInsumo.Visible = false;
            btnAceptarModificarInsumo.Visible = true;






        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Insumo insumo = new Insumo();
                InsumoNegocio negocio = new InsumoNegocio();

                int id = int.Parse(((Button)sender).CommandArgument);

                negocio.BajaLogicaInsumo(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnAltaInsumo_Click(object sender, EventArgs e)
        {

            /// VISUALIZACION


            InsumoNegocio negocio = new InsumoNegocio();


            txtDescripcionInsumo.Text = "";
            txtCantidadInsumo.Text = "";
            txtPrecioInsumo.Text = "";
            ddlTipoInsumos.DataSource = negocio.ListarTipoInsumo();
            ddlTipoInsumos.DataValueField = "IdTipoInsumo";
            ddlTipoInsumos.DataTextField = "DescripcionTipo";
            ddlTipoInsumos.DataBind();
            ABMINSUMOS.Visible = true;
            divAltaInsumo.Visible = true;
            btnAceptarAgregarInsumo.Visible = true;
            btnAceptarModificarInsumo.Visible = false;


        }
        protected void btnAceptarModificarInsumo_Click(object sender, EventArgs e)
        {

            try
            {
                Insumo modificado = new Insumo();
                InsumoNegocio negocio = new InsumoNegocio();

                modificado.IdInsumo = int.Parse(txtIdInsumo.Text);
                modificado.Descripcion = txtDescripcionInsumo.Text;
                modificado.Cantidad = int.Parse(txtCantidadInsumo.Text);
                modificado.Precio = int.Parse(txtPrecioInsumo.Text);

                modificado.IdTipoInsumo = new TipoInsumo();
                modificado.IdTipoInsumo.IdtipoInsumo = int.Parse(ddlTipoInsumos.SelectedValue);

                negocio.ModificarInsumo(modificado);



            }
            catch (Exception ex)
            {

                throw ex; 
            }


        }

        //                                      FIN DE ABM DE INSUMOS


        
        
        
        //                                      ABM DE MESEROS

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtAppelido.Text = "";
            chkEsadmin.Checked = false;
            btnAceptarModificarUsuario.Visible = true;
            divAltaUsuario.Visible = true;
            ABMINSUMOS.Visible = false;
            




        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            MeseroNegocio negocio = new MeseroNegocio();
            List<Usuario> lista = negocio.ListarXId(id);

            Usuario seleccionado = lista[0];

            // pre cargar campos..
            txtNombreUsuario.Text = seleccionado.NombreUsuario;
            txtPassword.Text = seleccionado.Password;
            txtNombre.Text = seleccionado.Nombre;
            txtAppelido.Text = seleccionado.Apellido;
            
            if (seleccionado.EsAdmin == true)
            {
                chkEsadmin.Checked = true;
            }
            else
            {
                chkEsadmin.Checked = false;
            }
            divAltaUsuario.Visible = true;
            btnAceptarAgregarUsuario.Visible = false;
            btnAceptarModificarUsuario.Visible = true;




        }

        protected void btnAbmUsuarios_Click(object sender, EventArgs e)
        {
            ABMUSUARIOS.Visible = true;
            divAltaUsuario.Visible = false;
            btnAceptarModificarUsuario.Visible = false;
            MeseroNegocio negocio = new MeseroNegocio();
            ABMINSUMOS.Visible = false;



            repUsuarios.DataSource = negocio.ListarUsuarios();
            repUsuarios.DataBind();


        }

      

        protected void btnAceptarModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                MeseroNegocio negocio = new MeseroNegocio();
                Usuario nuevo = new Usuario();

                nuevo.NombreUsuario = txtNombreUsuario.Text;
                nuevo.Password = txtPassword.Text;
                nuevo.Nombre= txtNombre.Text;
                nuevo.Apellido= txtAppelido.Text;
                
                if (chkEsadmin.Checked == true)
                {
                    nuevo.EsAdmin = true;
                }
                else
                {
                    nuevo.EsAdmin= false;
                }

                


                negocio.AgregarUsuario(nuevo);
                Response.Redirect("PantallaAdmin.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                MeseroNegocio negocio = new MeseroNegocio();
                Usuario nuevo = new Usuario();

                nuevo.NombreUsuario = txtNombreUsuario.Text;
                nuevo.Password = txtPassword.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtAppelido.Text;

                if (chkEsadmin.Checked == true)
                {
                    nuevo.EsAdmin = true;
                }
                else
                {
                    nuevo.EsAdmin = false;
                }




                negocio.AgregarUsuario(nuevo);
                Response.Redirect("PantallaAdmin.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}