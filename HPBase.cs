using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    public float Salud { get; protected set; }

    void Start()
    {
        
    }

    public void RecibirDaño(float cantidad)
    {
        if (cantidad <= 0) 
        {
            return;
        }

        if (Salud > 0f) 
        {
            Salud -= cantidad;
            ActualizarBarraVida(vidaActual:Salud, saludMax);
            if (Salud <= 0f)
            {
                ActualizarBarraVida(vidaActual:Salud, saludMax);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMax)
    {

    }

    protected virtual void PersonajeDerrotado() 
    {

    }
}
