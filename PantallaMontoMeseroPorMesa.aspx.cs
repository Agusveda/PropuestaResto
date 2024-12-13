using Negocio;
using System;
using System.Web.UI;

namespace PropuestaResto
{
    public partial class PantallaMontoMeseroPorMesa : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).EsAdmin == true))
            {
                Session.Add("error", "No tenes permisos para ingresar a esta pantalla, debes ser admin");
                Response.Redirect("Error.aspx", false);
            }
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            ReporteNegocio negocio = new ReporteNegocio();
            var lista = negocio.ObtenerMeseroPorMesaTotal();

            gvMeseroPorMesa.DataSource = lista;
            gvMeseroPorMesa.DataBind();
        }
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Configuración para exportar a Excel
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MontoMeseroPorMesa.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvMeseroPorMesa.AllowPaging = false;
                CargarDatos();

                gvMeseroPorMesa.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Este método es necesario para que el GridView se pueda exportar correctamente
        }

    }
}
