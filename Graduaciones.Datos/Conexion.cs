using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Graduaciones.Datos
{
    public class Conexion
    {
        //Se almacena nombre y BD a la cual se hara la conexión
        private string Base;
        //Indica el servidor en el cual está alojado el proyecto
        private string Servidor;
        //Usuario para acceder a la BD
        private string Usuario;
        //Clave del Usuario para acceder a la BD
        private string Clave;
        //Indica la manera en la que se trabajara la seguridad (Autenticación de Windows o SQl Server)
        private bool Seguridad;
        //Instancia de la Clase Conexion
        private static Conexion Con = null;

        //Constructor private para no poder ser instanciada por otra clase
        private Conexion()
        {
            this.Base = "Graduaciones";
            this.Servidor = ".";
            this.Usuario = "Juanio\\juan";
            this.Clave = "";
            this.Seguridad = true;
        }


        //Metodo de Conexion a BD validando si la conexion es con Autenticación de Windows o SQL
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if(this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + "Password=" + this.Clave;
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        //Metodo para obtener la instancia del contructor privado Conexion
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
