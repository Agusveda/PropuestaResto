using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace PropuestaResto
{
    public partial class PantallaMontoPorFechas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            ReporteNegocio negocio = new ReporteNegocio();
            gvMontoPorFechas.DataSource = negocio.ObtenerMontoTotalPorFecha();
            gvMontoPorFechas.DataBind();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
           // Exportacion a excel..... 
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MontoPorFechas.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvMontoPorFechas.AllowPaging = false;
                CargarDatos(); 

                gvMontoPorFechas.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}
