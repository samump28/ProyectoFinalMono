using ProyectoFinalMono.Entidadess;
using ProyectoFinalMono.PowerUps;
using System.Collections.Generic;

namespace ProyectoFinalMono.Sistemas
{
    public class Nivel
    {
        public int Numero { get; private set; }

        public List<Enemigo> EnemigosDelNivel { get; private set; }
        public List<PowerUp> PowerUpsDelNivel { get; private set; }

        public Nivel(int numero)
        {
            Numero = numero;

            EnemigosDelNivel = new List<Enemigo>();
            PowerUpsDelNivel = new List<PowerUp>();
        }
    }
}
