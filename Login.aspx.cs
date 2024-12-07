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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();


            try
            {

              usuario.NombreUsuario = txtuser.Text;
                usuario.Password= txtPassword.Text;
                if(negocio.loguear(usuario) )
                {
                    Session.Add("Usuario", usuario);

                    Response.Redirect("Default.aspx");


                }
                else
                {
                    Session.Add("error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx");

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}