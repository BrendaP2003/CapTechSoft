using BISoft.MiPrimeraApp.Aplicacion.Response;
using MyPrimeraApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BISoft.MiPrimeraApp.Aplicacion.Response.AlumnoDto;

namespace BISoft.MiPrimeraApp.Aplicacion.Helpers
{
    public static class EntityExtensions
    {
        public static AlumnoDto ToDto(this Alumno alumno)
        {
            return new AlumnoDto(alumno.Id, alumno.Nombre, alumno.Apellido, alumno.Edad);
        }

        public static MaestroDto ToDto(this Maestro maestro )
        {
            return new MaestroDto(maestro.Nombre, maestro.Apellido, maestro.Direccion, maestro.Email, maestro.Telefono);
        }
    }
}
