using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MesaNegocio
    {

        public List<Mesa> listarMesas()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();



            try
            {

            datos.setearProcedimiento("Listarmesas");
            datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Mesa aux = new Mesa();

                    aux.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.Disponible = (bool)datos.Lector["Disponible"];
                    aux.Asignada = (bool)datos.Lector["Asignada"];
                    aux.idMeseroAsignado = (int)datos.Lector["idMeseroAsignado"];

                    lista.Add(aux);




                }
                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }









        }


        public void ActualizarMesa(int idmesa , bool disponible)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("updMesa");
                datos.setearParametros("@IdMesa", idmesa);
                datos.setearParametros("@disponible", disponible);
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
