using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Pedido
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public int IdUsuario { get; set; }
        public decimal Precio { get; set; } // precio del producto, luego realizaria la suma total
        public bool Finalizado{ get; set; }
        public DateTime FechaHora { get; set; }

    }

    public class PedidoReporte
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdMesa { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaHora { get; set; }
    }
    public class PedidoFinalizado
    {
        public int idPedido { get; set; }
        public int idDetallePedido { get; set; }
        public int IdInsumo { get; set; }
        public string Descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precioInsumo{ get; set; }
        public DateTime FechaHora { get; set; }
        public decimal PrecioTotal { get; set; }
    }
    public class MontoPorFecha
    {
        public DateTime FechaHora { get; set; }
        public decimal MontoTotal { get; set; }
    }
    public class MeseroPorMesa
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdMesa { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaHora { get; set; }
    }


}
