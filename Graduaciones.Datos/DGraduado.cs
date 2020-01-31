using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Graduaciones.Entidades;
using System.Data.SqlClient;

namespace Graduaciones.Datos
{
    public class DGraduado
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("graduados_listar",SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
        }

        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("graduados_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
               // Comando.Parameters.Add("@valor2", SqlDbType.VarChar).Value = valor2;
                //Comando.Parameters.Add("@valor3", SqlDbType.VarChar).Value = valor3;
                //Comando.Parameters.Add("@valor4", SqlDbType.VarChar).Value = valor4;
                //Comando.Parameters.Add("@valor5", SqlDbType.VarChar).Value = valor5;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

        }

        public string Insertar(Graduado obj)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("graduados_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@instituto", SqlDbType.VarChar).Value = obj.Instituto;
                Comando.Parameters.Add("@grupo", SqlDbType.VarChar).Value = obj.Grupo;
                Comando.Parameters.Add("@turno", SqlDbType.VarChar).Value = obj.Turno;
                Comando.Parameters.Add("@generacion", SqlDbType.VarChar).Value = obj.Generacion;
                Comando.Parameters.Add("@idAnillo", SqlDbType.VarChar).Value = obj.IdAnillo;
                Comando.Parameters.Add("@idCuadro", SqlDbType.VarChar).Value = obj.IdCuadro;
                Comando.Parameters.Add("@idFoto", SqlDbType.VarChar).Value = obj.IdFoto;
                Comando.Parameters.Add("@abono", SqlDbType.VarChar).Value = obj.Abono;
                Comando.Parameters.Add(@"estado", SqlDbType.VarChar).Value = obj.Estado = 1;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }

        public string Actualizar(Graduado obj)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("graduados_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idGraduado", SqlDbType.VarChar).Value = obj.idGraduado;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@instituto", SqlDbType.VarChar).Value = obj.Instituto;
                Comando.Parameters.Add("@grupo", SqlDbType.VarChar).Value = obj.Grupo;
                Comando.Parameters.Add("@turno", SqlDbType.VarChar).Value = obj.Turno;
                Comando.Parameters.Add("@generacion", SqlDbType.VarChar).Value = obj.Generacion;
                Comando.Parameters.Add("@abono", SqlDbType.VarChar).Value = obj.Abono;


                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }

        public string Eliminar(int Id)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("graduados_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idGraduado", SqlDbType.VarChar).Value = Id;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }


           

    }
}
