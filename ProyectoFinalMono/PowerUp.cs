using System;

public abstract class PowerUp
{

    public string Tipo { get; protected set; }
    public float Duracion { get; protected set; }

    private float tiempoRestante;
    private bool activo;

    public PowerUp(string tipo, float duracion)
    {
        Tipo = tipo;
        Duracion = duracion;
        tiempoRestante = duracion;
        activo = false;
    }

    public void Activar(Jugador jugador)
    {
        if (!activo)
        {
            activo = true;
            tiempoRestante = Duracion;
            AplicarEfecto(jugador);
        }
    }

    public void Actualizar(float deltaTime, Jugador jugador)
    {
        if (activo)
        {
            tiempoRestante -= deltaTime;

            if (tiempoRestante <= 0)
            {
                Desactivar(jugador);
                activo = false;
            }
        }


    }

    public void Desactivar(Jugador jugador)
    {
        RemoverEfecto(jugador);
    }

    protected abstract void AplicarEfecto(Jugador jugador);
    protected abstract void RemoverEfecto(Jugador jugador);
}