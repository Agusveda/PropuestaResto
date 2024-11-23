using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MeseroNegocio
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ListarUsuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Password = (string)datos.Lector["Password"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
                    aux.EsAdmin = (bool)datos.Lector["EsAdmin"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insUsuario");
                datos.setearParametros("NombreUsuario", nuevoUsuario.NombreUsuario);
                datos.setearParametros("@Password", nuevoUsuario.Password);
                datos.setearParametros("@Nombre", nuevoUsuario.Nombre);
                datos.setearParametros("@Apellido", nuevoUsuario.Apellido);
                datos.setearParametros("@EsAdmin", nuevoUsuario.EsAdmin);
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
        public List<Usuario> ListarXId(int id)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearProcedimiento("ListarUsuariosxId");
                datos.setearParametros("@idUsuario", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Password = (string)datos.Lector["Password"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
                    aux.EsAdmin = (bool)datos.Lector["EsAdmin"];



                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarUsuario(Usuario modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("updUsuario");
                datos.setearParametros("@idUsuario", modificado.IdUsuario);
                datos.setearParametros("@NombreUsuario", modificado.NombreUsuario);
                datos.setearParametros("@Password", modificado.Password);
                datos.setearParametros("@Nombre", modificado.Nombre);
                datos.setearParametros("@Apellido", modificado.Apellido);
                datos.setearParametros("@EsAdmin", modificado.EsAdmin);
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

        public void BajaLogicaUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            MeseroNegocio negocio = new MeseroNegocio();

            try
            {

                datos.setearProcedimiento("delUsuario");
                datos.setearParametros("@IdUsuario", id);
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

