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
                datos.cerrarConexion();
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



