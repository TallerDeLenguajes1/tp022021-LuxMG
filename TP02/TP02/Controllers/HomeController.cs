using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TP02.Entities;
using TP02.Models;
using NLog;

namespace TP02.Controllers
{
    public class HomeController : Controller
    {
        public static List<Empleado> empleados = new List<Empleado>();
        private readonly Logger nlog;

        public HomeController(Logger nlog)
        {
            this.nlog = nlog;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Empleados(string nombre, string dni, DateTime fechaNac, string direccion, DateTime fechaIngr)
        {
            try
            {
                Empleado E = new Empleado(dni, nombre, fechaNac, direccion, fechaIngr);
                empleados.Add(E);
                nlog.Info(E.Nombre + "; " + E.Edad() + "; " + E.Antiguedad() + "; " + E.Salario());

                return View(empleados);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
