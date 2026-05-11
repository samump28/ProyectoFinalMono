using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProyectoFinalMono.UI
{
    public class PantallaNombre
    {
        private string nombre = "";
        private KeyboardState tecladoAnterior;

        public string Nombre
        {
            get { return nombre; }
        }

        public void Update()
        {
            KeyboardState teclado = Keyboard.GetState();

            foreach (Keys tecla in teclado.GetPressedKeys())
            {
                if (tecladoAnterior.IsKeyUp(tecla))
                {
                    if (tecla >= Keys.A && tecla <= Keys.Z && nombre.Length < 12)
                    {
                        nombre += tecla.ToString();
                    }

                    if (tecla == Keys.Back && nombre.Length > 0)
                    {
                        nombre = nombre.Substring(0, nombre.Length - 1);
                    }
                }
            }

            tecladoAnterior = teclado;
        }

        public bool EnterPulsado()
        {
            bool pulsado = false;
            KeyboardState teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.Enter) && tecladoAnterior.IsKeyUp(Keys.Enter) && nombre.Length > 0)
            {
                pulsado = true;
            }

            return pulsado;
        }

        public void Reiniciar()
        {
            nombre = "";
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
        {
            spriteBatch.DrawString(fuente, "INTRODUCE TU NOMBRE", new Vector2(230, 140), Color.White);
            spriteBatch.DrawString(fuente, nombre, new Vector2(230, 210), Color.Yellow);
            spriteBatch.DrawString(fuente, "ENTER - Comenzar", new Vector2(230, 290), Color.Gray);
            spriteBatch.DrawString(fuente, "BACKSPACE - Borrar", new Vector2(230, 330), Color.Gray);
            spriteBatch.DrawString(fuente, "ESC - Volver", new Vector2(230, 370), Color.Gray);
        }
    }
}