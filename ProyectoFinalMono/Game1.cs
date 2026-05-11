using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProyectoFinalMono.UI;
using ProyectoFinalMono.Sistemas;

namespace ProyectoFinalMono
{
    public class Game1 : Game
    {
        private enum EstadoJuego
        {
            Menu,
            Nombre,
            Jugando,
            Ranking,
            GameOver
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont fuente;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texturaEnemigo = Content.Load<Texture2D>("enemigo");
            Vector2 vector2 = new(300, 200);
            enemigo = new Enemigo(
                texturaEnemigo, 
                vector2);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            }
        }

        private bool TeclaPulsada(Keys tecla)
        {
            bool pulsada = false;

            // TODO: Add your update logic here

            return pulsada;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            mapa.Dibujar(_spriteBatch, texturaPared);

            jugador.Draw(_spriteBatch);

            _spriteBatch.Begin();

            enemigo.Draw(_spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void DibujarJuego()
        {
            _spriteBatch.DrawString(fuente, "JUGANDO", new Vector2(300, 120), Color.White);
            _spriteBatch.DrawString(fuente, "Jugador: " + nombreJugador, new Vector2(300, 180), Color.Yellow);
            _spriteBatch.DrawString(fuente, "Puntuacion: " + puntuacion, new Vector2(300, 220), Color.Yellow);
            _spriteBatch.DrawString(fuente, "Vidas: " + vidas, new Vector2(300, 260), Color.Yellow);
            _spriteBatch.DrawString(fuente, "Pulsa G para probar Game Over", new Vector2(300, 320), Color.Gray);
        }
    }
}