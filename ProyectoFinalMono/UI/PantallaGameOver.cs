using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProyectoFinalMono.UI
{
    public class PantallaGameOver
    {
        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente, int puntuacion)
        {
            spriteBatch.DrawString(fuente, "GAME OVER", new Vector2(300, 140), Color.Red);
            spriteBatch.DrawString(fuente, "Puntuacion final: " + puntuacion, new Vector2(260, 220), Color.Yellow);
            spriteBatch.DrawString(fuente, "ENTER - Volver al menu", new Vector2(240, 300), Color.Gray);
            spriteBatch.DrawString(fuente, "ESC - Salir", new Vector2(240, 340), Color.Gray);
        }
    }
}