using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Graduaciones.Datos;

namespace Graduaciones.Negocio
{
   public class NAnillo
    {
        public static DataTable Listar()
        {
            DAnillo Datos = new DAnillo();
            return Datos.Listar();
        }
    }
}
