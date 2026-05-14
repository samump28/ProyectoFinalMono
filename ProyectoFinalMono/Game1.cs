using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProyectoFinalMono.Entidadess;
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

        private Texture2D texturaEnemigo;
        private Texture2D texturaJugador;
        private Texture2D texturaPared;

        private Enemigo enemigo;
        private Jugador jugador;
        private Mapa mapa;

        private EstadoJuego estadoActual = EstadoJuego.Menu;

        private MenuPrincipal menuPrincipal;
        private PantallaNombre pantallaNombre;
        private PantallaRanking pantallaRanking;
        private PantallaGameOver pantallaGameOver;

        private string nombreJugador = "";
        private int puntuacion = 0;
        private int vidas = 3;
        private bool puntuacionGuardada = false;

        private KeyboardState tecladoActual;
        private KeyboardState tecladoAnterior;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            tecladoActual = Keyboard.GetState();
            tecladoAnterior = tecladoActual;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texturaEnemigo = Content.Load<Texture2D>("enemigo");
            texturaJugador = Content.Load<Texture2D>("jugador");
            texturaPared = Content.Load<Texture2D>("pared");

            fuente = Content.Load<SpriteFont>("fuente");

            enemigo = new Enemigo(
                texturaEnemigo,
                new Vector2(300, 200)
            );

            jugador = new Jugador(
                texturaJugador,
                new Vector2(100, 100)
            );

            mapa = new Mapa();

            menuPrincipal = new MenuPrincipal();

            pantallaNombre = new PantallaNombre();

            pantallaRanking = new PantallaRanking();

            pantallaGameOver = new PantallaGameOver();
        }

        protected override void Update(GameTime gameTime)
        {
            tecladoActual = Keyboard.GetState();

            if (estadoActual == EstadoJuego.Menu)
            {
                ActualizarMenu();
            }
            else if (estadoActual == EstadoJuego.Nombre)
            {
                ActualizarNombre();
            }
            else if (estadoActual == EstadoJuego.Jugando)
            {
                ActualizarJuego(gameTime);
            }
            else if (estadoActual == EstadoJuego.Ranking)
            {
                ActualizarRanking();
            }
            else if (estadoActual == EstadoJuego.GameOver)
            {
                ActualizarGameOver();
            }

            tecladoAnterior = tecladoActual;

            base.Update(gameTime);
        }

        private void ActualizarMenu()
        {
            menuPrincipal.Update();

            if (TeclaPulsada(Keys.Enter))
            {
                estadoActual = EstadoJuego.Nombre;
            }

            if (TeclaPulsada(Keys.R))
            {
                estadoActual = EstadoJuego.Ranking;
            }

            if (TeclaPulsada(Keys.Escape))
            {
                Exit();
            }
        }

        private void ActualizarNombre()
        {
            pantallaNombre.Update();

            if (pantallaNombre.EnterPulsado())
            {
                nombreJugador = pantallaNombre.Nombre;

                puntuacion = 0;

                vidas = 3;

                puntuacionGuardada = false;

                estadoActual = EstadoJuego.Jugando;
            }

            if (TeclaPulsada(Keys.Escape))
            {
                estadoActual = EstadoJuego.Menu;
            }
        }

        private void ActualizarJuego(GameTime gameTime)
        {
            Vector2 posicionAnterior = jugador.ObtenerPosicion();

            jugador.Update();

            if (mapa.HayColision(jugador.Rectangulo()))
            {
                jugador.CambiarPosicion(posicionAnterior);
            }

            if (mapa.RecogerPunto(jugador.Rectangulo()))
            {
                puntuacion += 10;
            }

            enemigo.Update(gameTime);

            if (jugador.Rectangulo().Intersects(enemigo.GetBounds()))
            {
                vidas--;
                jugador.CambiarPosicion(new Vector2(40, 40));
            }

            if (TeclaPulsada(Keys.G))
            {
                vidas = 0;
            }

            if (vidas <= 0)
            {
                estadoActual = EstadoJuego.GameOver;
            }
        }

        private void ActualizarRanking()
        {
            if (TeclaPulsada(Keys.Escape))
            {
                estadoActual = EstadoJuego.Menu;
            }
        }

        private void ActualizarGameOver()
        {
            if (!puntuacionGuardada)
            {
                RegistroRanking registroRanking = new RegistroRanking();

                registroRanking.Añadir(nombreJugador, puntuacion);

                puntuacionGuardada = true;
            }

            if (TeclaPulsada(Keys.Enter))
            {
                estadoActual = EstadoJuego.Menu;
            }

            if (TeclaPulsada(Keys.Escape))
            {
                Exit();
            }
        }

        private bool TeclaPulsada(Keys tecla)
        {
            return tecladoActual.IsKeyDown(tecla)
                && tecladoAnterior.IsKeyUp(tecla);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (estadoActual == EstadoJuego.Menu)
            {
                menuPrincipal.Draw(_spriteBatch, fuente);
            }
            else if (estadoActual == EstadoJuego.Nombre)
            {
                pantallaNombre.Draw(_spriteBatch, fuente);
            }
            else if (estadoActual == EstadoJuego.Jugando)
            {
                mapa.Dibujar(_spriteBatch, texturaPared);

                jugador.Draw(_spriteBatch);

                enemigo.Draw(_spriteBatch);

                DibujarJuego();
            }
            else if (estadoActual == EstadoJuego.Ranking)
            {
                pantallaRanking.Draw(_spriteBatch, fuente);
            }
            else if (estadoActual == EstadoJuego.GameOver)
            {
                pantallaGameOver.Draw(_spriteBatch, fuente, puntuacion);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DibujarJuego()
        {
            _spriteBatch.DrawString(
                fuente,
                "JUGANDO",
                new Vector2(300, 120),
                Color.White
            );

            _spriteBatch.DrawString(
                fuente,
                "Jugador: " + nombreJugador,
                new Vector2(300, 180),
                Color.Yellow
            );

            _spriteBatch.DrawString(
                fuente,
                "Puntuacion: " + puntuacion,
                new Vector2(300, 220),
                Color.Yellow
            );

            _spriteBatch.DrawString(
                fuente,
                "Vidas: " + vidas,
                new Vector2(300, 260),
                Color.Yellow
            );

            _spriteBatch.DrawString(
                fuente,
                "Pulsa G para probar Game Over",
                new Vector2(300, 320),
                Color.Gray
            );
        }
    }
}