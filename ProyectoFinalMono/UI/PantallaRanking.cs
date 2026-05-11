using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoFinalMono.Sistemas;

namespace ProyectoFinalMono.UI
{
    public class PantallaRanking
    {
        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
        {
            RegistroRanking registroRanking = new RegistroRanking();
            List<EntradaRanking> ranking = registroRanking.Cargar();

            spriteBatch.DrawString(fuente, "RANKING", new Vector2(300, 80), Color.White);

            int y = 140;

            for (int i = 0; i < ranking.Count; i++)
            {
                string linea = (i + 1) + ". " + ranking[i].Nombre + " - " + ranking[i].Puntuacion + " puntos - " + ranking[i].Fecha.ToShortDateString();
                spriteBatch.DrawString(fuente, linea, new Vector2(180, y), Color.Yellow);
                y += 35;
            }

            if (ranking.Count == 0)
            {
                spriteBatch.DrawString(fuente, "No hay puntuaciones guardadas", new Vector2(220, 160), Color.Yellow);
            }

            spriteBatch.DrawString(fuente, "ESC - Volver", new Vector2(260, 500), Color.Gray);
        }
    }
}