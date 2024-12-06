using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {

        public List<Insumo> ListarConSp()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearProcedimiento("ListarPedido");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Insumo aux = new Insumo();

                    aux.IdInsumo = (int)datos.Lector["IdInsumo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    // para poder cargar el tipo de insumo que es
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.IdTipoInsumo = new TipoInsumo();
                    aux.IdTipoInsumo.Descripciontipo = (string)datos.Lector["TipoInsumo"];




                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public int IdDetallePedido { get; set; }
        //public int IdPedido { get; set; }
        //public int IdInsumo { get; set; }
        //public int Cantidad { get; set; }


        public void AgregarPedido(Pedido NuevoPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insPedido");
                datos.setearParametros("@IdMesa", NuevoPedido.IdMesa);
                datos.setearParametros("@IdUsuario", NuevoPedido.IdUsuario);
                datos.setearParametros("@PrecioFinal", NuevoPedido.Precio);
                datos.setearParametros("@Finalizado", NuevoPedido.Finalizado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();


            }
        }
        public void AgregarDetallePedido(Insumo insumo, int idpedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Verificar si el insumo ya está en el detalle del pedido
                datos.setearProcedimiento("VerificarInsumoEnDetallePedido");
                datos.setearParametros("@IdPedido", idpedido);
                datos.setearParametros("@IdInsumo", insumo.IdInsumo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    // Obtener la cantidad actual 
                    int cantidadActual = (int)datos.Lector["Cantidad"];

                    // cierro por excepcion
                    datos.cerrarConexion();

                    // si el pedido existe se modifica la cantidad, significa que se modifico la cantiadad mas o menos.
                    datos = new AccesoDatos();
                    datos.setearProcedimiento("ActualizarCantidadInsumo");
                    datos.setearParametros("@IdPedido", idpedido);
                    datos.setearParametros("@IdInsumo", insumo.IdInsumo);
                    datos.setearParametros("@NuevaCantidad", cantidadActual + insumo.Cantidad);
                    datos.ejecutarAccion();
                    return;
                }

               // cierro la conexion para que no me traiga excepcion
                datos.cerrarConexion();

                // abro de nuevo la conexion
                datos = new AccesoDatos();
                datos.setearProcedimiento("insDetallePedido");
                datos.setearParametros("@IdPedido", idpedido);
                datos.setearParametros("@IdInsumo", insumo.IdInsumo);
                datos.setearParametros("@PrecioInsumo", insumo.Precio);
                datos.setearParametros("@Cantidad", insumo.Cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // Cerrar conexión finalmente
            }
        }






        public List<Insumo> ObtenerDetallePedidoPorMesa(int idMesa)
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ObtenerPedidoPorMesa");
                datos.setearParametros("@IdMesa", idMesa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        Precio = (decimal)datos.Lector["Precio"]
                    };
                    lista.Add(insumo);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }
        public List<Insumo> ObtenerDetallePedidoPorId(int idPedido)
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ObtenerDetallePedidoPorId");
                datos.setearParametros("@IdPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        Precio = (decimal)datos.Lector["Precio"]
                    };
                    lista.Add(insumo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


        public Pedido ObtenerPedidoActivoPorMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();
            Pedido pedido = null;

            try
            {
                datos.setearProcedimiento("ObtenerPedidoActivoPorMesa");
                datos.setearParametros("@IdMesa", idMesa);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    pedido = new Pedido
                    {
                        IdPedido = (int)datos.Lector["IdPedido"],
                        IdMesa = (int)datos.Lector["IdMesa"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Finalizado = (bool)datos.Lector["Finalizado"],
                        FechaHora = (DateTime)datos.Lector["FechaHora"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return pedido;
        }
        public void FinalizarPedido(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("FinalizarPedido");
                datos.setearParametros("@IdPedido", idPedido);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void EliminarTodosInsumosDelPedido(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("EliminarTodosInsumosDelPedido");
                datos.setearParametros("@IdPedido", idPedido);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void RestarCantidadEnInsumos(int idinsumo, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("RestarCantidadEnInsumos");
                datos.setearParametros("@IdInsumo", idinsumo);
                datos.setearParametros("@cantidad", cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void SumarCantidadEnInsumos(int idinsumo, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SumarCantidadEnInsumos");
                datos.setearParametros("@IdInsumo", idinsumo);
                datos.setearParametros("@cantidad", cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void EliminarInsumoDelPedido(int idinsumo, int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("EliminarInsumoDelPedido");
                datos.setearParametros("@idpedido", idPedido);
                datos.setearParametros("@idInsumo", idinsumo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ActualizarPrecioPedido(int idPedido, decimal nuevoPrecio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ActualizarPrecioPedido");
                datos.setearParametros("@IdPedido", idPedido);
                datos.setearParametros("@NuevoPrecio", nuevoPrecio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public int ObtenerUltimoIdPedido()
        {
            int idpedido = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearProcedimiento("Obtenerultimoidpedido");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                   idpedido = (int)datos.Lector["IdPedido"];




                  
                return idpedido;
                }
               return  idpedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }

    }



