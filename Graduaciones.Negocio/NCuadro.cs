using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Graduaciones.Datos;

namespace Graduaciones.Negocio
{
    public class NCuadro
    {
        public static DataTable Listar()
        {
            DCuadro Datos = new DCuadro();
            return Datos.Listar();
        }
    }
}
