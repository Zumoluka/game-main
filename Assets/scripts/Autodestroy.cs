using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    public float lifetime = 8f;  // Tiempo de vida del proyectil en segundos

    void Start()
    {
        // Destruir el GameObject después de `lifetime` segundos
        Destroy(gameObject, lifetime);
    }
}
