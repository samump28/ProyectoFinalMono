using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalMono.Entidadess;

namespace ProyectoFinalMono.Sistemas
{
    public class GestorNiveles
    {
        public List<Nivel> Niveles { get; private set; }
        public int NivelActualIndex { get; private set; } = 0;

        public GestorNiveles()
        {
            Niveles = new List<Nivel>();
            CrearNiveles();
        }

        private void CrearNiveles()
        {
            // NIVEL 1
            Nivel nivel1 = new Nivel(1);

            // Ejemplo de añadir enemigos
            // nivel1.EnemigosDelNivel.Add(new Enemigo(new Vector2(100, 100)));

            // Ejemplo de añadir powerups
            // nivel1.PowerUpsDelNivel.Add(new PowerUpVelocidad(5f, 2f));

            Niveles.Add(nivel1);

            // NIVEL 2
            Nivel nivel2 = new Nivel(2);

            // nivel2.EnemigosDelNivel.Add(new Enemigo(new Vector2(200, 150)));
            // nivel2.PowerUpsDelNivel.Add(new PowerUpVelocidad(5f, 3f));

            Niveles.Add(nivel2);

            // más niveles
        }

        public Nivel NivelActual()
        {
            return Niveles[NivelActualIndex];
        }

        public void SiguienteNivel()
        {
            if (NivelActualIndex < Niveles.Count - 1)
                NivelActualIndex++;
        }

        public void Reiniciar()
        {
            NivelActualIndex = 0;
        }
    }
}
