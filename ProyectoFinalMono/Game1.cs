using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProyectoFinalMono.Entidadess;
using ProyectoFinalMono.Sistemas;

namespace ProyectoFinalMono
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texturaJugador;
        private Texture2D texturaPared;

        private Jugador jugador;
        private Mapa mapa;

        private int puntuacion = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            mapa = new Mapa();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texturaJugador = new Texture2D(GraphicsDevice, 1, 1);
            texturaJugador.SetData(new[] { Color.Yellow });

            texturaPared = new Texture2D(GraphicsDevice, 1, 1);
            texturaPared.SetData(new[] { Color.Blue });

            jugador = new Jugador(texturaJugador, new Vector2(50, 50));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.Escape))
                Exit();

            Vector2 posicionAnterior = jugador.posicion;

            jugador.Update();

            if (Colisiones.DetectarPared(mapa, jugador.Rectangulo()))
                jugador.posicion = posicionAnterior;

            if (mapa.RecogerPunto(jugador.Rectangulo()))
                puntuacion += 10;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            mapa.Dibujar(_spriteBatch, texturaPared);

            jugador.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}