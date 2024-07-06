using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Autodestroy : MonoBehaviour
{
    public float slowDownDuration = 2f; // Duración del efecto de ralentización
    public float slowDownFactor = 0.5f; // Factor de ralentización (0.5 significa reducir la velocidad a la mitad)

    void Start()
    {
        // Destruir la bala después de 8 segundos
        Destroy(gameObject, 8f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener el componente NavMeshAgent del enemigo
            NavMeshAgent enemyAgent = collision.gameObject.GetComponent<NavMeshAgent>();
            if (enemyAgent != null)
            {
                // Ralentizar al enemigo
                StartCoroutine(SlowDownEnemy(enemyAgent));
            }

            // Destruir la bala al impactar
            Destroy(gameObject);
        }
    }

    private IEnumerator SlowDownEnemy(NavMeshAgent enemyAgent)
    {
        // Guardar la velocidad original del enemigo
        float originalSpeed = enemyAgent.speed;
        Debug.Log($"Velocidad original: {originalSpeed}");

        // Aplicar el efecto de ralentización
        float reducedSpeed = originalSpeed * slowDownFactor;
        enemyAgent.speed = reducedSpeed;
        Debug.Log($"Velocidad reducida: {enemyAgent.speed}");

        // Esperar la duración del efecto de ralentización
        yield return new WaitForSeconds(slowDownDuration);
    }
}
