using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public bool PuedeSerCurado => Salud < saludMax;

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad) 
    {
        if (PuedeSerCurado)
        {
            Salud += cantidad;
            if (Salud > saludMax)
            {
                Salud = saludMax;
            }

            ActualizarBarraVida(Salud, saludMax);
        }
    }

    protected override void PersonajeDerrotado() 
    {
        EventoPersonajeDerrotado?.Invoke();
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}