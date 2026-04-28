using Microsoft.Xna.Framework;

namespace ProyectoFinalMono.Sistemas
{
    internal class Colisiones
    {
        public static bool DetectarPared(Mapa mapa, Rectangle rect)
        {
            Rectangle rectJugador = new Rectangle(
                rect.X,
                rect.Y,
                rect.Width,
                rect.Height);

            bool colision = mapa.HayColision(rectJugador);

            return colision;
        }

        public static bool Detectar(Rectangle rect1, Rectangle rect2)
        {
            bool colision = rect1.Intersects(rect2);

            return colision;
        }

        public static bool DetectarJugadorEnemigo(Rectangle jugador, Rectangle enemigo)
        {
            bool colision = jugador.Intersects(enemigo);

            return colision;
        }

        public static bool DetectarJugadorPunto(Rectangle jugador, Rectangle punto)
        {
            bool colision = jugador.Intersects(punto);

            return colision;
        }
    }
}