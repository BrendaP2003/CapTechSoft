using BISoft.MiPrimeraApp.Aplicacion.Helpers;
using BISoft.MiPrimeraApp.Aplicacion.Response;
using MyPrimeraApp.Entidades;
using MyPrimeraApp.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BISoft.MiPrimeraApp.Aplicacion.Response.AlumnoDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BISoft.MiPrimeraApp.Aplicacion.Servicios
{
    public class AlumnoService
    {


        private readonly IAlumnoRepository _repo;

        public AlumnoService(IAlumnoRepository repo)
        {
            _repo = repo;
        }

        //public Alumno CrearAlumno(string nombre, string apellido, string email)
        public AlumnoDto CrearAlumno(string nombre, string apellido, string email)
        {
           
            //Alumno alumno;
            var alumnoConsultado = _repo.Obtener().FirstOrDefault(alumno=>alumno.Nombre == nombre);
            
            if (alumnoConsultado is not null)
            {
                throw new InvalidOperationException("El alumno ya existe");  
            }

            var alumno = new Alumno(nombre, apellido, email);
            _repo.Guardar(alumno);
            return alumno.ToDto();
            //return alumno;
        }

       // public List<Alumno> ObtenerAlumnos()
        public List<AlumnoDto> ObtenerAlumnos()
        {
            
            var lista = new List<AlumnoDto>();
            var alumnos = _repo.Obtener();
            foreach (var alumno in alumnos)
            {
                lista.Add(alumno.ToDto());
            }
            return lista;
        }
        private AlumnoDto ConvertToAlumnoDto(Alumno alumno)
        {
            return new AlumnoDto(alumno.Id, alumno.Nombre, alumno.Apellido, alumno.Edad);
        }
    }
    //public List<Alumno> ObtenerAlumnos()
    //    {
    //        return _repo.Obtener();
    //    }
    //}
}
