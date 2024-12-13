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

            if (!( Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).EsAdmin == true))
            {
                Session.Add("error", "No tenes permisos para ingresar a esta pantalla, debes ser admin");
                Response.Redirect("Error.aspx", false);
            }
        }

        //                                      ABM DE INSUMOSSSSS 
        protected void btnAbmInsumos_Click(object sender, EventArgs e)
        {

            CargarInsumos();
        } // carga vista de insumos
        protected void btnAceptarAgregarInsumo_Click(object sender, EventArgs e)
        {
   

            try
            {

                Page.Validate();
                if (!Page.IsValid)
                    return;

                InsumoNegocio negocio = new InsumoNegocio();
                Insumo nuevo = new Insumo();

                nuevo.Descripcion = txtDescripcionInsumo.Text;
                nuevo.Cantidad = int.Parse(txtCantidadInsumo.Text);
                nuevo.Precio= int.Parse(txtPrecioInsumo.Text);

                nuevo.IdTipoInsumo = new TipoInsumo();
                nuevo.IdTipoInsumo.IdtipoInsumo = int.Parse(ddlTipoInsumos.SelectedValue);

                negocio.AgregarInsumo(nuevo);
                CargarInsumos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        } // confirmacion de nuevo insumo
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






        } // para modificar un insumo
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Insumo insumo = new Insumo();
                InsumoNegocio negocio = new InsumoNegocio();

                int id = int.Parse(((Button)sender).CommandArgument);

                negocio.BajaLogicaInsumo(id);
                CargarInsumos();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        } // baja logica insumo
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



        } // muestro el formulario de alta de insumo
        protected void btnAceptarModificarInsumo_Click(object sender, EventArgs e)
        {

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Insumo modificado = new Insumo();
                InsumoNegocio negocio = new InsumoNegocio();

                modificado.IdInsumo = int.Parse(txtIdInsumo.Text);
                modificado.Descripcion = txtDescripcionInsumo.Text;
                modificado.Cantidad = int.Parse(txtCantidadInsumo.Text);
                modificado.Precio = decimal.Parse(txtPrecioInsumo.Text);

                modificado.IdTipoInsumo = new TipoInsumo();
                modificado.IdTipoInsumo.IdtipoInsumo = int.Parse(ddlTipoInsumos.SelectedValue);

                negocio.ModificarInsumo(modificado);
                CargarInsumos();



            }
            catch (Exception ex)
            {

                throw ex; 
            }


        } // confirmo la modificacion del insumo
        private void CargarInsumos() 
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
            divASIGNACIONMESA.Visible = false;
            divAltaNuevotipoInsumo.Visible = false;


        } // carga los insumos actuales.

        //                                      FIN DE ABM DE INSUMOS





        //                                      ABM DE MESEROS/USUARIOS

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtAppelido.Text = "";
            chkEsadmin.Checked = false;
            btnAceptarAgregarUsuario.Visible = true;
            divAltaUsuario.Visible = true;
            ABMINSUMOS.Visible = false;
            divAltaNuevotipoInsumo.Visible = false;
            




        }
        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> lista = negocio.ListarXId(id);

            Usuario seleccionado = lista[0];

            // pre cargar campos..
            txtIdUsuario.Text = seleccionado.IdUsuario.ToString();
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

            CargarUsuario();

        }
        protected void btnAceptarModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario nuevo = new Usuario();
                nuevo.IdUsuario = int.Parse(txtIdUsuario.Text);

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

                


                negocio.ModificarUsuario(nuevo);
                btnAceptarModificarUsuario.Visible = false;
                CargarUsuario();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                int id = int.Parse(((Button)sender).CommandArgument);

                negocio.BajaLogicaUsuario(id);

                CargarUsuario(); 
             

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void CargarUsuario()
        {
            ABMUSUARIOS.Visible = true;
            divAltaUsuario.Visible = false;
            btnAceptarModificarUsuario.Visible = false;
            UsuarioNegocio negocio = new UsuarioNegocio();
            ABMINSUMOS.Visible = false;
            divASIGNACIONMESA.Visible = false;
            divAltaNuevotipoInsumo.Visible = false;



            repUsuarios.DataSource = negocio.ListarUsuarios();
            repUsuarios.DataBind();
        }
        protected void btnAceptarAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuarioNegocio negocio = new UsuarioNegocio();
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
                CargarUsuario();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        //                                      FIN DE ABM DE MESEROS/USUARIOS




        //                                      ASIGNACION DE MESA
        protected void btnAsignacionMesa_Click(object sender, EventArgs e)
        {
            CargarMesasDisponibles();

            ABMINSUMOS.Visible = false;
            divAltaInsumo.Visible = false;
            btnAceptarModificarInsumo.Visible = false;
            ABMUSUARIOS.Visible = false;
            divAltaNuevotipoInsumo.Visible = false;




        }

        private void CargarMesasDisponibles()
        {
            divASIGNACIONMESA.Visible = true;
            MesaNegocio mesaNegocio = new MesaNegocio();
            List<MesaUsuario> mesas = mesaNegocio.listarMesasMeseros();

            UsuarioNegocio usuNegocio= new UsuarioNegocio();
            Session["MeserosDisponibles"] = usuNegocio.ListarUsuariosMeseros();

            repMesasDisponibles.DataSource = mesas;
            repMesasDisponibles.DataBind();
        }
       
        protected void btnAsignarMeseroMesa_Click(object sender, EventArgs e)
        {
            int idMesa = int.Parse(((Button)sender).CommandArgument);

            txtIdMesa.Text = idMesa.ToString();
            
            divAsignacionMesero.Visible = true;
            UsuarioNegocio negocio = new UsuarioNegocio();
            ddlMeseros.DataSource = negocio.ListarUsuariosMeseros();
            ddlMeseros.DataTextField = "Nombre";
            ddlMeseros.DataValueField = "IdUsuario";
            ddlMeseros.DataBind();


        }

        protected void btnConfirmarAsignarMesero_Click(object sender, EventArgs e)
        {

            MesaNegocio negocio = new MesaNegocio();

            int idMesero = int.Parse(ddlMeseros.SelectedItem.Value);
            int idmesa = int.Parse(txtIdMesa.Text);

            negocio.ActualizarMeseroAsignado(idmesa, idMesero);
            divAsignacionMesero.Visible = false;
            CargarMesasDisponibles();

        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {

            Response.Redirect("PantallaReportes.aspx", false);


        }


        protected void btnNuevoInsumo_Click(object sender, EventArgs e)
        {
            divAltaNuevotipoInsumo.Visible = true;
            InsumoNegocio negocio = new InsumoNegocio();


            //desplegable de los tipos de insumo
            ddlTipoInsumoActuales.DataSource = negocio.ListarTipoInsumo();
            ddlTipoInsumoActuales.DataValueField = "IdTipoInsumo";
            ddlTipoInsumoActuales.DataTextField = "DescripcionTipo";
            ddlTipoInsumoActuales.DataBind();
            ABMINSUMOS.Visible = false;
            ABMUSUARIOS.Visible = false;
            divASIGNACIONMESA.Visible = false;

        }

        protected void btnConfirmacionNuevoTipoInsumo_Click(object sender, EventArgs e)
        {

            InsumoNegocio negocio = new InsumoNegocio();
            TipoInsumo nuevo = new TipoInsumo();


            nuevo.Descripciontipo = txtDescripcionNuevoTipoInsumo.Text;

            negocio.AgregarTipoInsumo(nuevo);




        }

        protected void btncancelarTipoInsumoNuevo_Click(object sender, EventArgs e)
        {
            divAltaNuevotipoInsumo.Visible=false;

        }

        
    }
}