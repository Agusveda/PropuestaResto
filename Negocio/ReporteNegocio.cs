using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReporteNegocio
    {

        public List<Pedido> ObtenerDetallePedidoPorMesa(int idMesa)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ObtenerPedidoPorMesaREPORTE");
                datos.setearParametros("@IdMesa", idMesa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido pedidoaux = new Pedido();


                    pedidoaux.IdMesa = (int)datos.Lector["IdMesa"];
                        pedidoaux.Precio = (decimal)datos.Lector["Precio"];
                    pedidoaux.FechaHora = (DateTime)datos.Lector["FechaHora"];
                 
                    
                    lista.Add(pedidoaux);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }
        public List<PedidoReporte> ObtenerPedidoPorMesero(int idmesero)
        {
            List<PedidoReporte> lista = new List<PedidoReporte>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ObtenerPedidoPorMeseroREPORTE");
                datos.setearParametros("@IdUsuario", idmesero);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PedidoReporte pedidoaux = new PedidoReporte();


                    pedidoaux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    pedidoaux.IdMesa = (int)datos.Lector["IdMesa"];
                    pedidoaux.Nombre = (string)datos.Lector["Nombre"];
                    pedidoaux.Precio = (decimal)datos.Lector["Precio"];
                    pedidoaux.FechaHora = (DateTime)datos.Lector["FechaHora"];



                    lista.Add(pedidoaux);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }




    }
}
