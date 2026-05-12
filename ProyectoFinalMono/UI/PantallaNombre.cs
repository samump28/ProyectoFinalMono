using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProyectoFinalMono.UI
{
    public class PantallaNombre
    {
        private string nombre = string.Empty;
        private bool enterPulsado;
        private KeyboardState tecladoAnterior;

        public string Nombre => nombre;

        public void Update()
        {
            KeyboardState tecladoActual = Keyboard.GetState();

            enterPulsado = tecladoActual.IsKeyDown(Keys.Enter) && !tecladoAnterior.IsKeyDown(Keys.Enter);

            foreach (Keys tecla in tecladoActual.GetPressedKeys())
            {
                if (!tecladoAnterior.IsKeyDown(tecla))
                {
                    if (tecla == Keys.Back && nombre.Length > 0)
                    {
                        nombre = nombre[..^1];
                    }
                    else if (tecla == Keys.Space)
                    {
                        nombre += " ";
                    }
                    else if (tecla >= Keys.A && tecla <= Keys.Z)
                    {
                        nombre += tecla.ToString();
                    }
                }
            }

            tecladoAnterior = tecladoActual;
        }

        public bool EnterPulsado()
        {
            return enterPulsado && !string.IsNullOrWhiteSpace(nombre);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
        {
            spriteBatch.DrawString(fuente, "INTRODUCE TU NOMBRE", new Vector2(220, 140), Color.White);
            spriteBatch.DrawString(fuente, nombre + "_", new Vector2(260, 220), Color.Yellow);
            spriteBatch.DrawString(fuente, "ENTER - CONTINUAR", new Vector2(240, 320), Color.Gray);
            spriteBatch.DrawString(fuente, "ESC - VOLVER", new Vector2(260, 360), Color.Gray);
        }
    }
}
