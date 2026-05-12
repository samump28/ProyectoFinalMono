using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProyectoFinalMono.UI
{
    public class MenuPrincipal
    {
        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
        {
            spriteBatch.DrawString(fuente, "MENU PRINCIPAL", new Vector2(280, 120), Color.White);
            spriteBatch.DrawString(fuente, "ENTER - JUGAR", new Vector2(280, 190), Color.Yellow);
            spriteBatch.DrawString(fuente, "R - RANKING", new Vector2(280, 230), Color.Yellow);
            spriteBatch.DrawString(fuente, "ESC - SALIR", new Vector2(280, 270), Color.Yellow);
        }
    }
}