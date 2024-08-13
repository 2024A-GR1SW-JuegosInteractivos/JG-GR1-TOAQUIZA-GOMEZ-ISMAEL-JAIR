using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    [SerializeField] private float delayDestroy = 0.2f;
    private string tipoDeBasura; // para almacenar el tipo de basura que tiene el jugador
    [SerializeField] Color32 tieneBasuraColor = new Color32(255, 140, 0, 255);
    [SerializeField] Color32 noTieneBasuraColor = new Color32(255, 255, 255, 255); // Blanco (color normal)
    private SpriteRenderer spriteRenderer;
    private puntaje puntajeScript; // Referencia al script de puntaje

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        puntajeScript = FindObjectOfType<puntaje>(); // Buscar el script de puntaje en la escena
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!string.IsNullOrEmpty(tipoDeBasura))
        {
            // Si el jugador ya tiene basura y toca un contenedor, verificamos si es el correcto.
            if (other.tag == "Organic" && tipoDeBasura == "Fruit")
            {
                ActualizarPuntaje(1, "Correctly disposed of waste");
            }
            else if (other.tag == "Paper" && tipoDeBasura == "Paper")
            {
                ActualizarPuntaje(1, "Correctly disposed of waste");
            }
            else if (other.tag == "Plastic" && tipoDeBasura == "Plastic")
            {
                ActualizarPuntaje(1, "Correctly disposed of waste");
            }
            else if (other.tag == "Glass" && tipoDeBasura == "Glass")
            {
                ActualizarPuntaje(1, "Correctly disposed of waste");
            }
            else
            {
                ActualizarPuntaje(-1, "Incorrectly disposed of waste");
            }
        }
        else if (string.IsNullOrEmpty(tipoDeBasura) && (other.tag == "Fruit" || other.tag == "Paper" || other.tag == "Plastic" || other.tag == "Glass"))
        {
            // Si el jugador no tiene basura, puede recoger un nuevo objeto.
            RecogerBasura(other.tag, other.gameObject);
        }
    }

    private void RecogerBasura(string tipo, GameObject objeto)
    {
        tipoDeBasura = tipo;
        spriteRenderer.color = tieneBasuraColor;
        Destroy(objeto, delayDestroy);
    }

    private void ActualizarPuntaje(int cantidad, string mensaje)
    {
        puntajeScript.IncreaseScore(cantidad);
        Debug.Log(mensaje);
        spriteRenderer.color = noTieneBasuraColor;
        tipoDeBasura = null;
    }
}
