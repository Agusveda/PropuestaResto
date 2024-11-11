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
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
    }
}
