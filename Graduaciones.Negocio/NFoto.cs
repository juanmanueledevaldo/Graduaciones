using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Graduaciones.Datos;

namespace Graduaciones.Negocio
{
    public class NFoto
    {
        public static DataTable Listar()
        {
            DFoto Datos = new DFoto();
            return Datos.Listar();
        }
    }
}
