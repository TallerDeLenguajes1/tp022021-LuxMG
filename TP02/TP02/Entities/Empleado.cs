using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP02.Entities
{
    public class Empleado
    {
        private string dni;
        private string nombre;
        private DateTime fechaNacimiento;
        private string direccion;
        private DateTime fechaIngreso;

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        
        public Empleado()
        {

        }

        public Empleado(string dni, string nombre, DateTime fechaNacimiento, string direccion, DateTime fechaIngreso)
        {
            Dni = dni;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            FechaIngreso = fechaIngreso;
        }

        public int Antiguedad()
        {
            double antiguedad = (DateTime.Now - FechaIngreso).TotalSeconds / 31536000; //cantidad de segundos entre las dos fechas / cantidad de segundos en un año
            return (int) antiguedad;
        }

        public int Edad()
        {
            double edad = (DateTime.Now - FechaNacimiento).TotalSeconds / 31536000;
            return (int) edad;
        }

        public double Salario(double sueldoBasico = 30000)
        {
            if (Antiguedad() > 20)
                return sueldoBasico + (sueldoBasico * 0.25) - (sueldoBasico * 0.15);
            else
                return sueldoBasico + (sueldoBasico * 0.01 * Antiguedad()) - (sueldoBasico * 0.15);
        }
    }
}
