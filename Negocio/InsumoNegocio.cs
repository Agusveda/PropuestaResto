﻿using System;
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




        //}
        //public void Modificar(Articulo nuevoarticulo)
        //{
        //    Conexion_Comandos Accesodatos = new Conexion_Comandos();
        //    try
        //    {

        //        Accesodatos.setearConsulta("Update ARTICULOS set Codigo = @Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,Precio=@Precio where Id = @Id");
        //        Accesodatos.setearParametros("@Id", nuevoarticulo.id);
        //        Accesodatos.setearParametros("@Codigo", nuevoarticulo.Codigo);
        //        Accesodatos.setearParametros("@Nombre", nuevoarticulo.Nombre);
        //        Accesodatos.setearParametros("@Descripcion", nuevoarticulo.descripcion);
        //        Accesodatos.setearParametros("@IdMarca", nuevoarticulo.idMarca.Id);
        //        Accesodatos.setearParametros("@IdCategoria", nuevoarticulo.idCategoria.Id);
        //        Accesodatos.setearParametros("@Precio", nuevoarticulo.Precio);
        //        Accesodatos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        Accesodatos.cerrarConexion();


        //    }





        //}
        //public void BajaLogica(Articulo nuevoarticulo)
        //{
        //    Conexion_Comandos Accesodatos = new Conexion_Comandos();
        //    try
        //    {

        //        Accesodatos.setearConsulta("Update ARTICULOS set Precio= -1 where Id = @Id");
        //        Accesodatos.setearParametros("@Id", nuevoarticulo.id);
        //        Accesodatos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        Accesodatos.cerrarConexion();
        //    }
        //}

        //public List<Articulo> FiltrarArticulos(string campo, string criterio, string filtro)
        //{
        //    List<Articulo> lista = new List<Articulo>();
        //    Conexion_Comandos datos = new Conexion_Comandos();

        //    try
        //    {
        //        string consulta = "select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left join CATEGORIAS C on C.Id = A.IdCategoria left join IMAGENES I on I.IdArticulo = A.Id where Precio > 0 and ";
        //        if (campo == "Precio.")
        //        {
        //            switch (criterio)
        //            {
        //                case "Mayor a..":
        //                    consulta += "Precio > @Precio";
        //                    break;
        //                case "Menor a..":
        //                    consulta += "Precio < @Precio";
        //                    break;
        //                default:
        //                    consulta += "Precio = @Precio";
        //                    break;
        //            }
        //            datos.setearParametros("@Precio", Convert.ToDecimal(filtro));
        //        }
        //        else if (campo == "Nombre.")
        //        {
        //            switch (criterio)
        //            {
        //                case "comienza con..":
        //                    consulta += "Nombre like @Filtro + '%'";
        //                    break;
        //                case "Termina con..":
        //                    consulta += "Nombre like '%' + @Filtro";
        //                    break;
        //                default:
        //                    consulta += "Nombre like '%' + @Filtro + '%'";
        //                    break;
        //            }
        //            datos.setearParametros("@Filtro", filtro);
        //        }

        //        datos.setearConsulta(consulta);
        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {
        //            Articulo aux = new Articulo();

        //            aux.id = (int)datos.Lector["id"];
        //            aux.Codigo = (string)datos.Lector["Codigo"];
        //            aux.Nombre = (string)datos.Lector["Nombre"];
        //            aux.descripcion = (string)datos.Lector["Descripcion"];

        //            // para poder cargar IdMarca

        //            aux.idMarca = new Marca();
        //            aux.idMarca.Id = (int)datos.Lector["IdMarca"];
        //            aux.idMarca.Descripcion = (string)datos.Lector["DescripcionMarca"];

        //            //Creamos un aux categoria para poder cargar las columnas

        //            aux.idCategoria = new Categoria();
        //            if (datos.Lector["DescripcionCate"] is DBNull && datos.Lector["Idcategoria"] is DBNull)
        //            {
        //                aux.idCategoria.Descripcion = "Sin descripcion";
        //                aux.idCategoria.Id = 0;
        //            }
        //            else
        //            {

        //                aux.idCategoria.Id = (int)datos.Lector["Idcategoria"];
        //                aux.idCategoria.Descripcion = (string)datos.Lector["DescripcionCate"];
        //            }


        //            // me aseguro que no sea nulo
        //            aux.IdImagenUrl = new Imagenes();
        //            if (datos.Lector["ImagenURL"] is DBNull && datos.Lector["IdImg"] is DBNull)
        //            {
        //                aux.IdImagenUrl.id = 0;
        //                aux.IdImagenUrl.ImagenURL = "";
        //            }
        //            else
        //            {

        //                aux.IdImagenUrl.id = (int)datos.Lector["IdImg"];
        //                aux.IdImagenUrl.ImagenURL = (string)datos.Lector["ImagenUrl"];
        //            }



        //            aux.Precio = (decimal)datos.Lector["Precio"];
        //            lista.Add(aux);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void BajaFisica(Articulo bajaFisica)
        //{
        //    Conexion_Comandos datos = new Conexion_Comandos();

        //    try
        //    {
        //        datos.setearConsulta("delete from articulos where id = @id");
        //        datos.setearParametros("@id",bajaFisica.id);
        //        datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}


    
