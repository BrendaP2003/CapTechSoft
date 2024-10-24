using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyPrimeraApp.Entidades.Maestro;

namespace MyPrimeraApp.Entidades
{
    public class Alumno:Entidad
    {
        
        public int Edad { get; set; } = 12; //Regla de negocio


        public Alumno(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = 12;//Regla de negocio


          
            //usar regex para validar email
            if(string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                throw new InvalidOperationException("El email no es valido");
            }

            Email = email;
        }


        public Alumno()
        {
            
        }

        //Sobrecarga de constructor
        //public Alumno(string nombre, string apellido,string email,int edad)
        //{
        //    Nombre = nombre;
        //    Apellido = apellido;
        //    Email = email;
        //    Edad = edad;
        //}
        public override string ToString()
        {
            return Nombre + "," + Apellido + ","  + Email + "," + Edad;
        }
        public override void ReadTxt(string linea)
        {
            var valores = linea.Split(',');
            Nombre = valores[(int)AlumnoColum.Nombre];
            Apellido = valores[(int)AlumnoColum.Apellido];
            Email = valores[(int)AlumnoColum.Email];
            Edad = int.Parse(valores[(int)AlumnoColum.Edad]);
           




        }
        public enum AlumnoColum : int
        {

            Nombre = 0,
            Apellido,
            Email,
            Edad
          
          
        }

    }
}
