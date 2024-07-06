using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxSpeed = 10f; // Velocidad máxima a alcanzar
    public float accelerationDuration = 5f; // Tiempo para alcanzar la velocidad máxima

    private NavMeshAgent navMeshAgent;
    private float originalSpeed;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            originalSpeed = navMeshAgent.speed;
            StartCoroutine(IncreaseSpeed());
        }
        else
        {
            Debug.LogError("NavMeshAgent not found on the enemy!");
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        float elapsedTime = 0f;
        while (elapsedTime < accelerationDuration)
        {
            navMeshAgent.speed = Mathf.Lerp(originalSpeed, maxSpeed, elapsedTime / accelerationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        navMeshAgent.speed = maxSpeed; // Asegurarse de que la velocidad final es la máxima
        Debug.Log($"Velocidad máxima alcanzada: {navMeshAgent.speed}");
    }
}
