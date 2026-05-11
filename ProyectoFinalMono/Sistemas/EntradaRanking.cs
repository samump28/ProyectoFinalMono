using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMono.Sistemas
{
    internal class EntradaRanking
    {
        public string Nombre { get; set; }
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }
        public EntradaRanking(string nombre, int puntuacion)
        {
            Nombre = nombre;
            Puntuacion = puntuacion;
            Fecha = DateTime.Now;
        }
    }
}
