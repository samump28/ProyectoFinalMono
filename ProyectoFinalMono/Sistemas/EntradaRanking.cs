using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMono.Sistemas
{
    public class EntradaRanking
    {
        public string Nombre { get; set; } = string.Empty;
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }

        public EntradaRanking()
        {
        }

        public EntradaRanking(string nombre, int puntuacion)
        {
            Nombre = nombre;
            Puntuacion = puntuacion;
            Fecha = DateTime.Now;
        }
    }
}
