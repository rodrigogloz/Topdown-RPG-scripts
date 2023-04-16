using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{

    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float regeneracionPorSegundo;

    public float manaActual { get; private set; }

    private PersonajeVida _personajeVida;

    private void Awake() 
    {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    private void Start()
    {
        manaActual = manaInicial;
        ActualizarBarraMana();

        InvokeRepeating(nameof(RegenerarMana), 1, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10f);
        }
    }

    public void UsarMana(float cantidad)
    {
        if (manaActual >= cantidad)
        {
                manaActual -= cantidad;
                ActualizarBarraMana();

        }
    }

    private void RegenerarMana()
    {
        if (_personajeVida.Salud > 0f && manaActual < manaMax)
        {
            manaActual += regeneracionPorSegundo;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana()
    {
        manaActual = manaInicial;
        ActualizarBarraMana();
    }

    private void ActualizarBarraMana()
    {
        UIManager.Instance.ActualizarManaPersonaje(manaActual, manaMax);
    }
}
