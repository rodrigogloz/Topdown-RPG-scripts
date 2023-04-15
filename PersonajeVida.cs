public class PersonajeVida : VidaBase
{
    public bool PuedeSerCurado => Salud < saludMax;

    private void Update() 
    {
        if (input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        if (input.GetKeyDown(KeyCode.R))
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
        }
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {

    }
}