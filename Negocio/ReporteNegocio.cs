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

        
            public int ObtenerCantidadTotalInsumos()
        {

            AccesoDatos datos = new AccesoDatos();
            int montototal = 0;
            try
            {


                datos.setearProcedimiento("ObtenerCantidadTotalInsumos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Insumo aux = new Insumo();

                    montototal = (int)datos.Lector["Total"];

                    
                }
                return montototal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal ObtenerMontoTotal()
        {
            AccesoDatos datos = new AccesoDatos();
            decimal montototal = 0;
            try
            {


                datos.setearProcedimiento("ObtenerMontoTotal");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    montototal = (decimal)datos.Lector["Total"];

                   
                }
                return montototal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MontoPorFecha> ObtenerMontoTotalPorFecha()
        {
            AccesoDatos datos = new AccesoDatos();
            List<MontoPorFecha> lista = new List<MontoPorFecha>();

            try
            {
                datos.setearProcedimiento("ObtenerMontoTotalporFecha");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MontoPorFecha aux = new MontoPorFecha
                    {
                        FechaHora = (DateTime)datos.Lector["FechaHora"],
                        MontoTotal = (decimal)datos.Lector["MontoTotal"]
                    };

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el monto total por fechas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


        public List<MeseroPorMesa> ObtenerMeseroPorMesaTotal()
        {
            AccesoDatos datos = new AccesoDatos();
            List<MeseroPorMesa> lista = new List<MeseroPorMesa>();

            try
            {
                datos.setearProcedimiento("ObtenerMeseroPorMesaTotal");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MeseroPorMesa aux = new MeseroPorMesa
                    {
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        IdMesa = (int)datos.Lector["IdMesa"],
                        Precio = (decimal)datos.Lector["Precio"],
                        FechaHora = (DateTime)datos.Lector["FechaHora"]
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

