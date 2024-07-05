using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float velocidad = 5f; // Velocidad a la que el objeto seguir� al jugador

    void Update()
    {
        if (jugador != null) // Verificar que haya un jugador asignado
        {
            // Obtener la direcci�n hacia la cual moverse
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize(); // Normalizar para mantener la misma velocidad en todas las direcciones

            // Mover el objeto en la direcci�n del jugador
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
}
