using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;


namespace Negocio
{
    public class InsumoNegocio
    {
        public List<TipoInsumo> ListarTipoInsumo()
        {
            List<TipoInsumo> lista = new List<TipoInsumo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ListarTipoInsumos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoInsumo aux = new TipoInsumo();

                    aux.IdtipoInsumo = (int)datos.Lector["idTipoInsumo"];
                    aux.Descripciontipo = (string)datos.Lector["Descripciontipo"];


                    lista.Add(aux);


                }
                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Insumo> ListarConSp()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearProcedimiento("ListarInsumos");
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
        public List<Insumo> ListarXId(int id)
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearProcedimiento("ListarInsumosXid");
                datos.setearParametros("@idInsumo",id);
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
                    aux.IdTipoInsumo.IdtipoInsumo = (int)datos.Lector["IdTipoInsumo"];

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
        public void AgregarInsumo(Insumo nuevoInsumo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insInsumo");
                datos.setearParametros("@Descripcion", nuevoInsumo.Descripcion);
                datos.setearParametros("@IdTipoInsumo", nuevoInsumo.IdTipoInsumo.IdtipoInsumo);
                datos.setearParametros("@Cantidad", nuevoInsumo.Cantidad);
                datos.setearParametros("@Precio", nuevoInsumo.Precio);
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
        public void ModificarInsumo(Insumo nuevoInsumo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("updInsumo");
                datos.setearParametros("@IdInsumo", nuevoInsumo.IdInsumo);
                datos.setearParametros("@Descripcion", nuevoInsumo.Descripcion);
                datos.setearParametros("@IdTipoInsumo", nuevoInsumo.IdTipoInsumo.IdtipoInsumo);
                datos.setearParametros("@Cantidad", nuevoInsumo.Cantidad);
                datos.setearParametros("@Precio", nuevoInsumo.Precio);
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
        public void BajaLogicaInsumo(int id)
    {
        AccesoDatos datos = new AccesoDatos();


        try
        {

            datos.setearProcedimiento("delInsumo");
            datos.setearParametros("@IdInsumo", id);
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

        public void AgregarTipoInsumo(TipoInsumo nuevotipoinsumo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insTipoInsumo");
                datos.setearParametros("@Descripcion", nuevotipoinsumo.Descripciontipo);
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


    }


}


    
