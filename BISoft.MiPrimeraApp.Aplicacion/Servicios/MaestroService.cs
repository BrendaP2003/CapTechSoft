using BISoft.MiPrimeraApp.Aplicacion.Response;
using MyPrimeraApp.Entidades;
using MyPrimeraApp.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.MiPrimeraApp.Aplicacion.Servicios
{
    
    public class MaestroService
    {
        private readonly IMaestroRepository _repo;

        public MaestroService(IMaestroRepository repo)
        {
            _repo = repo;
        }

        public Maestro CrearMaestro(string nombre, string apellido, string email, string direccion, string telefono)
        {
            var existemaestro = _repo.Obtener().Any(x => x.Email == email);
            if (existemaestro) 
            {
                throw new Exception("El maestro ya existe");
            }

            var maestro = new Maestro(nombre,apellido, email, direccion,telefono);
            _repo.Guardar(maestro);


            return maestro;

        }
        public List<Maestro> ObtenerMaestro()
        {
            return _repo.Obtener();
        }

        private MaestroDto ConvertToMaestroDto(Maestro maestro)
        {
            return new MaestroDto(maestro.Nombre, maestro.Apellido, maestro.Email, maestro.Direccion, maestro.Telefono);
        }

        public Maestro ObtenerMaestroPorId(int id)
        {
            return _repo.Obtener().FirstOrDefault(x => x.Id == id);
        }

       

    }

}

