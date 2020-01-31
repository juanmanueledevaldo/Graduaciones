using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduaciones.Entidades
{
    public class Graduado
    {
        public int idGraduado { get; set; }
        public string Nombre { get; set; }
        public string Instituto { get; set; }
        public string Grupo { get; set; }
        public string Turno { get; set; }
        public int Generacion { get; set; }
        public int IdAnillo { get; set; }
        public int IdCuadro { get; set; }
        public int IdFoto { get; set; }
        public int Abono { get; set; }
        public int Estado { get; set; }


    }
}
