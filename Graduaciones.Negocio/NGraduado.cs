using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Graduaciones.Datos;
using Graduaciones.Entidades;

namespace Graduaciones.Negocio
{
    public class NGraduado
    {
        public static DataTable Listar()
        {
            DGraduado Datos = new DGraduado();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DGraduado Datos = new DGraduado();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Nombre, string Instituto, string Grupo, string Turno, int Generacion, int idAnillo, int idCuadro, int idFoto, int abono)
        {
            DGraduado Datos = new DGraduado();
            Graduado Obj = new Graduado();
            Obj.Nombre = Nombre;
            Obj.Instituto = Instituto;
            Obj.Grupo = Grupo;
            Obj.Turno = Turno;
            Obj.Generacion = Generacion;
            Obj.IdAnillo = idAnillo;
            Obj.IdCuadro = idCuadro;
            Obj.IdFoto = idFoto;
            Obj.Abono = abono;
            return Datos.Insertar(Obj);
        }



        public static string Actualizar(int IdGraduado, string Nombre, string Instituto, string Grupo, string Turno, int Generacion, int abono)
        {
            DGraduado Datos = new DGraduado();
            Graduado Obj = new Graduado();
            Obj.idGraduado = IdGraduado;
            Obj.Nombre = Nombre;
            Obj.Instituto = Instituto;
            Obj.Grupo = Grupo;
            Obj.Turno = Turno;
            Obj.Generacion = Generacion;
            Obj.Abono = abono;
            //Obj.IdAdeudo = idAdeudo;
            //Obj.IdAnillo = idAnillo;
            //Obj.IdCuadro = idCuadro;
            //Obj.IdFoto = idFoto;
            return Datos.Actualizar(Obj);
        }

        public static string Eliminar(int Id)
        {
            DGraduado Datos = new DGraduado();
            return Datos.Eliminar(Id);
        }

    }
}
