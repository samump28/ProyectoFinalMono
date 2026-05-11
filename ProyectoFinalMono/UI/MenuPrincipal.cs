using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ProyectoFinalMono.Sistemas;

namespace ProyectoFinalMono.UI
{
    internal class MenuPrincipal
    {
        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
        {
            spriteBatch.DrawString(fuente, "MENU PRINCIPAL", new Vector2(280, 120), Color .White);
            spriteBatch.DrawString(fuente, "ENTER - Jugar", new Vector2(280, 190), Color.Yellow);
            spriteBatch.DrawString(fuente, "R - Ranking", new Vector2(280, 230), Color.Yellow);
            spriteBatch.DrawString(fuente, "ESC - Salir", new Vector2(280, 270), Color.Yellow);
        }
    }
}
