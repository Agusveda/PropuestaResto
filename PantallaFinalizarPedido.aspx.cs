using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Negocio;


namespace PropuestaResto
{
    public partial class PantallaFinalizarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int idpedido = (int)Session["IdPedidoFinal"];
            PedidoNegocio negocio = new PedidoNegocio();

            dgvPedidoFinal.DataSource = negocio.ObtenerPedidoCompletoPorIdPedido(idpedido);
            dgvPedidoFinal.DataBind();






        }

        protected void btnImprimirpdf_Click(object sender, EventArgs e)
        {
            if (Session["IdPedidoFinal"] == null)
            {
                Response.Write("<script>alert('No hay un pedido seleccionado.');</script>");
                return;
            }

            int idpedido = (int)Session["IdPedidoFinal"];
            PedidoNegocio negocio = new PedidoNegocio();
            List<PedidoFinalizado> listaPedido = negocio.ObtenerPedidoCompletoPorIdPedido(idpedido);


            //limpio todos los insumos de detallepedido para asegurar de que no se traigan registros.
            PedidoNegocio negocioPedido = new PedidoNegocio();
            negocioPedido.EliminarTodosInsumosDelPedido(idpedido);

            // Validar si hay datos
            if (listaPedido == null || listaPedido.Count == 0)
            {
                Response.Write("<script>alert('No se encontraron datos para el pedido.');</script>");
                return;
            }

            // Crear documento PDF
            Document document = new Document(PageSize.A4);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Agregar logo
            string imagePath = Server.MapPath("~/Logo.png");
            if (File.Exists(imagePath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagePath);
                logo.ScaleToFit(200f, 100f);
                logo.Alignment = Element.ALIGN_CENTER;
                document.Add(logo);
            }

            // Título del documento
            Font titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            Paragraph title = new Paragraph("Detalle del Pedido", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Información del pedido
            Font textFont = FontFactory.GetFont("Arial", 12);
            document.Add(new Paragraph($"Pedido ID: {idpedido}", textFont));
            document.Add(new Paragraph($"Fecha: {listaPedido[0].FechaHora.ToString("dd/MM/yyyy HH:mm")}", textFont));
            document.Add(new Paragraph($"Total: ${listaPedido[0].PrecioTotal}", textFont));
            document.Add(new Paragraph("\n"));

            // Crear tabla para los detalles del pedido
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3f, 1f, 2f, 2f });

            // Encabezados de la tabla
            Font headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE);
            PdfPCell headerCell;

            headerCell = new PdfPCell(new Phrase("Producto", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Cantidad", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Precio Unitario", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Subtotal", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            // Agregar filas a la tabla
            Font cellFont = FontFactory.GetFont("Arial", 10);
            foreach (var item in listaPedido)
            {
                table.AddCell(new PdfPCell(new Phrase(item.Descripcion, cellFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(item.cantidad.ToString(), cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase($"${item.precioInsumo:F2}", cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase($"${item.cantidad * item.precioInsumo:F2}", cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            document.Add(table);
            document.Close();

            // Descargar PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=Pedido_" + idpedido + ".pdf");
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();


            Response.Redirect("Default.aspx");


        }
    }
}