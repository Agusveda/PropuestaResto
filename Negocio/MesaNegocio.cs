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
