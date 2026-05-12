using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProyectoFinalMono.UI
{
    public class PantallaGameOver
    {
        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente, int puntuacion)
        {
            spriteBatch.DrawString(fuente, "GAME OVER", new Vector2(300, 140), Color.Red);

            spriteBatch.DrawString(
                fuente,
                "PUNTUACION FINAL: " + puntuacion,
                new Vector2(240, 220),
                Color.Yellow
            );

            spriteBatch.DrawString(
                fuente,
                "ENTER - VOLVER AL MENU",
                new Vector2(220, 300),
                Color.Gray
            );

            spriteBatch.DrawString(
                fuente,
                "ESC - SALIR",
                new Vector2(220, 340),
                Color.Gray
            );
        }
    }
}