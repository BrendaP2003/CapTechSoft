using BISoft.MiPrimeraApp.Aplicacion.Response;
using MyPrimeraApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.MiPrimeraApp.Aplicacion.Helpers
{
    public static class DtoExtensions
    {
        public static Alumno ToEntity(this AlumnoDto alumnoDto)
        {
            return new Alumno(alumnoDto.Nombre, alumnoDto.Apellido, $"{alumnoDto.Nombre}.{alumnoDto.Apellido}@gmail.com");
        }
    }
}
