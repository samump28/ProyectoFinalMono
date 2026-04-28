using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace ProyectoFinalMono.Entidadess
{
    internal class Enemigo
    {
        // Posición del enemigo
        public Microsoft.Xna.Framework.Vector2 posicion;

        // Textura del enemigo
        private Texture2D textura;

        // Dirección de movimiento
        private Vector2 direccion;

        // Velocidad
        private float velocidad = 2f;

        // Random para movimiento
        private Random random = new Random();

        // Constructor correcto
        public Enemigo(Texture2D textura, Microsoft.Xna.Framework.Vector2 posicionInicial)
        {
            this.textura = textura;
            this.posicion = posicionInicial;

            direccion = new Vector2(1, 0);
        }

        // Movimiento automático
        public void Update(GameTime gameTime)
        {
            posicion += direccion * velocidad;

            // Cambiar dirección aleatoria
            if (random.Next(100) < 2)
            {
                CambiarDireccion();
            }
        }

        private void CambiarDireccion()
        {
            int valor = random.Next(4);

            switch (valor)
            {
                case 0:
                    direccion = new Vector2(1, 0);
                    break;

                case 1:
                    direccion = new Vector2(-1, 0);
                    break;

                case 2:
                    direccion = new Vector2(0, 1);
                    break;

                case 3:
                    direccion = new Vector2(0, -1);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicion, Color.White);
        }

        // Colisiones
        public Rectangle GetBounds()
        {
            return new Rectangle(
                (int)posicion.X,
                (int)posicion.Y,
                textura.Width,
                textura.Height
            );
        }
    }
}
