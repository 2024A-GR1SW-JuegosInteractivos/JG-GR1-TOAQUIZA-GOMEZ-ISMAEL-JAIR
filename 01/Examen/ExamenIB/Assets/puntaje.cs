using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Asegúrate de tener el espacio de nombres TextMeshPro

public class puntaje : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Referencia al componente TextMeshProUGUI
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Método para incrementar el puntaje
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Método para actualizar el texto del puntaje
    private void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + score.ToString();
    }
}
