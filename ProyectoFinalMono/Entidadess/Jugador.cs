using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProyectoFinalMono.Entidadess
{
    public class Jugador
    {
        private Texture2D textura;
        private Vector2 posicion;
        private int tamaño = 40;
        private float velocidad = 4f;

        public Jugador(Texture2D textura, Vector2 posicionInicial)
        {
            this.textura = textura;
            posicion = posicionInicial;
        }

        public void Update()
        {
            KeyboardState teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.W) || teclado.IsKeyDown(Keys.Up))
            {
                posicion.Y -= velocidad;
            }

            if (teclado.IsKeyDown(Keys.S) || teclado.IsKeyDown(Keys.Down))
            {
                posicion.Y += velocidad;
            }

            if (teclado.IsKeyDown(Keys.A) || teclado.IsKeyDown(Keys.Left))
            {
                posicion.X -= velocidad;
            }

            if (teclado.IsKeyDown(Keys.D) || teclado.IsKeyDown(Keys.Right))
            {
                posicion.X += velocidad;
            }
        }

        public void CambiarPosicion(Vector2 nuevaPosicion)
        {
            posicion = nuevaPosicion;
        }

        public Vector2 ObtenerPosicion()
        {
            return posicion;
        }

        public Rectangle Rectangulo()
        {
            return new Rectangle(
                (int)posicion.X,
                (int)posicion.Y,
                tamaño,
                tamaño
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                textura,
                Rectangulo(),
                Color.White
            );
        }
    }
}