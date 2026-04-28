using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMono.Sistemas
{
    internal class Mapa
    {
        public string[] grid =
        {
            "111111111111111",
            "100000000000001",
            "101111011111101",
            "100000000000001",
            "111111111111111"
        };

        private int tile = 40;

        public void Dibujar(SpriteBatch spriteBatch, Texture2D texturaPared)
        {
            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == '1')
                    {
                        spriteBatch.Draw(
                            texturaPared,
                            new Rectangle(x * tile, y * tile, tile, tile),
                            Color.White);
                    }

                    if (grid[y][x] == '0')
                    {
                        spriteBatch.Draw(
                            pixel,
                            new Rectangle(x * tile + 16, y * tile + 16, 8, 8),
                            Color.Yellow);
                    }
                }
            }
        }

        public bool HayColision(Rectangle rect)
        {
            bool colision = false;
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == '1')
                    {
                        Rectangle muro = new Rectangle(x * tile, y * tile, tile, tile);

                        if (rect.Intersects(muro))
                            colision = true;
                    }
                }
            }

            return colision;
        }

        public bool RecogerPunto(Rectangle jugadorRect)
        {
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == '0')
                    {
                        Rectangle punto = new Rectangle(
                            x * tile + 12,
                            y * tile + 12,
                            16,
                            16);

                        if (jugadorRect.Intersects(punto))
                        {
                            char[] fila = grid[y].ToCharArray();
                            fila[x] = '2';
                            grid[y] = new string(fila);

                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
