using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTargetingMouse : MonoBehaviour
{
    public Transform playerTransform;
    public Camera mainCamera;
    public float smoothSpeed = 5f;

    private Quaternion targetRotation;

    void Update()
    {
        // Obtenemos la posición del puntero del ratón en el mundo
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        // Obtenemos la dirección desde la posición del jugador hasta la posición del puntero del ratón
        Vector3 direction = mousePosition - playerTransform.position;
        direction.z = 0f;

        // Rotamos la dirección para apuntar hacia el puntero del ratón
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.AngleAxis(angle + -90f, Vector3.forward);

        // Suavizamos el movimiento de la luz hacia la nueva rotación
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // Establecemos la posición de la luz en la posición del objeto del jugador
        transform.position = playerTransform.position;
    }
}
