using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.MiPrimeraApp.Aplicacion.Request
{
    public record CrearMaestro (string Nombre, string Apellido, string Email, string Direccion, string Telefono);
    
}
