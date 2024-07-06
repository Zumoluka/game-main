using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;  // Punto desde donde se disparará el proyectil
    public float projectileSpeed = 10f;  // Velocidad del proyectil
    public Rigidbody carRigidbody;  // Referencia al Rigidbody del auto

    public void Fire()
    {
        // Instanciar el proyectil en el punto de disparo y con la misma rotación que el cilindro
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Obtener el Rigidbody del proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Ajustar la velocidad del proyectil considerando la velocidad del auto
        Vector3 totalVelocity = carRigidbody.velocity + firePoint.forward * projectileSpeed * Time.deltaTime;
        rb.velocity = totalVelocity;
    }
}
