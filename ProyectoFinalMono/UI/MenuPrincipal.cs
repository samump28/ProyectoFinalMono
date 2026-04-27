using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using system;
public enum OpcionMenu
{
    Ninguna,
    Jugar,
    Ranking,
    Salir
}

public class MenuPrincipal
{
    private string[] opciones;
    private int indiceSeleccionado;
    private KeyboardState tecladoAnterior;

    public MenuPrincipal()
    {
        opciones = new string[] { "Jugar", "Ver ranking", "Salir" };
        indiceSeleccionado = 0;
        tecladoAnterior = Keyboard.GetState();
    }

    public OpcionMenu Update()
    {
        KeyboardState tecladoActual = Keyboard.GetState();
        OpcionMenu opcionElegida = OpcionMenu.Ninguna;

        if (tecladoActual.IsKeyDown(Keys.Down) && tecladoAnterior.IsKeyUp(Keys.Down))
        {
            indiceSeleccionado++;

            if (indiceSeleccionado >= opciones.Length)
            {
                indiceSeleccionado = 0;
            }
        }

        if (tecladoActual.IsKeyDown(Keys.Up) && tecladoAnterior.IsKeyUp(Keys.Up))
        {
            indiceSeleccionado--;

            if (indiceSeleccionado < 0)
            {
                indiceSeleccionado = opciones.Length - 1;
            }
        }

        if (tecladoActual.IsKeyDown(Keys.Enter) && tecladoAnterior.IsKeyUp(Keys.Enter))
        {
            if (indiceSeleccionado == 0)
            {
                opcionElegida = OpcionMenu.Jugar;
            }
            else if (indiceSeleccionado == 1)
            {
                opcionElegida = OpcionMenu.Ranking;
            }
            else if (indiceSeleccionado == 2)
            {
                opcionElegida = OpcionMenu.Salir;
            }
        }

        tecladoAnterior = tecladoActual;

        return opcionElegida;
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont fuente)
    {
        int i;

        spriteBatch.DrawString(fuente, "MENU PRINCIPAL", new Vector2(250, 120), Color.White);

        for (i = 0; i < opciones.Length; i++)
        {
            Color colorTexto = Color.White;

            if (i == indiceSeleccionado)
            {
                colorTexto = Color.Yellow;
            }

            spriteBatch.DrawString(
                fuente,
                opciones[i],
                new Vector2(280, 190 + i * 40),
                colorTexto
            );
        }
    }
}