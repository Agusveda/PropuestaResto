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






    }


}
