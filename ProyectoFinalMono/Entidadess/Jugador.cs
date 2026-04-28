using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMono.Entidadess
{
    public class Jugador
    {
        public Texture2D textura;
        private Texture2D texturaOriginal;
        private Texture2D texturaPowerUp;

        public Vector2 posicion;
        public float velocidad = 3f;

        public Jugador(Texture2D tex, Vector2 pos)
        {
            textura = tex;
            texturaOriginal = tex;
            posicion = pos;
        }
        public void CambiarSprite(Texture2D nuevaTextura)
        {
            texturaPowerUp = nuevaTextura;
            textura = nuevaTextura;
        }

        public void RestaurarSprite()
        {
            textura = texturaOriginal;
        }


        public void Update()
        {
            KeyboardState teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.W))
                posicion.Y -= velocidad;

            if (teclado.IsKeyDown(Keys.S))
                posicion.Y += velocidad;

            if (teclado.IsKeyDown(Keys.A))
                posicion.X -= velocidad;

            if (teclado.IsKeyDown(Keys.D))
                posicion.X += velocidad;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicion, Color.White);
        }

        public Rectangle Rectangulo()
        {
            return new Rectangle((int)posicion.X, (int)posicion.Y, 32, 32);
        }
    }
}
