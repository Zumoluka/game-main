using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f; // Duración del juego en segundos
    public TextMeshProUGUI winText; // Referencia al texto de victoria
    private bool gameWon = false;

    private float elapsedTime = 0f;

    void Start()
    {
        winText.gameObject.SetActive(false); // Asegúrate de que el texto de victoria esté oculto al inicio
    }

    void Update()
    {
        if (!gameWon)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= gameDuration)
            {
                WinGame();
            }
        }

        if (gameWon && Input.GetKeyDown(KeyCode.C))
        {
            RestartGame();
        }
    }

    void WinGame()
    {
        gameWon = true;
        Time.timeScale = 0f; // Detener el tiempo en el juego
        winText.gameObject.SetActive(true); // Mostrar el texto de victoria
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Restaurar la escala de tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual
    }
}
