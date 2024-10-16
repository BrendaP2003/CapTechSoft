﻿using Microsoft.EntityFrameworkCore;
using MyPrimeraApp.Contextos;
using MyPrimeraApp.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.SqlServer;
using MyPrimeraApp.Fabrica;
using static MyPrimeraApp.Fabrica.AlumnoRepositoryFactory;
using BISoft.MiPrimeraApp.Aplicacion.Servicios;
using BISoft.MiPrimeraApp.Aplicacion.Fabrica;

namespace MyPrimeraApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            //var repoSql = AlumnoRepositoryFactory
            //    .CrearAlumnoRepository(DBType.Sqlite);
            //    //new AlumnoRepository(context);

            var servicio = ServiceFactory.CrearAlumnoService(DBType.Sqlite);

            var form = new frmAlumnos(servicio);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var repoSql = AlumnoRepositoryFactory
                .CrearAlumnoRepository(DBType.Txt);
            //new AlumnoRepository(context);
        }
    }
}
