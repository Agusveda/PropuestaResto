using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Insumo
    {
        public int IdInsumo { get; set; } 
        public string Descripcion { get; set; }
        public TipoInsumo IdTipoInsumo { get; set; } // relacionada a la clase TipoInsumo
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }



    }
}
